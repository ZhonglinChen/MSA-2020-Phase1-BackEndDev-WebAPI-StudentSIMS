using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MSA_StudentSIMS.Models
{
    public class Address
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int addressId { get; set; }

        [ForeignKey("Student")]
        public int studentId { get; set; }

        public int streetNumber   { get; set; }

        public string street { get; set; }

        public string city { get; set; }

        public int postcode { get; set; }
        
        public string country { get; set; }
    }
}
