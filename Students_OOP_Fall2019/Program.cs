using System;

namespace Students_OOP_Fall2019
{
    class Program
    {
        static void Main(string[] args)
        {

            Student[] myStudents = StudentFile.ReadStudentFile();

            Student.PrintStudentData(myStudents);

            Console.WriteLine("Combination of students with average grades over 95: ");
            Report.AvgGradesOver95(myStudents);

            Student.SortByClass(myStudents);
            Console.WriteLine("After sorting students by departments: ");
            Student.PrintStudentData(myStudents);

            Console.WriteLine("\nAverage grade by undergraduate class (report also written in grades_by_class.txt): ");
            Report.GradesByClass(myStudents);

            Student.SortByName(myStudents);

            int foundIndex;
            Console.Write("\nPlease enter the name to find (stop to exit): ");
            string nameToFind = Console.ReadLine();

            while (nameToFind.ToLower() != "stop")
            {
                foundIndex = Student.SearchByName(myStudents, nameToFind);

                if (foundIndex == -1)
                {
                    Console.WriteLine(nameToFind + " could not be found");
                }
                else
                {
                    Console.WriteLine(nameToFind + " is a " + myStudents[foundIndex].GetUndergradClass() +
                        " and has a grade: " + myStudents[foundIndex].GetGrade());
                }

                Console.Write("\nPlease enter the name to find (stop to exit): ");
                nameToFind = Console.ReadLine();
            }

            Console.ReadKey();

        }
    }
}
