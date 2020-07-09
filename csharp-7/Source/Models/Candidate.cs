using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("candidate")]
    public class Candidate
    {
        [ForeignKey("User")]
        [Required]
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Acceleration")]
        [Required]
        [Column("acceleration_id")]
        public int AccelerationId { get; set; }
        public Acceleration Acceleration { get; set; }

        [ForeignKey("Company")]
        [Required]
        [Column("company_id")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        [Column("status")]
        public int Status { get; set; }

        [Required]
        [Timestamp]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}