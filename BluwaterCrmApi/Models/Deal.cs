using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BluwaterCrmApi.Models
{
    public class Deal
    {
        public int DealId { get; set; }
        public Guid DealGuid { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DealStatus Status { get; set; }
        public double ApxValue { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedTimestamp { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedTimestamp { get; set; }

    }

    public enum DealStatus
    {
        Lead,
        Contacted,
        Connected,
        Proposal,
        Negotiation,
        Sale,
        Loss,
        Disqualified
    }
}
