using System.ComponentModel.DataAnnotations;

namespace UserInfoApp.Model
{
   public class Passport : IValidatableObject
   {
         public int Id { get; set; }

         public string? Number { get; set; }

         public string? DateOfBirth { get; set; }

         public string? PlaceOfBirth { get; set; }

         public string? RegistrationAddress { get; set; }
        
         public string?  AddressOfResidence { get; set; }
       
         public int UserId { get; set; } 
         public User? User { get; set; }

         public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
    
             // TODO:
    
            return errors;
        }
   }
}