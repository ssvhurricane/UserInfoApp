using System.ComponentModel.DataAnnotations;
using UserInfoApp.Constants;
using UserInfoApp.Service;

namespace UserInfoApp.Model
{

    public class User : IValidatableObject
    {
         public int Id { get; set; }

         [DataType(DataType.Text)]
         public string? FirstName { get; set; }

         [DataType(DataType.Text)]
         public string? PatronymicName { get; set; } 

         [DataType(DataType.Text)]
         public string? LastName { get; set; }
     
         [DataType(DataType.EmailAddress)]
         public string? EmailAddress { get; set; }

         [DataType(DataType.PhoneNumber)] 
         public string? PhoneNumber { get; set; }

         public Passport? Passport{ get; set; } = new();

         public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            var errors = new List<ValidationResult>();

            var validationService = validationContext.GetService<ValidationService>();
            if (validationService == null) return errors;

            var isValid = validationService.ValidateData(this);

            switch(ValidationServiceConstants.XDEVICE_MODE)
            {
                case Service.XDeviceMode.Default:
                {
                    if (!isValid) errors.Add(new ValidationResult("Заполните все поля!"));
                    break;
                }
                case Service.XDeviceMode.Web:
                {
                     if (!isValid) errors.Add(new ValidationResult("Все поля кроме почты и адреса проживания обязательные!"));
                    break;
                }
                case Service.XDeviceMode.Mail:
                {
                    if (!isValid) errors.Add(new ValidationResult("Имя и почта обязательные поля!"));
                    break;
                }
                 case Service.XDeviceMode.Mobile:
                {
                    if (!isValid) errors.Add(new ValidationResult("Телефон обязательные поле!"));
                    break;
                }
            }
    
            return errors;
        }
    }
}