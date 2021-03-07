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
using WPFBookManager.Data;

namespace WPFBookManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookDbContext dbContext;
        Book NewBook = new Book();

        public MainWindow(BookDbContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            GetBooks();

            AddNewBookGrid.DataContext = NewBook;
        }

        private void GetBooks()
        {
            BookDG.ItemsSource = dbContext.Books.ToList();
        }

        private void AddBook(object s, RoutedEventArgs e)
        {
            dbContext.Books.Add(NewBook);
            dbContext.SaveChanges();
            GetBooks();
            NewBook = new Book();
            AddNewBookGrid.DataContext = NewBook;
        }

        Book selectedBook = new Book();
        private void UpdateBookForEdit(object s, RoutedEventArgs e)
        {
            selectedBook = (s as FrameworkElement).DataContext as Book;
            UpdateBookGrid.DataContext = selectedBook;
        }

        private void UpdateBook(object s, RoutedEventArgs e)
        {
            dbContext.Update(selectedBook);
            dbContext.SaveChanges();
            GetBooks();
        }
    }
}
