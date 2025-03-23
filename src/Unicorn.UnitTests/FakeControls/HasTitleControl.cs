using Unicorn.UI.Core.Controls.Interfaces;

namespace Unicorn.UnitTests.FakeControls
{
    class HasTitleControl : IHasTitle
    {

        public string Title => "some actual title";
    }
}
