using System;
using System.Collections.Generic;

namespace WpfApp1
{
    public class Questions
    {
        private static int _questionRandomNum;
        private static readonly List<int> QuestionsAsked = new List<int>();

        public static int GetQuestion()
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
    }
}