using TheCollectorApp.Models;

namespace TheCollectorApp
{
    public class ValidationServices
    {
        public class ValidationResult
        {
            public bool IsValid { get; set; } // Sann eller falsk om den lyckats validera
            public List<string> ValidationErrors { get; set; } = new List<string>(); // Alla felmeddelanden
        }

        public ValidationResult ValidateUser(User user)
        {
            var result = new ValidationResult { IsValid = true };

            // Kontroller om förnamn är null eller tom
            if (string.IsNullOrEmpty(user.FirstName))
                result.ValidationErrors.Add("Förnamn måste anges");

            // efternamn...
            if (string.IsNullOrEmpty(user.SecondName))
                result.ValidationErrors.Add("Efternamn måste anges");

            // användarnamn...
            if (string.IsNullOrEmpty(user.UserName))
                result.ValidationErrors.Add("Användarnamn måste anges");

            // lösenord...
            if (string.IsNullOrEmpty(user.Password))
                result.ValidationErrors.Add("Lösenord måste anges");

            // e-post...
            if (string.IsNullOrEmpty(user.Email))
                result.ValidationErrors.Add("E-post måste anges");

            if (result.ValidationErrors.Any()) // Sann om det finns fel, Falskt om listan är tom
                result.IsValid = false;

            return result;
        }
    }
}