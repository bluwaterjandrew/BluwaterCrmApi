using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BluwaterCrmApi.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public Guid NoteGuid { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public string OwnerId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedTimestamp { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedTimestamp { get; set; }
    }
}
