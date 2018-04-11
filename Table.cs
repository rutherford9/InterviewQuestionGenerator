using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace WpfApp1
{
    /// Table.cs is responsible for interacting with the SQL tables and getting the information.
    /// It will defer to the Questions.cs and Students.cs for handling of getting the new 
    /// student id's and question id's for the next question to be asked.  Those classes are also 
    /// responsible for keeping track of the students picked and questions asked.

    internal class Table
    {
        //TODO: encrypt and decrypt connectionString file.
        //Get connection string from txt file 
        private readonly string _connectionString = File.ReadAllText("connectString.txt");
        private string[] boxResults  = new string[2];

        public string[] GetNewStudentAndQuestion()
        {
            /*
             * TODO:  Create logic that checks to see whether the technical question of behavioral questionbox is checked
             * depending on which one the user has selected, then call the appropriate method.
             */


            //Create all the neccesary variables for getting data in the SQL DB.
            var sqlConn1 = new SqlConnection(_connectionString);
            //Get and track questions asked.
            var questionRandomNum = Questions.GetBehaviorQuestion();
            //Get and track students asked.
            var nameRandomNum = Students.GetStudent();
            string selectSql1 =
                $"Select [Question] From [QuestionNameGenerator].[dbo].[ProgramQuestions] Where {questionRandomNum} = [QuestionID]";
            string selectSql2 =
                $"SELECT [StudentName] FROM [QuestionNameGenerator].[dbo].[ProgramNames] Where {nameRandomNum} = [StudentID]";
            var cmd1 = new SqlCommand(selectSql1);
            sqlConn1.Open();
            cmd1.Connection = sqlConn1;

            //Get the next question from the DB.
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                while (reader.Read())
                {
                    boxResults[0] = (reader["Question"].ToString());
                }
            }

            //Get the next student from the DB.
            var cmd2 = new SqlCommand(selectSql2);
            cmd2.Connection = sqlConn1;

            using (SqlDataReader read = cmd2.ExecuteReader())
            {
                while (read.Read())
                {
                    boxResults[1] = (read["StudentName"].ToString());
                }

                // Return the string array to be assigned to the textboxes, tried to do that here but 
                // wasn't having any luck, the TextBox.Text properties wouldn't change when assigned here.
                return boxResults;
            }
        }
    }
}