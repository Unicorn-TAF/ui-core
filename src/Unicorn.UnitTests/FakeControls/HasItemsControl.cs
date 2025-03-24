using System.Collections.Generic;
using Unicorn.UI.Core.Controls.Interfaces;

namespace Unicorn.UnitTests.FakeControls
{
    class HasItemsControl : IHasItems
    {
        public IList<string> Items => new List<string> { "item1", "item2", "item3" };
    }
}
