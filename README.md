# WPFBookManager
WPFBookManager is a small WPF application for managing your favourite books. Program is based on *.NET Core 3.1* and utilizes *Entity Framework* and *SQLite* database.

![Screenshot](https://raw.githubusercontent.com/chwnk/WPFBookManager/main/Screenshot.png "WPFBookManager")

## Requirements
* Microsoft Visual Studio (*Latest recommended*)

## Project Structure
**View:**
* AddAuthorWindow.xaml - *Contains UI for Add Author window*
* AddAuthorWindow.xaml.cs - *Contains logic for Add Author window*
* AddGenreWindow.xaml - *Contains UI for Add Genre window*
* AddGenreWindow.xaml.cs - *Contains logic for Add Genre window*
* AddPublisherWindow.xaml - *Contains UI for Add Publisher window*
* AddPublisherWindow.xaml.cs - *Contains logic for Add Publisher window*
* App.xaml - *Contains UI for App*
* App.xaml.cs - *Contains logic for App*
* MainWindow.xaml - *Contains UI for Main window*
* MainWindow.xaml.cs - *Contains logic for Main window*
* AssemblyInfo.cs - *Contains logic for AssemblyInfo*
* BookDbContext.cs - *Contains logic for BookDbContext*

**Model:**
* Entities/Author.cs - *Contains Author table structure*
* Entities/Book.cs - *Contains Book table structure*
* Entities/Genre.cs - *Contains Genre table structure*
* Entities/Publisher.cs - *Contains Publisher table structure*

## Author
[Bartosz Chowaniak](https://github.com/chwnk)
