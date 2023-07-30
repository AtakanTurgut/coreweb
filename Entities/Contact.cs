using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adınız Soyadınız"), Required, StringLength(50)]
        public string Name { get; set; }
        [EmailAddress, StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Telefon Numaranız"), StringLength(20)]
        public string? Phone { get; set; }
        [Display(Name = "Mesajınız"), StringLength(175)]
        public string Message { get; set; }
        [Display(Name = "Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }
    }
}
