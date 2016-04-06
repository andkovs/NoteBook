using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoteBook.DAL
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        public String FirstName { get; set; }

        public String MiddleName { get; set; }

        public String LastName { get; set; }

        public int PositionId { get; set; }

        [ForeignKey("PositionId")]
        public Position Position { get; set; }

        public String Phone { get; set; }

        public String Email { get; set; }

        public String Skype { get; set; }

        public int StoreId { get; set; }

        [ForeignKey("StoreId")]
        public Store Store { get; set; }
    }

    public class Position
    {
        [Key]
        public int Id { get; set; }

        public String Name { get; set; }
    }

    public class Store
    {
        [Key]
        public int Id { get; set; }

        public String Title { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        public String Address { get; set; }

        public String Phone { get; set; }

        public String Email { get; set; }

        public String Skype { get; set; }       
    }

    public class City
    {
        [Key]
        public int Id { get; set; }

        public String Title { get; set; }
    }

    public class Company
    {
        [Key]
        public int Id { get; set; }

        public String Title { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        public String Address { get; set; }

        public String ContactName { get; set; }

        public String Phone { get; set; }

        public String Email { get; set; }

        public String Skype { get; set; }
    }
}