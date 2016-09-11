using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Core
{
    public class CniiteiAuthorizationModelBuildingException: Exception
    {
        internal CniiteiAuthorizationModelBuildingException(
            Exception innerException, 
            IEnumerable<ModelBuildingErrorSource> trace,
            string userMethodName = ""
            )
            :base(ToMessage(trace, innerException, userMethodName), innerException)
        {

        }

        private static string ToMessage(IEnumerable<ModelBuildingErrorSource> trace, Exception innerException, string userMethodInfo = "")
        {
            var stringBuilder = new StringBuilder();
            
            stringBuilder.AppendLine($"Cniitei authorization model building exception with the following parameters:");
            stringBuilder.AppendLine("");
            if (!String.IsNullOrWhiteSpace(userMethodInfo))
            {
                stringBuilder.AppendLine($" - Method info: '{userMethodInfo}';");
            }
            stringBuilder.AppendLine(" - Has the following location inside the tree of elements (from top level downwards):");

            foreach (var t in trace)
            {
                stringBuilder.AppendLine(
                    $"    / '{t.ElmType}' element" + 
                    $" with definition order #{t.LocalIndex}" + 
                    $" (id={t.GlobalIndex}" + 
                    $"{( !String.IsNullOrWhiteSpace(t.UniqueKeyIfExists)? $", uniquekey={t.UniqueKeyIfExists}" : "" )}" + 
                    $")"
                    );
            }
            stringBuilder.AppendLine("");

            if (!String.IsNullOrWhiteSpace(innerException?.Message))
            {
                stringBuilder.AppendLine(" - Inner exception message:");
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine(innerException.Message);

                if (innerException.InnerException != null)
                {
                    stringBuilder.AppendLine("");
                    stringBuilder.AppendLine(" - Have a look, the inner exception has another inner exception!");
                }
            }
            
            return stringBuilder.ToString();
        }
    }
}
