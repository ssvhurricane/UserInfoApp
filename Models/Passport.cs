using System;
using System.ComponentModel.DataAnnotations;

namespace UserInfoApp.Model
{
   public class Passport
   {
         public int Id { get; set; }

         public string? Number { get; set; }

         public string? DateOfBirth { get; set; }

         public string? PlaceOfBirth { get; set; }

         public string? RegistrationAddress { get; set; }
        
         public string?  AddressOfResidence { get; set; }
       
         public int UserId { get; set; } 
         public User? User { get; set; }
   }
}