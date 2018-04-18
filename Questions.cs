using System;
using System.Collections.Generic;

namespace WpfApp1
{
    public class Questions
    {
        private static int _questionRandomNum;
        private static readonly List<int> QuestionsAsked = new List<int>();

        internal static int GetBehaviorQuestion()
        {
            var randomQuestionNum = new Random();

            do
            {
                _questionRandomNum = randomQuestionNum.Next(1, 51);
            } while (QuestionsAsked.Contains(_questionRandomNum));

            QuestionsAsked.Add(_questionRandomNum);

            if (QuestionsAsked.Count == 50)
            { QuestionsAsked.Clear(); }

            return _questionRandomNum;
        }

        internal static int GetTechnicalQuestion()
        {
            //TODO: This will do the same as GetBehaviorQuestion except keep track of technical questions asked.
            throw new NotImplementedException();
        }

        internal static string AddQuestion()
        {
            //TODO: Add ability to add questions.  Don't forget to create the TextBlock to get user input
            throw new NotImplementedException();
        }
    }
}