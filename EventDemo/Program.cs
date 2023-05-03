using System;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CollegeClassModel history = new CollegeClassModel("History '101'", 3);
            CollegeClassModel math = new CollegeClassModel("Calculus '201'", 2);

            history.EnrollmentFull += History_EnrollmentFull;

            history.SignUpStudents("Tim Corey").PrintToConsole();
            history.SignUpStudents("Sue Storm").PrintToConsole();
            history.SignUpStudents("Joe Smith").PrintToConsole();
            history.SignUpStudents("Mary Jones").PrintToConsole();
            history.SignUpStudents("Sandy Patty").PrintToConsole();
            Console.WriteLine();

            math.EnrollmentFull += Math_EnrollmentFull;

            math.SignUpStudents("Sue Storm").PrintToConsole();
            math.SignUpStudents("Joe Smith").PrintToConsole();
            math.SignUpStudents("Mary Jones").PrintToConsole();

            Console.ReadLine();
        }

        private static void Math_EnrollmentFull(object? sender, string e)
        {
            Console.WriteLine();
            Console.WriteLine("The Enrollment is full for Math");
            Console.WriteLine();
        }

        private static void History_EnrollmentFull(object? sender, string e)
        {
            Console.WriteLine();
            Console.WriteLine("The Enrollment is full for History");
            Console.WriteLine();
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
        public event EventHandler<string> EnrollmentFull;

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
                if (enrolledStudents.Count == MaximumStudents)
                {
                    EnrollmentFull?.Invoke(this, $"{CourseTitle} enrollment is full");
                }
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