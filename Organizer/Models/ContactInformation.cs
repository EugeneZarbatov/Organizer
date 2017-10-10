using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Organizer.Models
{
    /// <summary>
    /// Класс контактной информации.
    /// </summary>
    public class ContactInformation
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        /// <summary>
        /// Номер телефона.
        /// </summary>
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        [Display(Name = "Email")]
        public string Email { get; set; }
        /// <summary>
        /// Аккаунт в Skype.
        /// </summary>
        [Display(Name = "Skype")]
        public string Skype { get; set; }
        /// <summary>
        /// Другая ифнормация.
        /// </summary>
        [Display(Name = "Другое")]
        public string OtherInfo { get; set; }

        /// <summary>
        /// Навигационное поле.
        /// </summary>
        public Contact Contact { get; set; }
        /// <summary>
        /// Идентификатор контакта.
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public ContactInformation() { }
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона.</param>
        /// <param name="email">Адрес электронной почты.</param>
        /// <param name="skype">Аккаунт в Skype.</param>
        /// <param name="otherInfo">Другая ифнормация.</param>
        /// <param name="contactId">Идентификатор контакта.</param>
        public ContactInformation(string phoneNumber, string email, string skype, string otherInfo, int contactId)
        {
            PhoneNumber = phoneNumber;
            Email = email;
            Skype = skype;
            OtherInfo = otherInfo;
            ContactId = contactId;
        }
    }
}