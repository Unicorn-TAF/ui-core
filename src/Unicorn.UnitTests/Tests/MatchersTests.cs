using Unicorn.Taf.Core.Testing.Attributes;
using Unicorn.Taf.Core.Verification;
using Unicorn.Taf.Core.Verification.Matchers;
using Unicorn.UnitTests.FakeControls;
using Ui = Unicorn.UI.Core.Matchers.UI;

namespace Unicorn.UnitTests.Tests
{
    [Suite]
    internal class MatchersTests
    {
        private HasTitleControl iHasTitle;
        private HasItemsControl iHasItems;

        [BeforeSuite]
        public void SetUp()
        {
            iHasTitle = new HasTitleControl();
            iHasItems = new HasItemsControl();
        }

        #region HasTitle

        [Test]
        public void HasTitleReverseTestNegative() =>
            Assert.Throws<AssertionException>(() => 
                Assert.That(iHasTitle, Is.Not(Ui.Control.HasTitle("some actual title"))));

        [Test]
        public void HasTitleTestPositive() =>
            Assert.That(iHasTitle, Ui.Control.HasTitle("some actual title"));

        [Test]
        public void HasTitleReverseTestPositive() =>
            Assert.That(iHasTitle, Is.Not(Ui.Control.HasTitle("sofe actual title")));

        [Test]
        public void HasTitleTestNegative() =>
            Assert.Throws<AssertionException>(() =>
                Assert.That(iHasTitle, Ui.Control.HasTitle("some atual title")));

        #endregion

        #region HasItems

        [Test]
        public void HasItemsReverseTestNegative() =>
            Assert.Throws<AssertionException>(() =>
                Assert.That(iHasItems, Is.Not(Ui.Control.HasExactlyItems("item1", "item2", "item3"))));

        [Test]
        public void HasItemsTestPositive() =>
            Assert.That(iHasItems, Ui.Control.HasExactlyItems("item1", "item2", "item3"));

        [Test]
        public void HasItemsTestNegative() =>
            Assert.Throws<AssertionException>(() =>
                Assert.That(iHasItems, Ui.Control.HasExactlyItems("item1", "item2")));

        [Test]
        public void HasItemsReverseTestPositive() =>
            Assert.That(iHasItems, Is.Not(Ui.Control.HasExactlyItems("item1", "item2")));

        #endregion

        #region ContainsItems

        [Test]
        public void ContainsItemsReverseTestNegative() =>
            Assert.Throws<AssertionException>(() =>
                Assert.That(iHasItems, Is.Not(Ui.Control.ContainsItems("item1", "item3"))));

        [Test]
        public void ContainsItemsTestPositive() =>
            Assert.That(iHasItems, Ui.Control.ContainsItems("item1", "item3"));

        [Test]
        public void ContainsItemsTestNegative() =>
            Assert.Throws<AssertionException>(() => 
                Assert.That(iHasItems, Ui.Control.ContainsItems("item4", "item5")));

        [Test]
        public void ContainsItemsReverseTestPositive() =>
                Assert.That(iHasItems, Is.Not(Ui.Control.ContainsItems("item4", "item5")));

        #endregion
    }
}
