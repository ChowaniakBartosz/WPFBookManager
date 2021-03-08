using System.Windows;

namespace WPFBookManager
{
    /// <summary>
    /// Interaction logic for AddPublisherWindow.xaml
    /// </summary>
    public partial class AddPublisherWindow : Window
    {
        BookDbContext dbContext;
        Entities.Publisher NewPublisher  = new Entities.Publisher();

        /// <summary>
        /// AddPublisherWindow constructor
        /// </summary>
        /// <param name="dbContext">Used to pass DbContext</param>
        public AddPublisherWindow(BookDbContext dbContext)
        {
            // Assigning passed as an argument dbContext value
            this.dbContext = dbContext;

            // Centering window
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Rendering window
            InitializeComponent();

            // Binding author to the grid
            AddNewPublisherGrid.DataContext = NewPublisher;
        }

        /// <summary>
        /// Method that adds publisher when the Add button is clicked
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void addPublisherBtn(object s, RoutedEventArgs e)
        {
            // Checks if user entered anything
            if (PublisherNameTextbox.Text != "")
            {
                // Adding new publisher
                dbContext.Publishers.Add(NewPublisher);

                // Saving changes to the database
                dbContext.SaveChanges();

                // Closing dialog box
                this.Close();
            }
            else
            {
                // Displaying information that user didn't enter any text
                MessageBox.Show("Publisher's name cannot be empty!", "Enter publisher's name", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
