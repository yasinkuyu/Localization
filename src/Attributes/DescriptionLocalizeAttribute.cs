// @yasinkuyu
// 05/08/2014

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
        /// <param name="id">The text id.</param>
        public DescriptionLocalizeAttribute(string id) : base(id)
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
                return Localization.Localize(base.Description) ?? base.Description;
            }
        }
        #endregion Overrides
    }
}
