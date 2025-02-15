﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAPItwe.Entities
{
    [Table("Member")]

    public partial class Member
    {
        public Member()
        {
            MemberSessions = new HashSet<MemberSession>();
            Sessions = new HashSet<Session>();
        }

        public string Id { get; set; }
        public string Fullname { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public string Facebook { get; set; }
        public string Birthday { get; set; }
        public string MajorId { get; set; }
        public string Grade { get; set; }
        public string Description { get; set; }
        public Boolean Status { get; set; }

        public virtual Major Major { get; set; }
        public virtual ICollection<MemberSession> MemberSessions { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
