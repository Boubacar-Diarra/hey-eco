using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Web.Models
{
    public class Offer
    {
        private readonly ILazyLoader _lazyLoader;
        public Offer(ILazyLoader lazyLoader) { _lazyLoader = lazyLoader; }

        public Offer() { }
        public long Id { get; set; }
        public string Author { get; set; }
        private List<Applicant> _applicants;

        public List<Applicant> Applicants
        {
            get => _lazyLoader.Load(this, ref _applicants);
            set => _applicants = value;
        }
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

    public class Applicant
    {
        private readonly ILazyLoader _lazyLoader;
        public Applicant() { }
        public Applicant(ILazyLoader lazyLoader) { _lazyLoader = lazyLoader; }
        
        public long Id { get; set; }
        private User _user;
        public User User
        {
            get => _lazyLoader.Load(this, ref _user);
            set => _user = value;
        }

        private Offer _offer;

        public Offer Offer
        {
            get => _lazyLoader.Load(this, ref _offer);
            set => _offer = value;
        }
        public bool IsAccepted { get; set; } = false;
        public DateTime DateOfRequest { get; set; }
    }
}