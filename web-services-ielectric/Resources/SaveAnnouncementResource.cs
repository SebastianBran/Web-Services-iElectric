using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Resources
{
    public class SaveAnnouncementResource
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string UrlToImage { get; set; }

        [Required]
        [Range(1, 2)]
        public int TypeOfAnnouncement { get; set; }

        [Required]
        public bool Visible { get; set; }
    }
}
