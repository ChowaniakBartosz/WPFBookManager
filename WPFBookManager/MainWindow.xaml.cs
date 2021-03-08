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
            GetPublishers();
            GetGenres();

            AddNewBookGrid.DataContext = NewBook;

            // for testing only
            comboAuthorEdit.SelectedItem = dbContext.Authors.Where(y => y.Id == 0).Select(x => x.Name).ToString();
        }

        /// <summary>
        /// Displays books in the DataGrid
        /// </summary>
        private void GetBooks()
        {
            // there's probably a better way to do it, but i have to leave it as it is for now
            //var books = dbContext.Books.Select(x => new
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Author = dbContext.Authors.Where(y => y.Id == x.AuthorId).FirstOrDefault().Name,
            //    Publisher = dbContext.Publishers.Where(y => y.Id == x.PublisherId).FirstOrDefault().Name,
            //    Genre = dbContext.Genres.Where(y => y.Id == x.GenreId).FirstOrDefault().Name,
            //    Year = x.Year,
            //    Pages = x.Pages
            //})
            //.ToList();

            BookDG.ItemsSource = dbContext.Books.ToList();
        }

        private void GetAuthors()
        {
            var authors = dbContext.Authors.ToList();

            comboAuthor.ItemsSource = authors.Select(x => x.Name);
            comboAuthorEdit.ItemsSource = comboAuthor.ItemsSource;
        }

        private void GetGenres()
        {
            var genres = dbContext.Genres.ToList();

            comboGenre.ItemsSource = genres.Select(x => x.Name);
            comboGenreEdit.ItemsSource = comboGenre.ItemsSource;
        }

        private void GetPublishers()
        {
            var publishers = dbContext.Publishers.ToList();
            
            comboPublisher.ItemsSource = publishers.Select(x => x.Name);
            comboPublisherEdit.ItemsSource = comboPublisher.ItemsSource;
        }

        /// <summary>
        /// Adds a book to the database
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void AddBook(object s, RoutedEventArgs e)
        {

            // validating if there are any empty inputs
            if(TextBoxTitle.Text == "")
            {
                MessageBox.Show("Title cannot be empty!", "Insert title", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (comboAuthor.SelectedItem == null)
            {
                MessageBox.Show("Author cannot be empty!", "Choose the author", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (comboPublisher.SelectedItem == null)
            {
                MessageBox.Show("Publisher cannot be empty!", "Choose the publisher", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (comboGenre.SelectedItem == null)
            {
                MessageBox.Show("Genre cannot be empty!", "Choose the genre", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (TextBoxYear.Text == "")
            {
                MessageBox.Show("Year cannot be empty!", "Enter the year", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (TextBoxPages.Text == "")
            {
                MessageBox.Show("Enter the year!", "Enter the year", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                var author = dbContext.Authors.Where(x => x.Name == comboAuthor.SelectedItem.ToString()).FirstOrDefault();
                var publisher = dbContext.Publishers.Where(x => x.Name == comboPublisher.SelectedItem.ToString()).FirstOrDefault();
                var genre = dbContext.Genres.Where(x => x.Name == comboGenre.SelectedItem.ToString()).FirstOrDefault();

                NewBook.Author = author;
                NewBook.Publisher = publisher;
                NewBook.Genre = genre;

                dbContext.Books.Add(NewBook);
                dbContext.SaveChanges();
                GetBooks();
                //  AddNewBookGrid.DataContext = null;
                NewBook = new Book();
                AddNewBookGrid.DataContext = NewBook;
            }
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

            // add right combobox values !!!!!!!!!
            comboAuthorEdit.SelectedItem = selectedBook.Author.Name;
            comboPublisherEdit.SelectedItem = selectedBook.Publisher.Name;
            comboGenreEdit.SelectedItem = selectedBook.Genre.Name;
        }

        /// <summary>
        /// Updates selected book
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void UpdateBook(object s, RoutedEventArgs e)
        {
            // assigns values selected in edit form to the slected book
            var selectedAuthor = comboAuthorEdit.SelectedItem;
            var selectedPublisher = comboPublisherEdit.SelectedItem;
            var selectedGenre = comboGenreEdit.SelectedItem;

            if (TextBoxTitleEdit.Text == "")
            {
                MessageBox.Show("Title cannot be empty!", "Insert title", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (selectedAuthor == null)
            {
                MessageBox.Show("Author cannot be empty!", "Choose the author", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (selectedPublisher == null)
            {
                MessageBox.Show("Publisher cannot be empty!", "Choose the publisher", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (selectedGenre == null)
            {
                MessageBox.Show("Genre cannot be empty!", "Choose the genre", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (TextBoxYearEdit.Text == "")
            {
                MessageBox.Show("Year cannot be empty!", "Enter the year", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (TextBoxPagesEdit.Text == "")
            {
                MessageBox.Show("Enter the year!", "Enter the year", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                selectedBook.Author = dbContext.Authors.Where(x => x.Name == selectedAuthor).FirstOrDefault() as Author;
                selectedBook.Publisher = dbContext.Publishers.Where(x => x.Name == selectedPublisher).FirstOrDefault() as Publisher;
                selectedBook.Genre = dbContext.Genres.Where(x => x.Name == selectedGenre).FirstOrDefault() as Genre;

                dbContext.Update(selectedBook);
                dbContext.SaveChanges();
                GetBooks();

                // clears inputs in edit form
                UpdateBookGrid.DataContext = null;
            }
        }

        /// <summary>
        /// Removes selected book from the database
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void RemoveBook(object s, RoutedEventArgs e)
        {
            Book selectedBook = (s as FrameworkElement).DataContext as Book;

            //selectedBook = dbContext.Books.Where(x => x.Id == tmpSelectedBook.Id);

            dbContext.Books.Remove(selectedBook);
            dbContext.SaveChanges();
            GetBooks();
            UpdateBookGrid.DataContext = null;
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
            AddGenreWindow GenreWindow = new AddGenreWindow(dbContext);
            GenreWindow.ShowDialog();
            GetGenres();
        }

        /// <summary>
        /// Creates new window for adding new Publisher
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void addPublisherBtn_Click(object s, RoutedEventArgs e)
        {
            AddPublisherWindow PublisherWindow = new AddPublisherWindow(dbContext);
            PublisherWindow.ShowDialog();
            GetPublishers();
        }
    }
}
