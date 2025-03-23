using System.Collections.Generic;

namespace Unicorn.UI.Core.Matchers
{
    internal static class UiMatchersUtils
    {
        internal static string DescribeCollection<T>(IEnumerable<T> collection, int trimLength)
        {
            string itemsList = string.Join(", ", collection);

            if (itemsList.Length > trimLength)
            {
                itemsList = itemsList.Substring(0, trimLength) + " etc . . .";
            }

            return itemsList;
        }
    }
}
