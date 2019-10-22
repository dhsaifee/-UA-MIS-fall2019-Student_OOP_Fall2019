using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Students_OOP_Fall2019
{
    class Report
    {

        public static void AvgGradesOver95(Student[] myStudents)
        {
            StreamWriter outFile = new StreamWriter("avg_grades_over_95.txt");

            for (int i = 0; i < Student.GetCount() - 1; i++)
            {
                for (int j = i + 1; j < Student.GetCount(); j++)
                {
                    if ((myStudents[i].GetGrade() + myStudents[j].GetGrade()) / 2.0 > 95)
                    {
                        Console.WriteLine(myStudents[i].GetName() + "\t" + myStudents[j].GetName() + ": " + 
                            (myStudents[i].GetGrade() + myStudents[j].GetGrade()) / 2.0);
                        outFile.WriteLine(myStudents[i].GetName() + "\t" + myStudents[j].GetName() + ": " +
                            (myStudents[i].GetGrade() + myStudents[j].GetGrade()) / 2.0);
                    }
                }
            }

            Console.WriteLine("\n");

            outFile.Close();
        }


        public static void GradesByClass(Student[] myStudents)
        {
            StreamWriter outFile = new StreamWriter("grades_by_class.txt");

            string currentClass = myStudents[0].GetUndergradClass();
            int count = 1;
            double totalGrade = myStudents[0].GetGrade();
            double avgGrade;

            for (int i = 1; i < Student.GetCount(); i++)
            {
                if (myStudents[i].GetUndergradClass() == currentClass)
                {
                    count++;
                    totalGrade += myStudents[i].GetGrade();
                }
                else
                {
                    avgGrade = totalGrade / count;
                    Console.WriteLine("There are " + count + " " + currentClass + "s and their average grade is " + avgGrade);
                    outFile.WriteLine("There are " + count + " " + currentClass + "s and their average grade is " + avgGrade);

                    currentClass = myStudents[i].GetUndergradClass();
                    count = 1;
                    totalGrade = myStudents[i].GetGrade();
                }
            }

            avgGrade = totalGrade / count;
            Console.WriteLine("There are " + count + " " + currentClass + "s and their average grade is " + avgGrade);
            outFile.WriteLine("There are " + count + " " + currentClass + "s and their average grade is " + avgGrade);

            outFile.Close();
        }



    }
}
