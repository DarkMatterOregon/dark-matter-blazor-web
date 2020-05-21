﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkMatterWeb.Models
{
    public class CrewMember
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string GithubUserName { get; set; }
        public string Specialities { get; set; }
        public string LinkedInURL { get; set; }

    }
}
