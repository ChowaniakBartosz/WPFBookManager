using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFBookManager.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public virtual List<Book> Books { get; set; }
    }
}
