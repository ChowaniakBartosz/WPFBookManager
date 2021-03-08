using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFBookManager.Entities
{
    /// <summary>
    /// The main Author class
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Property of the Author class; Primary Key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Property of the Author class; Contains string value with name of the author
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property of the Author class; Contains list of the books
        /// </summary>
        [NotMapped]
        public virtual List<Book> Books { get; set; }
    }
}
