using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryStorage.Models
{
    public class ItemHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Item name")]
        public string ItemName { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public int Location { get; set; }
        [Required]
        public int OldLocation { get; set; }
       [Required]
        public DateTime DateTimeWhenChanged { get; set; }
    }
}
