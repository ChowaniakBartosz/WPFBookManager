using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFBookManager.Entities
{
    /// <summary>
    /// The main Genre class
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Property of the Genre class; Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property of the Genre class; Contains string value with name of the genre
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property of the Genre class; Contains list of the books
        /// </summary>
        [NotMapped]
        public virtual List<Book> Books { get; set; }
    }
}
