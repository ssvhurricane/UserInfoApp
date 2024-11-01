using System.ComponentModel.DataAnnotations;

namespace UserInfoApp.Model
{
   public class Passport
   {
         public int Id { get; set; }

         [DataType(DataType.Text)]
         [RegularExpression(@"^\d{4}\s\d{6}$", ErrorMessage = "Неправильный формат серия и номера паспорта! (например, 1111 222222)")]
         public string? Number { get; set; }

         [DataType(DataType.Text)]
         [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$", ErrorMessage = "Неправильный формат даты! (например, 11.11.1999)")]
         public string? DateOfBirth { get; set; }

         [DataType(DataType.Text)]
         public string? PlaceOfBirth { get; set; }

         [DataType(DataType.Text)]
         public string? RegistrationAddress { get; set; }
         
         [DataType(DataType.Text)]
         public string? AddressOfResidence { get; set; }
       
         public int UserId { get; set; } 
         public User? User { get; set; }
   }
}