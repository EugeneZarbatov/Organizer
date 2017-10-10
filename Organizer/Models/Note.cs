using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Organizer.Models
{
    /// <summary>
    /// Класс записи ежедневника.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        /// <summary>
        /// Тип записи.
        /// </summary>
        [Required]
        [Display(Name = "Тип")]
        public string Type { get; set; }
        /// <summary>
        /// Тема.
        /// </summary>
        [Required]
        [Display(Name = "Тема")]
        public string Subject { get; set; }
        /// <summary>
        /// Дата и время начала.
        /// </summary>
        [Required]
        [Display(Name = "Дата и время начала")]
        public DateTime BeginDateTime { get; set; }
        /// <summary>
        /// Дата и время окончания.
        /// </summary>
        [Display(Name = "Дата и время окончания")]
        public DateTime? EndDateTime { get; set; }
        /// <summary>
        /// Место.
        /// </summary>
        [Display(Name = "Место")]
        public string Place { get; set; }
        /// <summary>
        /// Статус события - выполнено/не выполнено. По умолчанию: false.
        /// </summary>
        public bool State { get; set; } = false;
    }
}