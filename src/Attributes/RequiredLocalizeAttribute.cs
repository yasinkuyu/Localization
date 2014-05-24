using System.ComponentModel.DataAnnotations;

namespace Insya.Localization.Attributes
{
    public class RequiredLocalizedAttribute : RequiredAttribute
    {
        protected string FormatErrorMessage()
        {
            return Localization.Localize("required");
        }
    }
}
