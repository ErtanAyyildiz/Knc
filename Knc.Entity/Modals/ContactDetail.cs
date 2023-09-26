using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knc.Entity.Modals
{
    public class ContactDetail
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? CompanyName { get; set; }
        public string Adress { get; set; }
        public string? Note { get; set; }
    }
}
