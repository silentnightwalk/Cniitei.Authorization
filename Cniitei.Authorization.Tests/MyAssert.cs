using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.Tests
{
    //taken from 
    //https://github.com/bbraithwaite/MSTestExtensions
    //thanks to the author


    /// <summary>
    /// Assertion methods for checking exceptions.
    /// </summary>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public static class MyAssert
    {
        /// <summary>
        /// Assertion method to verify that an exception is thrown.
        /// </summary>
        /// <param name="task">The function or method under test.</param>
        /// <param name="expectedMessage">The expected message.</param>
        /// <param name="messageOptions">The message options for specifying assertion rules for the exception message.</param>
        /// <param name="inheritOptions">The inherit options for specifying assertion rules for the exception type.</param>
        /// <typeparam name="T">The type of the expected exception.</typeparam>
        /// <returns>The <see cref="T"/>. Returns the exception instance.</returns>
        public static T Throws<T>(Action task, string expectedMessage, ExceptionMessageCompareOptions messageOptions, ExceptionInheritanceOptions inheritOptions) where T : Exception
        {
            try
            {
                task();
            }
            catch (Exception ex)
            {
                return ExceptionAssert.CheckException<T>(expectedMessage, messageOptions, inheritOptions, ex);
            }

            ExceptionAssert.OnNoExceptionThrown<T>();

            return default(T);
        }

        #region Overloaded methods

        public static T Throws<T>(this IAssertion assertion, Action task, ExceptionInheritanceOptions inheritOptions = ExceptionInheritanceOptions.Inherits) where T : Exception
        {
            return Throws<T>(task, null, ExceptionMessageCompareOptions.None, inheritOptions);
        }

        public static T Throws<T>(Action task, ExceptionInheritanceOptions inheritOptions = ExceptionInheritanceOptions.Inherits) where T : Exception
        {
            return Throws<T>(task, null, ExceptionMessageCompareOptions.None, inheritOptions);
        }

        public static T Throws<T>(this IAssertion assertion, Action task, string expectedMessage, ExceptionInheritanceOptions inheritOptions = ExceptionInheritanceOptions.Inherits) where T : Exception
        {
            return Throws<T>(task, expectedMessage, ExceptionMessageCompareOptions.Exact, inheritOptions);
        }

        public static T Throws<T>(Action task, string expectedMessage, ExceptionInheritanceOptions inheritOptions = ExceptionInheritanceOptions.Inherits) where T : Exception
        {
            return Throws<T>(task, expectedMessage, ExceptionMessageCompareOptions.Exact, inheritOptions);
        }

        public static T Throws<T>(this IAssertion assertion, Action task, string expectedMessage, ExceptionMessageCompareOptions options, ExceptionInheritanceOptions inheritOptions = ExceptionInheritanceOptions.Inherits) where T : Exception
        {
            return Throws<T>(task, expectedMessage, options, inheritOptions);
        }

        public static Exception Throws(this IAssertion assertion, Action task, string expectedMessage, ExceptionMessageCompareOptions options, ExceptionInheritanceOptions inheritOptions = ExceptionInheritanceOptions.Inherits)
        {
            return Throws<Exception>(task, expectedMessage, options, inheritOptions);
        }

        public static Exception Throws(Action task, string expectedMessage, ExceptionMessageCompareOptions options, ExceptionInheritanceOptions inheritOptions = ExceptionInheritanceOptions.Inherits)
        {
            return Throws<Exception>(task, expectedMessage, options, inheritOptions);
        }

        public static Exception Throws(this IAssertion assertion, Action task, string expectedMessage, ExceptionInheritanceOptions inheritOptions = ExceptionInheritanceOptions.Inherits)
        {
            return Throws<Exception>(task, expectedMessage, ExceptionMessageCompareOptions.Exact, inheritOptions);
        }

        public static Exception Throws(Action task, string expectedMessage, ExceptionInheritanceOptions inheritOptions = ExceptionInheritanceOptions.Inherits)
        {
            return Throws<Exception>(task, expectedMessage, ExceptionMessageCompareOptions.Exact, inheritOptions);
        }

        public static Exception Throws(this IAssertion assertion, Action task, ExceptionInheritanceOptions inheritOptions = ExceptionInheritanceOptions.Inherits)
        {
            return Throws<Exception>(task, null, ExceptionMessageCompareOptions.None, inheritOptions);
        }

        public static Exception Throws(Action task, ExceptionInheritanceOptions inheritOptions = ExceptionInheritanceOptions.Inherits)
        {
            return Throws<Exception>(task, null, ExceptionMessageCompareOptions.None, inheritOptions);
        }

        #endregion
    }


    //--------

    /// <summary>
    /// Common methods used by Throws and ThrowsAsync methods for verifying exception properties.
    /// </summary>
    internal static class ExceptionAssert
    {
        /// <summary>
        /// Fails the test if no exception is thrown by the method under test.
        /// </summary>
        /// <typeparam name="T">The type of the expected exception.</typeparam>
        public static void OnNoExceptionThrown<T>() where T : Exception
        {
            if (typeof(T).Equals(new Exception().GetType()))
            {
                Assert.Fail("Expected exception but no exception was thrown.");
            }
            else
            {
                Assert.Fail(string.Format("Expected exception of type {0} but no exception was thrown.", typeof(T)));
            }
        }

        /// <summary>
        /// The check exception.
        /// </summary>
        /// <param name="expectedMessage">The expected message.</param>
        /// <param name="messageOptions">The message options for specifying assertion rules for the exception message.</param>
        /// <param name="inheritOptions">The inherit options for specifying assertion rules for the exception type.</param>
        /// <param name="ex">The exception thrown by the method under test.</param>
        /// <typeparam name="T">The type of the expected exception.</typeparam>
        /// <returns>The <see cref="T"/>. Returns the exception instance.</returns>
        public static T CheckException<T>(string expectedMessage, ExceptionMessageCompareOptions messageOptions, ExceptionInheritanceOptions inheritOptions, Exception ex) where T : Exception
        {
            AssertExceptionType<T>(ex, inheritOptions);
            AssertExceptionMessage(ex, expectedMessage, messageOptions);
            return (T)ex;
        }

        /// <summary>
        /// Asserts that the exception type is an exact match i.e. not inherited.
        /// </summary>
        /// <param name="ex">The exception thrown by the method under test.</param>
        /// <typeparam name="T">The type of the expected exception.</typeparam>
        /// <remarks>
        /// E.g it's possible to clearly assert a type of ArgumentException without the assert passing when an ArgumentNullException is thrown.
        /// </remarks>
        private static void AssertExceptionNotInherited<T>(Exception ex)
        {
            Assert.IsFalse(ex.GetType().IsSubclassOf(typeof(T)));
        }

        /// <summary>
        /// Asserts the type of the exception with the expected type (T)
        /// </summary>
        /// <param name="ex">The exception thrown by the method under test.</param>
        /// <param name="inheritanceOptions">The options.</param>
        /// <typeparam name="T">The type of the expected exception.</typeparam>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception for invalid or None option.</exception>
        private static void AssertExceptionType<T>(Exception ex, ExceptionInheritanceOptions inheritanceOptions)
        {
            Assert.IsInstanceOfType(ex, typeof(T), "Expected exception type failed.");
            switch (inheritanceOptions)
            {
                case ExceptionInheritanceOptions.Exact:
                    AssertExceptionNotInherited<T>(ex);
                    break;
                case ExceptionInheritanceOptions.Inherits:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("inheritanceOptions");

            }
        }

        /// <summary>
        /// Assert the message of the exception.
        /// </summary>
        /// <param name="ex">The exception thrown by the method under test.</param>
        /// <param name="expectedMessage">The expected message.</param>
        /// <param name="messageOptions">The message options for specifying assertion rules for the exception message.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception for invalid or None option.</exception>
        private static void AssertExceptionMessage(Exception ex, string expectedMessage, ExceptionMessageCompareOptions messageOptions)
        {
            if (!string.IsNullOrEmpty(expectedMessage))
            {
                switch (messageOptions)
                {
                    case ExceptionMessageCompareOptions.Exact:
                        Assert.AreEqual(expectedMessage, ex.Message, "Expected exception message failed.");
                        break;
                    case ExceptionMessageCompareOptions.IgnoreCase:
                        Assert.AreEqual(expectedMessage, ex.Message, true, "Expected exception message failed.");
                        break;
                    case ExceptionMessageCompareOptions.Contains:
                        Assert.IsTrue(ex.Message.Contains(expectedMessage), string.Format("Expected exception message does not contain <{0}>.", expectedMessage));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("messageOptions");
                }

            }
        }
    }

    //--------

    public interface IAssertion
    {

    }

    //--------

    /// <summary>
    /// Options for asserting the message values of an exception with the expected message.
    /// </summary>
    public enum ExceptionMessageCompareOptions
    {
        /// <summary>
        ///  Not Set.
        /// </summary>
        None,

        /// <summary>
        /// The exception message must exactly match to expected value.
        /// </summary>
        Exact,

        /// <summary>
        /// The exception message can contain partially match the expected value (useful for verbose exception messages).
        /// </summary>
        Contains,

        /// <summary>
        /// The case of the actual exception message against the expected will be ignored.
        /// </summary>
        IgnoreCase
    }

    //--------

    /// <summary>
    /// Options for asserting the expected type of an exception.
    /// </summary>
    public enum ExceptionInheritanceOptions
    {
        /// <summary>
        ///  Not Set.
        /// </summary>
        None,

        /// <summary>
        /// The exception type must be the exact type i.e. not a subtype.
        /// </summary>
        Exact,

        /// <summary>
        /// The exception type can still match if its inherited type matches the assertion.
        /// </summary>
        Inherits
    }

    //--------
}
