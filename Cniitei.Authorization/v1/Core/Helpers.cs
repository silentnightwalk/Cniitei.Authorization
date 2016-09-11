using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Core
{
    /// <summary>
    /// definition of extension methods
    /// </summary>

    public static class GenericElementsListHelper
    {
        internal static void AddIfCasts<TElm>(this IList<TElm> list, IElement element)
            where TElm : class, IElement
        {
            list = list ?? new List<TElm>();

            if (element is TElm)
            {
                list.Add(element as TElm);
            }
        }
    }

    public static class ElementCollectionHelper
    {
        internal static TElm CniiteiSingle<TElm>(this IEnumerable<IElement> elements)
            where TElm : class
        {
            if (elements == null)
            {
                throw new Exception($"One element of type '{typeof(TElm).Name}' should be defined");
            }

            var filtered = elements.Where(x => x is TElm);

            if (filtered.Count() == 1)
            {
                return filtered.First() as TElm;
            }

            throw new Exception($"Only single element of type '{typeof(TElm).Name}' should be defined");
        } 

        internal static IEnumerable<TElm> CniiteiFilter<TElm>(this IEnumerable<IElement> elements)
            where TElm : class
        {
            if (elements == null)
            {
                return Enumerable.Empty<TElm>();
            }

            return elements.Where(x => x is TElm).Select(x => x as TElm);
        }

    }

    public static class ElementBuilderHelper
    {
        internal static ModelBuildingErrorSource CreateErrorSource(this ElmBuilderBase elmBuilder)
        {
            return new ModelBuildingErrorSource()
            {
                ElmType = elmBuilder.ElmType,
                GlobalIndex = elmBuilder.GlobalIndex,
                LocalIndex = elmBuilder.LocalIndex,
                UniqueKeyIfExists = elmBuilder.UniqueKeyIfExists
            };
        }
    }
}
