﻿using System;
using System.Windows;
using System.Windows.Automation;
using Unicorn.UI.Core.Driver;
using Unicorn.UI.Core.Controls;
using Unicorn.UI.Desktop.Driver;
using Unicorn.UI.Desktop.Input;

namespace Unicorn.UI.Desktop.Controls
{
    public abstract class GuiControl : GuiSearchContext, IControl
    {
        public ByLocator Locator { get; set; }

        public bool Cached = true;

        public virtual string ClassName { get { return null; } }

        public abstract ControlType Type { get; }


        protected override AutomationElement SearchContext
        {
            get
            {
                if (!Cached)
                    base.SearchContext = GetNativeControlFromParentContext(Locator, GetType());

                return base.SearchContext;
            }

            set
            {
                base.SearchContext = value;
            }
        }

        public virtual AutomationElement Instance
        {
            get
            {
                return SearchContext;
            }
            set
            {
                SearchContext = value;
            }
        }


        public string Text
        {
            get
            {
                var name = (string)Instance.GetCurrentPropertyValue(AutomationElement.NameProperty);
                return !string.IsNullOrEmpty(name) ? name : (string)Instance.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty);
            }
        }

        public bool Enabled
        {
            get
            {
                return (bool)Instance.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty);
            }
        }

        public bool Visible
        {
            get
            {
                bool isVisible;
                try
                {
                    isVisible = !Instance.Current.IsOffscreen;
                }
                catch (ElementNotAvailableException)
                {
                    isVisible = false;
                }
                return isVisible;
            }
        }

        public System.Drawing.Point Location
        {
            get
            {
                return new System.Drawing.Point(BoundingRectangle.Location.X, BoundingRectangle.Location.Y);
            }
        }

        public System.Drawing.Rectangle BoundingRectangle
        {
            get
            {
                return (System.Drawing.Rectangle)Instance.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty);
            }
        }



        public GuiControl() { }

        public GuiControl(AutomationElement instance)
        {
            Instance = instance;
        }



        public string GetAttribute(string attribute)
        {
            AutomationProperty ap;

            switch (attribute.ToLower())
            {
                case "class":
                    ap = AutomationElement.ClassNameProperty; break;
                case "text":
                    ap = AutomationElement.NameProperty; break;
                case "enabled":
                    return Enabled.ToString();
                case "visible":
                    return Visible.ToString();
                default:
                    throw new ArgumentException($"No such property as {attribute}");
            }

            return (string)Instance.GetCurrentPropertyValue(ap);
        }


        public void Click()
        {
            this.WaitForEnabled();

            object pattern = null;

            try
            {
                if (Instance.TryGetCurrentPattern(InvokePattern.Pattern, out pattern))
                    ((InvokePattern)pattern).Invoke();
                else
                    ((TogglePattern)Instance.GetCurrentPattern(TogglePattern.Pattern)).Toggle();
            }
            catch
            {
                MouseClick();
            }
        }


        private void MouseClick()
        {
            Instance.SetFocus();
            Point point;
            if (!Instance.TryGetClickablePoint(out point))
            {
                Point pt = new Point(3, 3);
                var rect = (Rect)Instance.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty);
                point = rect.TopLeft;
                point.Offset(pt.X, pt.Y);
            }
            Mouse.Instance.Click(point);
        }


        public void RightClick()
        {
            Instance.SetFocus();

            Point point;
            if (!Instance.TryGetClickablePoint(out point))
            {
                Point pt = new Point(3, 3);
                var rect = (Rect)Instance.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty);
                point = rect.TopLeft;
                point.Offset(pt.X, pt.Y);
            }

            Mouse.Instance.RightClick(point);
        }


        public AutomationElement GetParent()
        {
            TreeWalker tWalker = TreeWalker.ControlViewWalker;
            return tWalker.GetParent(Instance);
        }

        #region "Helpers"

        protected T GetPattern<T>() where T : BasePattern
        {
            var pattern = (AutomationPattern)typeof(T).GetField("Pattern").GetValue(null);
            object patternObject;
            Instance.TryGetCurrentPattern(pattern, out patternObject);
            return (T)patternObject;
        }

        #endregion
    }
}
