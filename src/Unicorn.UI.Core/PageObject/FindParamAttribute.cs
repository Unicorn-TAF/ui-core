using System;

namespace Unicorn.UI.Core.PageObject
{
    /// <summary>
    /// Provides with ability to specify parameter for substitution into locator template specified for control type
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class FindParamAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FindParamAttribute"/> class with specified parameter value
        /// </summary>
        /// <param name="locatorParam">locator template parameter value</param>
        public FindParamAttribute(string locatorParam)
        {
            LocatorParam = locatorParam;
        }

        /// <summary>
        /// Gets parameter value.
        /// </summary>
        public string LocatorParam
        {
            get;
        }
    }
}
