﻿namespace RecruitYourselfApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Event
    {
        private ICollection<Volunteer> participants;

        public Event()
        {
            this.participants = new List<Volunteer>();
        }

        public int Id { get; set; }
        
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
        
        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }
        
        public string CreatorId { get; set; }
        
        //[ForeignKey("InitiatorId")]
        //public virtual Organization Initiator { get; set; }
        
        //public string InitiatorId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual ICollection<Volunteer> Participants
        {
            get { return this.participants; }
            set { this.participants = value; }
        }
    }
}