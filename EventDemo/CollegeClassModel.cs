namespace EventDemo
{
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