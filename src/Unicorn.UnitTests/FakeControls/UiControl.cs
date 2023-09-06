using System;
using System.Drawing;
using Unicorn.UI.Core.Controls;
using Unicorn.UI.Core.Driver;

namespace Unicorn.UnitTests.FakeControls
{
    internal class UiControl : UiSearchContext, IControl
    {
        public bool Cached { get; set; }

        public ByLocator Locator { get; set; }

        public string Name { get; set; }

        public bool Visible => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public string Text => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public Rectangle BoundingRectangle => throw new NotImplementedException();

        public void Click()
        {
            throw new NotImplementedException();
        }

        public string GetAttribute(string attribute)
        {
            throw new NotImplementedException();
        }

        public void RightClick()
        {
            throw new NotImplementedException();
        }
    }
}
