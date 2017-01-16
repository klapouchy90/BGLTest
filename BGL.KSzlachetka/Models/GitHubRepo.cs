using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BGL.KSzlachetka.Models
{
    public class GitHubRepo
    {
        [Display(Name = "Repository ID")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Stargazers")]
        public int StargazersCount { get; set; }
    }
}