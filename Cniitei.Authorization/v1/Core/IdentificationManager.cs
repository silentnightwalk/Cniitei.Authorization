using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Core
{
    /// <summary>
    /// this class is used to define indexes (IDs) for decision tree elements.
    /// also check uniqueness of keys
    /// </summary>

    internal class IdentificationManager
    {
        private SingleIndexGenerator m_LocalIndexGenerator = new SingleIndexGenerator(1);
        private SingleIndexGenerator m_GlobalIndexGenerator;
        private List<string> m_UniqueKeys;

        public IdentificationManager()
            : this(new SingleIndexGenerator(), Enumerable.Empty<string>())
        {
                
        }

        protected IdentificationManager(SingleIndexGenerator globalIndexGenerator, IEnumerable<string> uniqueKeys)
        {
            m_GlobalIndexGenerator = globalIndexGenerator;
            m_UniqueKeys = new List<string>(uniqueKeys);
        }

        public int NextGlobalIndex()
        {
            return m_GlobalIndexGenerator.Next();
        }

        public int NextLocalIndex()
        {
            return m_LocalIndexGenerator.Next();
        }

        public void CheckAddUniqueKey(string uniqueKey)
        {
            if (String.IsNullOrWhiteSpace(uniqueKey))
            {
                throw new Exception($"Key must not be null or white space."); 
            }

            int duplicatesCount = m_UniqueKeys.Where(x => x == uniqueKey).Count();

            if (duplicatesCount > 0)
            {
                throw new Exception($"Key must be unique. Key '{uniqueKey}' has already been used.");
            }

            m_UniqueKeys.Add(uniqueKey);
        }

        public IdentificationManager Another()
        {
            return new IdentificationManager(m_GlobalIndexGenerator, m_UniqueKeys);
        }
    }

    internal class SingleIndexGenerator
    {
        private int m_Current = 0;

        internal SingleIndexGenerator(int startIndex = 0)
        {
            m_Current = startIndex;
        }

        internal int Next()
        {
            m_Current++;
            return m_Current - 1;
        }
    }
}
