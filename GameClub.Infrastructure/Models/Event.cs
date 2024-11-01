using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClub.Infrastructure.Models
{
    [Table("Events")]
    public class Event
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("ClubId")]
        [Required]
        public int ClubId { get; set; }
        [Column("Title")]
        [Required]
        public string Title { get; set; }
        [Column("Description")]
        [Required]
        public string Description { get; set; }
        [Column("StartTime")]
        [Required]
        public DateTime StartTime { get; set; }
        [Column("EndTime")]
        [Required]
        public DateTime EndTime { get; set; }
        [Column("Created")]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
