﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MSA_StudentSIMS.Models
{
    public class Student
    {
        // annotate studentId to be the unique identifier of the Model which maps
        // to the primary key of the database
        [Key]
        // DatabaseGenerated can be assigned so that a value of an attribute is automatically generated
        // in this case, the studentId. DatabaseGeneratedOption.Identity means the value will only be
        // generated once when the row is first created, and it cannot be updated
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentId { get; set; }
        // fisrtName is required when adding a Student to the database, and it will have 100 characters max
        [Required, MaxLength(100)]
        public string firstName { get; set; }
        public string middleName { get; set; }
        [Required]
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public int phoneNumber { get; set; }
        // assign Timestamp type to the timeCreated attribute
        [Timestamp]
        public DateTime timeCreated { get; set; }

        public ICollection<Address> addresses { get; set; }
    }
}
