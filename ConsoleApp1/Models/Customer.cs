using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }      //This allows null
        public string? Phone { get; set; }
        public string? Email { get; set; }    //This property was added later
        public ICollection<Order> Orders { get; set; }  //Navigation Property  i.e help internal link to the other class
    }
}
