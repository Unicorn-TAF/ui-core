using Unicorn.UI.Core.Driver;
using Unicorn.UI.Core.PageObject;

namespace Unicorn.UnitTests.FakeControls
{
    [FindTemplate(Using.WebXpath, TemplatedCustomControlXpath)]
    internal class TemplatedCustomControl : UiControl
    {
        public const string TemplatedCustomControlXpath = ".//button[text() = '{0}']";
    }
}
