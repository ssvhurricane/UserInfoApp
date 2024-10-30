using System;

namespace UserInfoApp.Model
{
   public class Passport
   {
         public int Id { get; set; }

         public string? Number { get; set; }

         public DateTime? DateOfBirth { get; set; }

         public string? PlaceOfBirth { get; set; }

         public string? RegistrationAddress { get; set; }

         public string?  AddressOfResidence { get; set; }
   }
}