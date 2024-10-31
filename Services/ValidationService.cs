using UserInfoApp.Constants;
using UserInfoApp.Model;

namespace UserInfoApp.Service
{
    public class ValidationService
    {
        public void SendHeader(HttpContext context)
        {
            if(!context.Response.Headers.ContainsKey(ValidationServiceConstants.XDEVICEKEY))
                 context.Response.Headers.Add(ValidationServiceConstants.XDEVICEKEY,
                                              ValidationServiceConstants.XDEVICE_MODE.ToString());
        }

        public bool ValidateData(User user)
        {
            switch(ValidationServiceConstants.XDEVICE_MODE)
            {   
                case XDeviceMode.Default: return DefaultCalcFunc(user);;
                case XDeviceMode.Web: return WebCalcFunc(user);
                case XDeviceMode.Mobile: return MobileCalcFunc(user);
                case XDeviceMode.Mail: return MailCalcFunc(user);
                default: return false;
            }
        }

        private bool DefaultCalcFunc(User user)
        {
            if(user != null 
                && !string.IsNullOrEmpty(user.LastName)
                && !string.IsNullOrEmpty(user.FirstName)
                && !string.IsNullOrEmpty(user.PatronymicName)
                && !string.IsNullOrEmpty(user.EmailAddress)
                && !string.IsNullOrEmpty(user.PhoneNumber)
                && !string.IsNullOrEmpty(user.Passport?.Number)
                && !string.IsNullOrEmpty(user.Passport?.DateOfBirth)
                && !string.IsNullOrEmpty(user.Passport?.PlaceOfBirth)
                && !string.IsNullOrEmpty(user.Passport?.RegistrationAddress)
                && !string.IsNullOrEmpty(user.Passport?.AddressOfResidence)) return true;
           
            return false;
        }

        private bool MailCalcFunc(User user)
        {
             if(user != null 
                && !string.IsNullOrEmpty(user.FirstName)
                && !string.IsNullOrEmpty(user.EmailAddress)) return true;
          
            return false;
        }

        private bool MobileCalcFunc(User user)
        {
            if(user != null && !string.IsNullOrEmpty(user.PhoneNumber)) return true;
           
            return false;
        }

        private bool WebCalcFunc(User user)
        {
            if(user != null 
                && !string.IsNullOrEmpty(user.LastName)
                && !string.IsNullOrEmpty(user.FirstName)
                && !string.IsNullOrEmpty(user.PatronymicName)
                
                && !string.IsNullOrEmpty(user.PhoneNumber)
                && !string.IsNullOrEmpty(user.Passport?.Number)
                && !string.IsNullOrEmpty(user.Passport?.DateOfBirth)
                && !string.IsNullOrEmpty(user.Passport?.PlaceOfBirth)
                && !string.IsNullOrEmpty(user.Passport?.RegistrationAddress))return true;
            
            return true;
        }
    }
}