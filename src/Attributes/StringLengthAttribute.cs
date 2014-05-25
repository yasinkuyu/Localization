// @yasinkuyu
// 05/08/2014

using System;
using System.ComponentModel.DataAnnotations;

namespace Insya.Localization.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class StringLengthLocalizeAttribute : ValidationAttribute
    {
        public int MaximumLength
        {
            get;
            private set;
        }
        public int MinimumLength
        {
            get;
            set;
        }
        public StringLengthLocalizeAttribute(int maximumLength) : base(new Func<string>(StringLengthLocalizeAttribute.GetDefaultErrorMessage))
        {
            this.MaximumLength = maximumLength;
        }
        private static string GetDefaultErrorMessage()
        {
            return Localization.Localize("stringLength");
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(base.ErrorMessageString, name, this.MaximumLength, this.MinimumLength);
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            string text = (string)value;
            int maximumLength = this.MaximumLength;
            int minimumLength = this.MinimumLength;
            if (maximumLength < 0)
            {
                throw new InvalidOperationException("The maximum length must be a nonnegative integer.");
            }
            if (minimumLength > maximumLength)
            {
                throw new InvalidOperationException(string.Format("The maximum value '{0}' must be greater than or equal to the minimum value '{1}'.", maximumLength, minimumLength));
            }
            int length = text.Length;
            return length <= maximumLength && length >= minimumLength;
        }
    }
}
