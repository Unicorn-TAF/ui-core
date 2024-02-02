using Unicorn.UI.Core.Driver;
using Unicorn.UI.Core.PageObject;

namespace Unicorn.UnitTests.FakeControls
{
    [Find(Using.Id, CustomControlId)]
    internal class CustomControl : UiControl
    {
        public const string CustomControlId = "someId";
    }
}
