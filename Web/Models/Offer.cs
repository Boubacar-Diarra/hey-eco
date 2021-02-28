using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Web.Models
{
    public class Offer
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public List<User> Applicants { get; set; } = new List<User>();
        public string TextContent { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl1 { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        
    }

    public enum Category
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
    public enum Type
    {
        JobOffer,
        Merchandise
    }
}