using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {
        [ForeignKey("User")]
        [Required]
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }
        
        [ForeignKey("Challenge")]
        [Required]
        [Column("challenge_id")]
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }
        
        [Required]
        [Column("score")]
        public decimal Score { get; set; }
        
        [Required]
        [Timestamp]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }   
}
