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
using System.Data.SqlClient;
using System.IO;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// On Button_Click, call GetNewStudentAndQuestion() and then assigned strings returned
        /// to the TextBox.Text properties.  Again, I have having trouble doing this inside Table.cs
        /// So I opted to return the string[] as a work around.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var table1 = new Table();
            string[] results = table1.GetNewStudentAndQuestion();
            questionBox.Text = results[0];
            nameBox.Text = results[1];

        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            //TODO: Add methods to add questions and/or names to database
        }
    }
}
