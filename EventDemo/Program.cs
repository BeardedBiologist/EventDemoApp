using System;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CollegeClassModel history = new CollegeClassModel("History '101'", 3);
            CollegeClassModel math = new CollegeClassModel("Calculus '201'", 2);

            history.EnrollmentFull += CollegeClass_EnrollmentFull;

            history.SignUpStudents("Tim Corey").PrintToConsole();
            history.SignUpStudents("Sue Storm").PrintToConsole();
            history.SignUpStudents("Joe Smith").PrintToConsole();
            history.SignUpStudents("Mary Jones").PrintToConsole();
            history.SignUpStudents("Sandy Patty").PrintToConsole();
            Console.WriteLine();

            math.EnrollmentFull += CollegeClass_EnrollmentFull;

            math.SignUpStudents("Sue Storm").PrintToConsole();
            math.SignUpStudents("Joe Smith").PrintToConsole();
            math.SignUpStudents("Mary Jones").PrintToConsole();

            Console.ReadLine();
        }

        private static void CollegeClass_EnrollmentFull(object? sender, string e)
        {
            CollegeClassModel model = (CollegeClassModel)sender;
            Console.WriteLine();
            Console.WriteLine($"{model.CourseTitle}: Full ");
            Console.WriteLine();
        }

        
    }
}