using System.Collections.Generic;
using Unicorn.Taf.Core.Testing.Attributes;
using Unicorn.Taf.Core.Verification;
using Unicorn.UI.Core.Controls;
using Unicorn.UI.Core.Extensions;
using Unicorn.UnitTests.FakeControls;
using static Unicorn.Taf.Core.Verification.Matchers.Is;

namespace Unicorn.UnitTests.Tests
{
    [Suite]
    internal class ExtensionsTests
    {
        private List<ControlWithTextAndAttribute> controlsList;

        [BeforeSuite]
        public void SetUp()
        {
            controlsList = new List<ControlWithTextAndAttribute>
            {
                new ControlWithTextAndAttribute("string1"),
                new ControlWithTextAndAttribute("string2"),
                new ControlWithTextAndAttribute("string3"),
                new ControlWithTextAndAttribute(" string5 "),
                new ControlWithTextAndAttribute("text4"),
            };
        }

        [Test]
        public void TestThrowsGetByText() =>
            Assert.Throws<ControlNotFoundException>(() => controlsList.GetByText("string44"));

        [Test]
        public void TestGetByText() =>
            Assert.That(controlsList.GetByText("string3").Text, EqualTo("string3"));
        
        [Test]
        public void TestGetByTextTrimmed() =>
             Assert.That(controlsList.GetByText("string5").Text, EqualTo(" string5 "));

        [Test]
        public void TestAnyWithText() =>
            Assert.IsTrue(controlsList.AnyWithText("string3"));

        [Test]
        public void TestAnyWithTextTrimmed() =>
            Assert.IsTrue(controlsList.AnyWithText("string5"));

        [Test]
        public void TestNoAnyWithText() =>
            Assert.IsFalse(controlsList.AnyWithText("string2313"));

        [Test]
        public void TestThrowsGetByAttributeContains() =>
            Assert.Throws<ControlNotFoundException>(() => controlsList.GetByAttributeContains("class", "string334"));

        [Test]
        public void TestGetByAttributeContains() =>
            Assert.That(controlsList.GetByAttributeContains("class", "text4").GetAttribute("class"), EqualTo("text4"));

        [Test]
        public void TestAnyWithAttributeContains() =>
            Assert.IsTrue(controlsList.AnyWithAttributeContains("class", "string2"));

        [Test]
        public void TestNoAnyWithAttributeContains() =>
            Assert.IsFalse(controlsList.AnyWithAttributeContains("class", "string334"));
    }
}
