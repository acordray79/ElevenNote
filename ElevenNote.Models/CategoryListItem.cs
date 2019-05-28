using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryListItem
    {
        public int CatID { get; set; }
        [Display(Name = "Category")]
        public string CatName { get; set; }
        public override string ToString() => CatName;
    }
}
