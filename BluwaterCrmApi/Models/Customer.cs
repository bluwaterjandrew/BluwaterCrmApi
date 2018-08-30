using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BluwaterCrmApi.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerGuid { get; set; }

        [Required, MaxLength(120)]
        public string FirstName { get; set; }
        [Required, MaxLength(240)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public DateTime Dob { get; set; }
        [Required, MaxLength(240)]
        public string EmailAddress { get; set; }
        public string JobTitle { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string MobilePhone { get; set; }
        public string ProfileImgUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public CustomerStatus Status { get; set; }

        public string OwnerId { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public List<Interaction> Interactions { get; set; }
        public List<Note> Notes { get; set; }
        public List<Deal> Deals { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedTimestamp { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedTimestamp { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum CustomerStatus
    {
        Lead,
        Prospect,
        Customer
    }

}
