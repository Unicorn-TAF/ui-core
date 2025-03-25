using System;
using System.Collections.Generic;
using Unicorn.UI.Core.Driver;

namespace Unicorn.UnitTests.FakeControls
{
    internal class UiSearchContext : BaseSearchContext<UiSearchContext>
    {
        protected override Type ControlsBaseType { get; } = typeof(UiControl);

        protected override TimeSpan ImplicitWaitTimeout
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        protected override T GetFirstChildWrappedControl<T>()
        {
            throw new NotImplementedException();
        }

        protected override IList<T> GetWrappedControlsList<T>(ByLocator locator)
        {
            throw new NotImplementedException();
        }

        protected override T WaitForWrappedControl<T>(ByLocator locator)
        {
            throw new NotImplementedException();
        }
    }
}
