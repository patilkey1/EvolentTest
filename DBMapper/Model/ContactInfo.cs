using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMapper.Model
{
    public class ContactInfo
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public bool isActive { get; set; }
    }
}
