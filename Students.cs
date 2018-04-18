using System;
using System.Collections.Generic;

namespace WpfApp1
{
    internal class Students
    {
        static readonly List<int> namesPicked = new List<int>();
        private static int nameRandomNum;

        public static int GetStudent()
        {
            var randomStudentNum = new Random();

            do
            {
                nameRandomNum = randomStudentNum.Next(1, 29);
            } while (namesPicked.Contains(nameRandomNum));

            namesPicked.Add(nameRandomNum);

            if (namesPicked.Count == 28)
            {
                namesPicked.Clear();
            }

            return nameRandomNum;
        }
    }
}