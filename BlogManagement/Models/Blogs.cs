using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string FileName { get; set; }
    }
}
