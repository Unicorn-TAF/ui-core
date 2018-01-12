﻿using Unicorn.Core.Testing.Verification.Matchers;
using Unicorn.UI.Core.Controls;

namespace Unicorn.UI.Core.Matchers.IControlMatchers
{
    public class AttributeContainsMatcher : Matcher
    {
        private string attribute, value;

        public AttributeContainsMatcher(string attribute, string value)
        {
            this.attribute = attribute;
            this.value = value;
        }

        public override string CheckDescription => $"has attribute '{this.attribute}' contains '{this.value}'";

        public override bool Matches(object obj)
        {
            return IsNotNull(obj) && Assertion(obj);
        }

        protected bool Assertion(object obj)
        {
            IControl element = null;

            try
            {
                element = obj as IControl;
            }
            catch
            {
                DescribeMismatch("was not an instance of IControl");
                return !this.Reverse;
            }

            string actualValue = element.GetAttribute(this.attribute);
            DescribeMismatch($"having '{attribute}' = '{actualValue}'");

            return actualValue.Contains(this.value);
        }
    }
}