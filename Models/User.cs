using System.ComponentModel.DataAnnotations;

namespace UserInfoApp.Model
{
    public class User : IValidatableObject
    {
         public int Id { get; set; }

         public string? FirstName { get; set; }

         public string? PatronymicName { get; set; } 

         public string? LastName { get; set; }

         public string? EmailAddress { get; set; }

         public string? PhoneNumber { get; set; }

         public Passport? Passport{ get; set; } = new();

         public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
    
             // TODO:
    
            return errors;
        }
    }
}