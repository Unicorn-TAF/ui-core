using System;
using Unicorn.UI.Core.Driver;

namespace Unicorn.UI.Core.PageObject
{
    /// <summary>
    /// Provides with ability to specify search condition template for PageObject UI control
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class FindTemplateAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FindTemplateAttribute"/> class 
        /// with specified search method and locator template
        /// </summary>
        /// <param name="how">search method</param>
        /// <param name="locatorTemplate">locator template to search by</param>
        public FindTemplateAttribute(Using how, string locatorTemplate)
        {
            How = how;
            LocatorTemplate = locatorTemplate;
        }

        /// <summary>
        /// Gets search method.
        /// </summary>
        public Using How 
        { 
            get; 
        }

        /// <summary>
        /// Gets control locator template.
        /// </summary>
        public string LocatorTemplate
        {
            get;
        }
    }
}
