using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFBookManager.Entities
{
    /// <summary>
    /// The main Publisher class.
    /// </summary>
    public class Publisher
    {
        /// <summary>
        /// Property of the Publisher class; Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property of the Publisher class; Contains string value with name of the publisher
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property of the Publisher class; Contains list of the books
        /// </summary>
        [NotMapped]
        public virtual List<Book> Books { get; set; }
    }
}
