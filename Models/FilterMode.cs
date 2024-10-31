using System.ComponentModel.DataAnnotations;

namespace UserInfoApp.Model
{
    public enum FilterMode
    {
        [Display(Name = "Имя")]
        FirstName,

        [Display(Name = "Отчество")]
        PatronymicName,

        [Display(Name = "Фамилия")]
        LastName,

        [Display(Name = "Почта")]
        EmailAddress,

        [Display(Name = "Телефон")]
        PhoneNumber
    }
}