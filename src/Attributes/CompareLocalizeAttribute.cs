using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Insya.Localization.Attributes {

    /// <summary>
    /// Localized <see cref="CompareAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class CompareLocalizeAttribute : CompareAttribute 
    {
        /// <summary>
        /// The text id.
        /// </summary>
        private string Id { get; set; }

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="CompareLocalizeAttribute"/> class.
        /// </summary>
        /// <param name="otherProperty">The property to compare with the current property.</param>
        public CompareLocalizeAttribute(string otherProperty) : this(otherProperty, "compare") 
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompareLocalizeAttribute"/> class.
        /// </summary>
        /// <param name="otherProperty">The property to compare with the current property.</param>
        /// <param name="id">The text id.</param>
        public CompareLocalizeAttribute(string otherProperty, string id) : base(otherProperty)
        {
            Id = id;
        }
        #endregion Initialization

        #region Overrides
        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name of the field that caused the validation failure.</param>
        /// <returns>
        /// The formatted error message.
        /// </returns>
        public override string FormatErrorMessage(string name) 
        {
            return string.Format(CultureInfo.CurrentCulture, Localization.Localize(Id), name, OtherPropertyDisplayName ?? OtherProperty);
        }
        #endregion Overrides
    }
}
