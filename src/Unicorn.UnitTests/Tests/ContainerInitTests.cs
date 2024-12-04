using Unicorn.Taf.Core.Testing.Attributes;
using Unicorn.Taf.Core.Verification;
using Unicorn.Taf.Core.Verification.Matchers;
using Unicorn.UI.Core.Driver;
using Unicorn.UI.Core.PageObject;
using Unicorn.UnitTests.FakeControls;

namespace Unicorn.UnitTests.Tests
{
    [Suite]
    internal class ContainerInitTests
    {
        private UiContainer container;

        [BeforeSuite]
        public void SetUp()
        {
            container = new UiContainer();
            ContainerFactory.InitContainer(container);
        }

        [Test]
        public void PageObjectFieldInit()
        {
            UiControl control = container.GetUiControl();
            Assert.That(control.Locator.How, Is.EqualTo(Using.Class));
            Assert.That(control.Locator.Locator, Is.EqualTo(UiContainer.ControlFieldClass));
        }

        [Test]
        public void PageObjectPropertyInit()
        {
            UiControl control = container.ControlProperty;
            Assert.That(control.Locator.How, Is.EqualTo(Using.WebCss));
            Assert.That(control.Locator.Locator, Is.EqualTo(UiContainer.ControlPropertyCss));
        }

        [Test]
        public void PageObjectCustomControlPropertyInit()
        {
            UiControl control = container.CustomControlProperty;
            Assert.That(control.Locator.How, Is.EqualTo(Using.Id));
            Assert.That(control.Locator.Locator, Is.EqualTo(CustomControl.CustomControlId));
        }

        [Test]
        public void PageObjectTemplatedControlInit()
        {
            UiControl control = container.GetTemplatedCustomControl();
            Assert.That(control.Locator.How, Is.EqualTo(Using.WebXpath));

            string expectedLocator = string.Format(TemplatedCustomControl.TemplatedCustomControlXpath, 
                UiContainer.ControlFieldClass);

            Assert.That(control.Locator.Locator, Is.EqualTo(expectedLocator));
        }
    }
}
