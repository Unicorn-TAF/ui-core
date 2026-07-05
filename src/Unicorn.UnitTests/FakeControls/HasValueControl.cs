using Unicorn.UI.Core.Controls.Interfaces;

namespace Unicorn.UnitTests.FakeControls
{
    class HasValueControl : IHasValue
    {
        public string Value => "some actual value";
    }
}
