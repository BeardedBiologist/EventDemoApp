using System;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CollegeClassModel history = new CollegeClassModel("History '101'", 3);
            CollegeClassModel math = new CollegeClassModel("Calculus '201'", 2);

            history.SignUpStudents("Tim Corey").PrintToConsole();
            history.SignUpStudents("Sue Storm").PrintToConsole();
            history.SignUpStudents("Joe Smith").PrintToConsole();
            history.SignUpStudents("Mary Jones").PrintToConsole();
            history.SignUpStudents("Sandy Patty").PrintToConsole();

            math.SignUpStudents("Sue Storm").PrintToConsole();
            math.SignUpStudents("Joe Smith").PrintToConsole();
            math.SignUpStudents("Mary Jones").PrintToConsole();

            Console.ReadLine();
        }
    }

    public static class ConsoleHelpers
    {
        public static void PrintToConsole(this string message)
        {
            Console.WriteLine(message);
        }
    }

    public class CollegeClassModel
    {
        private List<string> enrolledStudents = new List<string>();
        private List<string> waitingList = new List<string>();

        public string CourseTitle { get; private set; }
        public int MaximumStudents { get; private set; }

        public CollegeClassModel(string title, int maximumStudents)
        {
            CourseTitle = title;
            MaximumStudents = maximumStudents;

        }

        public string SignUpStudents(string studentName)
        {
            string output = "";

            if (enrolledStudents.Count < MaximumStudents)
            {
                enrolledStudents.Add(studentName);
                output = $"{ studentName } was enrolled in { CourseTitle }";

                //check to see if we are maxed out
            }
            else
            {
                waitingList.Add(studentName);
                output = $"{studentName} was added to the {CourseTitle} waiting list";
            }

            return output;
        }
    }
}