using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ODataV4Service.Models
{ 

    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? AnotherDate { get; set; }
        public int CreditLimit { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CustomerId1 { get; set; }


        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; } 
    }

    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public string LastName { get; set; } 
        //public string Email { get; set; }
        //public Gender Gender { get; set; }
        //public DateTime? RegistrationDate { get; set; }

        [JsonIgnore]
        public List<Book> CustomerBooks { get; set; }

        //public override string ToString()
        //{
        //    return $"new Customer() {{ " +
        //        $"Email = \"{Email}\", " +
        //        $"Gender = ({typeof(Gender).Name}){Convert.ToInt32(Gender)}, " +
        //        $"Id = new Guid(\"{Id}\"), " +
        //        $"LastName = \"{LastName}\", " +
        //        $"Name = \"{Name}\", " +
        //        $"RegistrationDate = new DateTime({RegistrationDate?.Ticks}) " +
        //        $"}}";
        //}
    }

    public enum Gender
    {        
        [Display(Name = "Male")]
        Male,
        
        [Display(Name = "Female")]
        Female,
        
    }
}
