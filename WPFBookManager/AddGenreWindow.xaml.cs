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
    /// Interaction logic for AddGenreWindow.xaml
    /// </summary>
    public partial class AddGenreWindow : Window
    {
        BookDbContext dbContext;
        Genre NewGenre = new Genre();

        public AddGenreWindow(BookDbContext dbContext)
        {
            this.dbContext = dbContext;
            // Centers window
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();

            AddNewGenreGrid.DataContext = NewGenre;
        }

        private void addGenreBtn(object s, RoutedEventArgs e)
        {
            if (GenreNameTextbox.Text != "")
            {
                // potrzebny dbcontext
                // dbcontext.authors.add();
                dbContext.Genres.Add(NewGenre);
                // dbcontext.savechanges();
                dbContext.SaveChanges();
                // odswiezyc moze liste na mainwindow jak bedzie taka potrzeba
                // zamknac okno
                this.Close();
            }
            else
            {
                MessageBox.Show("Genre's name cannot be empty!", "Enter genre's name", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
