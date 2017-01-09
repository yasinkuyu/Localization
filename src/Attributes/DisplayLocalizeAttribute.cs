// @yasinkuyu
// 05/08/2014

using System;
using System.ComponentModel;

namespace Insya.Localization.Attributes
{
    /// <summary>
    /// Localized <see cref="DisplayNameAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event)]
    public sealed class DisplayLocalizeAttribute : DisplayNameAttribute
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayLocalizeAttribute"/> class.
        /// </summary>
        /// <param name="id">The text id.</param>
        public DisplayLocalizeAttribute(string id) : base(id)
        {
        }
        #endregion Initialization

        #region Overrides
        /// <summary>
        /// Gets the display name for a property, event, or public void method that takes no arguments stored in this attribute.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The display name.
        /// </returns>
        public override string DisplayName
        {
            get
            {
                return Localization.Localize(base.DisplayName) ?? base.DisplayName;
            }
        }
        #endregion Overrides
    }

}
