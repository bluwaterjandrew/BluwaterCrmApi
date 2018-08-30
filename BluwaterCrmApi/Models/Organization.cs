using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BluwaterCrmApi.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public Guid OrganizationGuid { get; set; }

        [Required, MaxLength(240)]
        public string Name { get; set; }
        public string Website { get; set; }
        public string WorkPhone { get; set; }
        public string ProfileImgUrl { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; }

        public string OwnerId { get; set; }
        public int IndustryTagId { get; set; }
        public IndustryTag IndustryTag { get; set; }
        public List<Customer> Customers { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedTimestamp { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedTimestamp { get; set; }
    }
}
