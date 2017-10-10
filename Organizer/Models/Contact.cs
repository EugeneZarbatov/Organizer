using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Organizer.Models
{
    /// <summary>
    /// Класс контакта.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required]
        [Display(Name = "Фамилия")]
        public string FirstName { get; set; }
        /// <summary>
        /// Имя.
        /// </summary>
        [Required]
        [Display(Name = "Имя")]
        public string LastName { get; set; }
        /// <summary>
        /// Отчество.
        /// </summary>
        [Required]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Организация.
        /// </summary>
        [Display(Name = "Организация")]
        public string Organization { get; set; }
        /// <summary>
        /// Должность.
        /// </summary>
        [Display(Name = "Должность")]
        public string Position { get; set; }
        
        /// <summary>
        /// Контактная информация.
        /// </summary>
        public ICollection<ContactInformation> contactInformation { get; set; }
        public Contact()
        {
            contactInformation = new List<ContactInformation>();
        }
    }
}