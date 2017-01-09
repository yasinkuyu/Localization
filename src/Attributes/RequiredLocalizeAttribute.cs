// @yasinkuyu
// 05/08/2014

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Insya.Localization.Attributes
{
    /// <summary>
    /// Localized <see cref="RequiredAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequiredLocalizedAttribute : RequiredAttribute
    {
        /// <summary>
        /// The text id.
        /// </summary>
        private string Id { get; set; }

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredLocalizedAttribute"/> class.
        /// </summary>
        public RequiredLocalizedAttribute() : this("required")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredLocalizedAttribute"/> class.
        /// </summary>
        /// <param name="id">The text id.</param>
        public RequiredLocalizedAttribute(string id) 
        {
            Id = id;
        }
        #endregion Initialization

        #region Overrides
        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>An instance of the formatted error message.</returns>
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, Localization.Localize(Id), name);
        }
        #endregion Overrides
    }
}
