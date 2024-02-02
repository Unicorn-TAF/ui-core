using Unicorn.UI.Core.Driver;
using Unicorn.UI.Core.PageObject;

namespace Unicorn.UnitTests.FakeControls
{
    internal class UiContainer : UiControl
    {
        public const string ControlFieldClass = "ControlFieldClass";
        public const string ControlPropertyCss = "ControlPropertyCss";
        public const string TemplatedControlParam = "TemplatedControlParam";

        [Find(Using.Class, ControlFieldClass)]
        private readonly UiControl _controlField;

        [FindParam(ControlFieldClass)]
        private TemplatedCustomControl templatedCustomControlField;

        [Find(Using.WebCss, ControlPropertyCss)]
        public UiControl ControlProperty { get; set; }


        public CustomControl CustomControlProperty { get; set; }

        public UiControl GetUiControl() =>
            _controlField;

        public TemplatedCustomControl GetTemplatedCustomControl() =>
            templatedCustomControlField;
    }
}
