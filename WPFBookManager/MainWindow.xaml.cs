using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFBookManager.Entities;

namespace WPFBookManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookDbContext dbContext;
        Book NewBook = new Book();

        /// <summary>
        /// MainWindow Constructor, Gets list of all books
        /// </summary>
        /// <param name="dbContext"></param>
        public MainWindow(BookDbContext dbContext)
        {
            // centers window
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.dbContext = dbContext;
            InitializeComponent();
            GetBooks();
            GetAuthors();

            AddNewBookGrid.DataContext = null;
        }

        /// <summary>
        /// Displays books in the DataGrid
        /// </summary>
        private void GetBooks()
        {
            BookDG.ItemsSource = dbContext.Books.ToList();

            // lista encji do combo boxa
            // comboTitle.ItemsSource = dbContext.Books.Select(x => x.Title).ToList();
        }

        private void GetAuthors()
        {
            comboAuthor.ItemsSource = dbContext.Authors.ToList().Select(x => x.Name);
            comboAuthorEdit.ItemsSource = comboAuthor.ItemsSource;
        }

        private void GetGenres()
        {

        }

        private void GetPublishers()
        {

        }

        /// <summary>
        /// Adds a book to the database
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void AddBook(object s, RoutedEventArgs e)
        {
            dbContext.Books.Add(NewBook);
            dbContext.SaveChanges();
            GetBooks();
            AddNewBookGrid.DataContext = null;
        }

        Book selectedBook = new Book();

        /// <summary>
        /// Fills edit fields according to selected book
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void UpdateBookForEdit(object s, RoutedEventArgs e)
        {
            selectedBook = (s as FrameworkElement).DataContext as Book;
            UpdateBookGrid.DataContext = selectedBook;
        }

        /// <summary>
        /// Updates selected book
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void UpdateBook(object s, RoutedEventArgs e)
        {
            dbContext.Update(selectedBook);
            dbContext.SaveChanges();
            GetBooks();
            UpdateBookGrid.DataContext = null;
        }

        /// <summary>
        /// Removes selected book from the database
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void RemoveBook(object s, RoutedEventArgs e)
        {
            Book selectedBook = (s as FrameworkElement).DataContext as Book;
            dbContext.Books.Remove(selectedBook);
            dbContext.SaveChanges();
            GetBooks();
        }

        /// <summary>
        /// Creates new window for adding new Author
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void addAuthorBtn_Click(object s, RoutedEventArgs e)
        {
            AddAuthorWindow AuthorWindow = new AddAuthorWindow(dbContext);
            AuthorWindow.ShowDialog();
            GetAuthors();
        }

        /// <summary>
        /// Creates new window for adding new Genre
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void addGenreBtn_Click(object s, RoutedEventArgs e)
        {
            AddGenreWindow GenreWindow = new AddGenreWindow();
            GenreWindow.ShowDialog();
        }

        /// <summary>
        /// Creates new window for adding new Publisher
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void addPublisherBtn_Click(object s, RoutedEventArgs e)
        {
            AddPublisherWindow PublisherWindow = new AddPublisherWindow();
            PublisherWindow.ShowDialog();
        }
    }
}
