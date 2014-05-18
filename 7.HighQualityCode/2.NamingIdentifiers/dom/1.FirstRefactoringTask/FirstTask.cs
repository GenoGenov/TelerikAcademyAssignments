namespace _1.FirstRefactoringTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FirstTask
    {
        private const int MAX_COUNT = 6;

        public static void Main()
        {
            FirstTask.FirstTaskSubclass instance = new FirstTask.FirstTaskSubclass();
            instance.ConvertBoolToString(true);
        }

        public class FirstTaskSubclass
        {
            public void ConvertBoolToString(bool variableToConvert)
            {
                string variableToString = variableToConvert.ToString();
                Console.WriteLine(variableToString);
            }
        }
    }
}