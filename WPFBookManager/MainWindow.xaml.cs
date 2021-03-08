using System;
using System.Linq;
using System.Windows;
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
        /// <param name="dbContext">Used to pass DbContext</param>
        public MainWindow(BookDbContext dbContext)
        {
            // centering window on start
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Assigning passed as an argument dbContext value
            this.dbContext = dbContext;

            // Rendering window
            InitializeComponent();

            // Loading list of books
            GetBooks();
            // Loading list of authors
            GetAuthors();
            // Loading list of publishers
            GetPublishers();
            // Loading list of genres
            GetGenres();

            // Binding book to the grid
            AddNewBookGrid.DataContext = NewBook;
        }

        /// <summary>
        /// Displays books in the DataGrid
        /// </summary>
        private void GetBooks()
        {
            // Displaying books in the datagrid
            BookDG.ItemsSource = dbContext.Books.ToList();
        }

        /// <summary>
        /// Loading list of authors
        /// </summary>
        private void GetAuthors()
        {
            var authors = dbContext.Authors.ToList();

            comboAuthor.ItemsSource = authors.Select(x => x.Name);
            comboAuthorEdit.ItemsSource = comboAuthor.ItemsSource;
        }

        /// <summary>
        /// Loading list of genres
        /// </summary>
        private void GetGenres()
        {
            var genres = dbContext.Genres.ToList();

            comboGenre.ItemsSource = genres.Select(x => x.Name);
            comboGenreEdit.ItemsSource = comboGenre.ItemsSource;
        }

        /// <summary>
        /// Loading list of publishers
        /// </summary>
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
            else if (!Int32.TryParse(TextBoxYear.Text, out int parsedYear))
            {
                MessageBox.Show("Year cannot be a string!", "Enter the year", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (TextBoxPages.Text == "")
            {
                MessageBox.Show("Enter the pages!", "Enter the pages", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (!Int32.TryParse(TextBoxPages.Text, out int parsedPages))
            {
                MessageBox.Show("Pages cannot be a string!", "Enter the pages", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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

                // Saving changes to the database
                dbContext.SaveChanges();

                // Loading list of books
                GetBooks();

                // Clearing value of NewBook
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

            // Binding selected book to the datagrid
            UpdateBookGrid.DataContext = selectedBook;

            // When update button is clicked, values in the combobox fiels in the edit form are changed
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
            // assigns values selected in edit form to the selected book
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
            else if (!Int32.TryParse(TextBoxYearEdit.Text, out int parsedYear))
            {
                MessageBox.Show("Year cannot be a string!", "Enter the year", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (TextBoxPagesEdit.Text == "")
            {
                MessageBox.Show("Enter the year!", "Enter the year", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (!Int32.TryParse(TextBoxPagesEdit.Text, out int parsedPages))
            {
                MessageBox.Show("Year cannot be a string!", "Enter the year", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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

            // Removing selected book from the database
            dbContext.Books.Remove(selectedBook);

            // Saving changes to the database
            dbContext.SaveChanges();

            // Loading list of books
            GetBooks();

            // Clearing inputs after removing books
            UpdateBookGrid.DataContext = null;
        }

        /// <summary>
        /// Creates new window for adding new Author
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void addAuthorBtn_Click(object s, RoutedEventArgs e)
        {
            // Opening separate window
            AddAuthorWindow AuthorWindow = new AddAuthorWindow(dbContext);
            AuthorWindow.ShowDialog();

            // Loading list of authors
            GetAuthors();
        }

        /// <summary>
        /// Creates new window for adding new Genre
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void addGenreBtn_Click(object s, RoutedEventArgs e)
        {
            // Opening separate window
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
            // Opening separate window
            AddPublisherWindow PublisherWindow = new AddPublisherWindow(dbContext);
            PublisherWindow.ShowDialog();
            GetPublishers();
        }
    }
}
