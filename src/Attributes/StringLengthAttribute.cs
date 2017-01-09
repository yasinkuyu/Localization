// @yasinkuyu
// 05/08/2014

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Insya.Localization.Attributes
{
    /// <summary>
    /// Localized <see cref="ValidationAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class StringLengthLocalizeAttribute : ValidationAttribute
    {
        /// <summary>
        /// The allowed string maximum length.
        /// </summary>
        public int MaximumLength
        {
            get;
            private set;
        }

        /// <summary>
        /// The allowed string minimum length.
        /// </summary>
        public int MinimumLength
        {
            get;
            private set;
        }

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="StringLengthLocalizeAttribute"/> class.
        /// </summary>
        /// <param name="maximumLength">The allowed string maximum length.</param>
        public StringLengthLocalizeAttribute(int maximumLength) : this("stringLength", maximumLength)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringLengthLocalizeAttribute"/> class.
        /// </summary>
        /// <param name="id">The text id.</param>
        /// <param name="maximumLength">The allowed string maximum length.</param>
        public StringLengthLocalizeAttribute(string id, int maximumLength) : this(id, maximumLength, 0)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="StringLengthLocalizeAttribute"/> class.
        /// </summary>
        /// <param name="minimumLength">The allowed string minimum length.</param>
        /// <param name="maximumLength">The allowed string maximum length.</param>
        public StringLengthLocalizeAttribute(int maximumLength, int minimumLength) : this("stringLength", maximumLength, minimumLength)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringLengthLocalizeAttribute"/> class.
        /// </summary>
        /// <param name="id">The text id.</param>
        /// <param name="minimumLength">The allowed string minimum length.</param>
        /// <param name="maximumLength">The allowed string maximum length.</param>
        public StringLengthLocalizeAttribute(string id, int maximumLength, int minimumLength) : base(new Func<string>(() => Localization.Localize(id))) 
        {
            MaximumLength = maximumLength;
            MinimumLength = minimumLength;
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
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, MaximumLength, MinimumLength);
        }

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            string text = (string)value;
            if (MaximumLength < 0)
            {
                throw new InvalidOperationException("The maximum length must be a nonnegative integer.");
            }
            if (MinimumLength > MaximumLength)
            {
                throw new InvalidOperationException(string.Format("The maximum value '{0}' must be greater than or equal to the minimum value '{1}'.", MaximumLength, MinimumLength));
            }
            int length = text.Length;
            return length <= MaximumLength && length >= MinimumLength;
        }
        #endregion Overrides
    }
}
