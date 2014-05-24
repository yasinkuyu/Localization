using System;
using System.ComponentModel;

namespace Insya.Localization.Attributes
{
    /// <summary>
    /// Localized <see cref="DisplayNameAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class DisplayLocalizeAttribute : DisplayNameAttribute
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayLocalizeAttribute"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        public DisplayLocalizeAttribute(string displayName) : base(displayName)
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
                // Return the localized version of the given value.
                var str = Localization.Localize(base.DisplayName);
                return str ?? base.DisplayName;
            }
        }

        #endregion Overrides
    }

}
