using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BGL.KSzlachetka.Models
{
    public class GitHubUser
    {
        [Display(Name = "User ID")]
        public int Id { get; set; }

        [Display(Name = "Login")]
        public string Login { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Url]
        [Display(Name = "Gravatar")]
        public string AvatarUrl { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Url]
        [Display(Name = "Repositories URL")]
        public string ReposUrl { get; set; }

        [Display(Name = "Repositories")]
        public GitHubRepo[] Repos { get; set; }
    }
}