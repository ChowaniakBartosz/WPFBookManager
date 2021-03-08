using System.ComponentModel.DataAnnotations.Schema;

namespace WPFBookManager.Entities
{
    /// <summary>
    /// The main Publisher class
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Property of the Book class; Primary Key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Property of the Book class; Contains string value with title of the book
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Property of the Book class; Contains year of publication
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Property of the Book class; Contains number of pages
        /// </summary>
        public int Pages { get; set; }

        /// <summary>
        /// Property of the Book class; Foreign Key
        /// </summary>
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        /// <summary>
        /// Virtual property of the Book class; Contains author
        /// </summary>
        public virtual Author Author { get; set; }

        /// <summary>
        /// Property of the Book class; Foreign Key
        /// </summary>
        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        /// <summary>
        /// Virtual property of the Book class; Contains genre
        /// </summary>
        public virtual Genre Genre { get; set; }

        /// <summary>
        /// Property of the Book class; Foreign Key
        /// </summary>
        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }

        /// <summary>
        /// Virtual property of the Book class; Contains publisher
        /// </summary>
        public virtual Publisher Publisher { get; set; }
    }
}
