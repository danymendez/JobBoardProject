using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.EN.Models
{
   public class JobEntity
    {
        public int JobId { get;set;}
        public string Job { get; set;}
        public string JobTitle { get;set;}
        public string Description { get; set;}
        public DateTime CreatedAt { get;set;}
        public DateTime? ExpiresAt { get; set; }
    }
}
