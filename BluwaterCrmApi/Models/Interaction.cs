using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BluwaterCrmApi.Models
{
    public class Interaction
    {
        public int InteractionId { get; set; }
        public Guid InteractionGuid { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public InteractionStatus Status { get; set; }

        public string OwnerId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int DealId { get; set; }
        public Deal Deal { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedTimestamp { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedTimestamp { get; set; }
    }

    public enum InteractionStatus
    {
        New,
        Working,
        Complete
    }
}
