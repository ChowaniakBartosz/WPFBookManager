using System.Windows;
using WPFBookManager.Entities;

namespace WPFBookManager
{
    /// <summary>
    /// Interaction logic for AddGenreWindow.xaml
    /// </summary>
    public partial class AddGenreWindow : Window
    {
        BookDbContext dbContext;
        Genre NewGenre = new Genre();

        /// <summary>
        /// AddGenreWindow Constructor
        /// </summary>
        /// <param name="dbContext">Used to pass DbContext</param>
        public AddGenreWindow(BookDbContext dbContext)
        {
            // Assigning passed as an argument dbContext value
            this.dbContext = dbContext;

            // Centering window
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Rendering window
            InitializeComponent();

            // Binding genre to the grid
            AddNewGenreGrid.DataContext = NewGenre;
        }

        /// <summary>
        /// Method that adds genre when the Add button is clicked
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void addGenreBtn(object s, RoutedEventArgs e)
        {
            // Checks if user entered anything
            if (GenreNameTextbox.Text != "")
            {
                // Adding new genre
                dbContext.Genres.Add(NewGenre);

                // Saving changes to the database
                dbContext.SaveChanges();

                // Closing dialog box
                this.Close();
            }
            else
            {
                // Displaying information that user didn't enter any text
                MessageBox.Show("Genre's name cannot be empty!", "Enter genre's name", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
