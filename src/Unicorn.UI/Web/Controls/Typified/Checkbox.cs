﻿using Unicorn.Core.Logging;
using Unicorn.UI.Core.Controls.Interfaces.Typified;

namespace Unicorn.UI.Web.Controls.Typified
{
    public class Checkbox : WebControl, ICheckbox
    {
        public bool Checked => this.Instance.Selected;

        public bool SetCheckState(bool isChecked)
        {
            return isChecked ? Check() : Uncheck();
        }

        private bool Check()
        {
            Logger.Instance.Log(LogLevel.Debug, $"Check {this.ToString()}");
            if (this.Checked)
            {
                Logger.Instance.Log(LogLevel.Trace, "\tNo need to check (checked by default)");
                return false;
            }

            this.Click();
            Logger.Instance.Log(LogLevel.Trace, "\tChecked");

            return true;
        }

        private bool Uncheck()
        {
            Logger.Instance.Log(LogLevel.Debug, $"Uncheck {this.ToString()}");
            if (!this.Checked)
            {
                Logger.Instance.Log(LogLevel.Trace, "\tNo need to uncheck (unchecked by default)");
                return false;
            }

            this.Click();
            Logger.Instance.Log(LogLevel.Trace, "\tUnchecked");

            return true;
        }
    }
}