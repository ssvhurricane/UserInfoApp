using System.ComponentModel.DataAnnotations;

namespace UserInfoApp.Model
{
   public class Passport
   {
         public int Id { get; set; }

         public string? Number { get; set; }

         [DataType(DataType.Text)]
         [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
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