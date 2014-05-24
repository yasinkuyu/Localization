using System;
using System.ComponentModel;

namespace Insya.Localization.Attributes
{
    /// <summary>
    /// Localized <see cref="DescriptionAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class DescriptionLocalizeAttribute : DescriptionAttribute
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptionLocalizeAttribute"/> class.
        /// </summary>
        /// <param name="description">The description text.</param>
        public DescriptionLocalizeAttribute(string description) : base(description)
        {
        }
        #endregion Initialization

        #region Overrides
        /// <summary>
        /// Gets the description stored in this attribute.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The description stored in this attribute.
        /// </returns>
        public override string Description
        {
            get
            {
                // Return the localized version of the given value.
                var str = Localization.Localize(base.Description);
                return str ?? base.Description;
            }
        }
        #endregion Overrides
    }
}
