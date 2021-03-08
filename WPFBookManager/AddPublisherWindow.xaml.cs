using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFBookManager
{
    /// <summary>
    /// Interaction logic for AddPublisherWindow.xaml
    /// </summary>
    public partial class AddPublisherWindow : Window
    {
        BookDbContext dbContext;
        Entities.Publisher NewPublisher  = new Entities.Publisher();

        public AddPublisherWindow(BookDbContext dbContext)
        {
            this.dbContext = dbContext;

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();

            AddNewPublisherGrid.DataContext = NewPublisher;
        }

        private void addPublisherBtn(object s, RoutedEventArgs e)
        {
            if (PublisherNameTextbox.Text != "")
            {
                // dbcontext.authors.add();
                dbContext.Publishers.Add(NewPublisher);
                // dbcontext.savechanges();
                dbContext.SaveChanges();
                // zamknac okno
                this.Close();
            }
            else
            {
                MessageBox.Show("Publisher's name cannot be empty!", "Enter publisher's name", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
