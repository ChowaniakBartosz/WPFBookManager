using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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

        public AddAuthorWindow(BookDbContext dbContext)
        {
            this.dbContext = dbContext;
            // Centers window
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            AddNewAuthorGrid.DataContext = NewAuthor;
        }

        private void addAuthorBtn(object s, RoutedEventArgs e)
        {
            if (AuthorNameTextbox.Text != "")
            {
                // potrzebny dbcontext
                // dbcontext.authors.add();
                dbContext.Authors.Add(NewAuthor);
                // dbcontext.savechanges();
                dbContext.SaveChanges();
                // odswiezyc moze liste na mainwindow jak bedzie taka potrzeba
                // zamknac okno
                this.Close();
            }
            else
            {
                MessageBox.Show("Author's name cannot be empty!", "Enter author's name", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
