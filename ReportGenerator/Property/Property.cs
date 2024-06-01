﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace ReserveSpot.Domain
{
    public class Property : AbstractEntity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
     
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ImageUrl is required")]
        [RegularExpression(@"(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|jpeg|gif|png)", ErrorMessage = "Please enter a valid image URL.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Type is required")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PropertyType Type { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "ContactPhone is required")]
        [RegularExpression(@"^(\+?3?8)?(0\d{9})$", ErrorMessage = "Invalid Ukrainian phone number")]
        public string ContactPhone { get; set; }

        [Required(ErrorMessage = "ContactName is required")]
        public string ContactName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "PricePerNight must be greater than 0")]
        public decimal PricePerNight { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
        public int Capacity { get; set; }

        [StartDateLessThanEndDate(ErrorMessage = "StartDate must be less than or equal to EndDate")]
        public DateTime StartDate { get; set; }

        [EndDateGreaterThanStartDate(ErrorMessage = "EndDate must be greater than or equal to StartDate")]
        public DateTime EndDate { get; set; }
        
        public bool IsArchived { get; set; } = false;

        [Required(ErrorMessage = "UserID is required")]
        public Guid UserID { get; set; }
               
        public static int PropetryCount;     

        public Property(string name, string description, PropertyType type, string location, string contactPhone, string contactName, decimal pricePerNight, int capacity, DateTime startDate, DateTime endDate, string imageUrl, Guid creatorID)
        {
            Name = name;
            Description = description;
            Type = type;
            Location = location;
            ContactPhone = contactPhone;
            ContactName = contactName;
            PricePerNight = pricePerNight;
            Capacity = capacity;
            StartDate = startDate;
            EndDate = endDate;
            ImageUrl = imageUrl;
            UserID = creatorID;      
        }  

       
    }

    public class PropertyDetails
    {
        public string? Name { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public string? Description { get; set; }
        public PropertyType? Type { get; set; }
        public string? Location { get; set; }
        public decimal? PricePerNight { get; set; }
        public int? Capacity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
