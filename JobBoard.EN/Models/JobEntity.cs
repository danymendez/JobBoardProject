using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JobBoard.EN.Models
{
   public class JobEntity
    {
       
        [Key]
        public int JobId { get;set;}
        [Required]
        [MaxLength(50)]
        public string Job { get; set;}
        [Required]
        [MaxLength(50)]
        public string JobTitle { get;set;}
        [Required]
        [MaxLength(250)]
        public string Description { get; set;}
        public DateTime CreatedAt { get;set;}
        public DateTime? ExpiresAt { get; set; }
    }
}
