using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Data
{
    class City
    {
        public City(string name,string description,double latitude,double longitude)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
            Pois = new HashSet<Poi>();
        }
        public Guid Id { get; private set; }
        [Required]
        [StringLength(100,MinimumLength=50)]
        public string Name{ get;private set;}
        [Required]
        [StringLength(150)]
        public string Description { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public virtual ICollection<Poi> Pois { get; private set; }
    }
}
