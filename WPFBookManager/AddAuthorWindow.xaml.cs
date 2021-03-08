using System.Windows;
using WPFBookManager.Entities;

namespace WPFBookManager
{
    /// <summary>
    /// Interaction logic for AddAuthorWindow.xaml
    /// </summary>
    public partial class AddAuthorWindow : Window
    {
        BookDbContext dbContext;
        Author NewAuthor = new Author();

        /// <summary>
        /// AddAuthorWindow Constructor
        /// </summary>
        /// <param name="dbContext">Used to pass DbContext</param>
        public AddAuthorWindow(BookDbContext dbContext)
        {
            // Assigning passed as an argument dbContext value
            this.dbContext = dbContext;

            // Centering window
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Rendering window
            InitializeComponent();

            // Binding author to the grid
            AddNewAuthorGrid.DataContext = NewAuthor;
        }

        /// <summary>
        /// Method that adds author when the Add button is clicked
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void addAuthorBtn(object s, RoutedEventArgs e)
        {
            // Checks if user entered anything
            if (AuthorNameTextbox.Text != "")
            {
                // Adding new author
                dbContext.Authors.Add(NewAuthor);

                // Saving changes to the database
                dbContext.SaveChanges();

                // Closing dialog box
                this.Close();
            }
            else
            {
                // Displaying information that user didn't enter any text
                MessageBox.Show("Author's name cannot be empty!", "Enter author's name", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
