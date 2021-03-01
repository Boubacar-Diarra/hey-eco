using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public Sex Sex { get; set; } = Sex.M;
        [DataType(DataType.Text)]
        public string Biography { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string CvUrl { get; set; }
        public string Enterprise { get; set; }
        public string ProfessionalActivity { get; set; }
        public string ProfessionalActivityDomaine { get; set; }
        public bool IsSubscribed { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastSession { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        public List<AreasOfExpertise> AreasOfExpertise { get; set; } = new List<AreasOfExpertise>();
        public List<Offer> Offers { get; set; } = new List<Offer>();
        [NotMapped]
        public static readonly List<string> AreasOfExpertiseString = new List<string>
        {
            "Commerce",
            "Agriculture",
            "Peche",
            "Mine",
            "Marketing",
            "Finance",
            "ECommerce",
            "Informatique"
        };
    }

    public enum Sex { M, F }

    public enum AreasOfExpertiseEnum
    {
        Commerce,
        Agriculture,
        Peche,
        Mine,
        Marketing,
        Finance,
        ECommerce,
        Informatique
    }

    public class AreasOfExpertise
    {
        public long Id { get; set; }
        public AreasOfExpertiseEnum Areas { get; set; }
    }
}