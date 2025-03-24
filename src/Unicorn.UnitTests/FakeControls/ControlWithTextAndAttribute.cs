using System;
using System.Drawing;
using Unicorn.UI.Core.Controls;
using Unicorn.UI.Core.Driver;

namespace Unicorn.UnitTests.FakeControls
{
    public class ControlWithTextAndAttribute : IControl
    {
        private readonly string _text;

        public ControlWithTextAndAttribute(string text)
        {
            _text = text;
        }

        public bool Cached { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ByLocator Locator { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Visible => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public string Text => _text;

        public Point Location => throw new NotImplementedException();

        public Rectangle BoundingRectangle => throw new NotImplementedException();

        public void Click() =>
            throw new NotImplementedException();

        public string GetAttribute(string attribute) =>
            _text;

        public void RightClick() =>
            throw new NotImplementedException();
    }
}
