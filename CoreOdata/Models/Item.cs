using System;
using System.Collections.Generic;

namespace CoreOdata.Models
{
    public class Item
    {
        public int Id { get; set; }
        public decimal RetailPrice { get; set; }
        public DateTimeOffset AquiredDate { get; set; }
        public string Description { get; set; }
        // Need a list of tags for grouping items. Ex: items that were Gifts etc.
        public ICollection<Note> Notes { get; set; }
    }
}
