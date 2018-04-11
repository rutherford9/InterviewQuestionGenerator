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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        readonly List<int> questionsAsked = new List<int>();
        readonly List<int> namesPicked = new List<int>();
        Random randomNum = new Random();
        private int questionRandomNum;
        private int nameRandomNum;
        string connectionString = File.ReadAllText("connectString.txt");


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConn1 = new SqlConnection(connectionString);
            do
            {
                questionRandomNum = randomNum.Next(1, 51);
            } while (questionsAsked.Contains(questionRandomNum));
            questionsAsked.Add(questionRandomNum);
            if (questionsAsked.Count == 50)
            {
                questionsAsked.Clear();
            }
            do
            {
                nameRandomNum = randomNum.Next(1, 29);
            } while (namesPicked.Contains(nameRandomNum));
            namesPicked.Add(nameRandomNum);
            if (namesPicked.Count == 28)
            {
                namesPicked.Clear();
            }
            string selectSql1 = $"Select [Question] From [QuestionNameGenerator].[dbo].[ProgramQuestions] Where {questionRandomNum} = [QuestionID]";
            string selectSql2 = $"SELECT [StudentName] FROM [QuestionNameGenerator].[dbo].[ProgramNames] Where {nameRandomNum} = [StudentID]";
            SqlCommand cmd1 = new SqlCommand(selectSql1);
            sqlConn1.Open();
            cmd1.Connection = sqlConn1;
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                while (reader.Read())
                {
                    questionBox.Text = (reader["Question"].ToString());
                }
            }

            SqlCommand cmd2 = new SqlCommand(selectSql2);
            cmd2.Connection = sqlConn1;
            using (SqlDataReader read = cmd2.ExecuteReader())
            {
                while (read.Read())
                {
                    nameBox.Text = (read["StudentName"].ToString());
                }
            }
        }
    }
}
