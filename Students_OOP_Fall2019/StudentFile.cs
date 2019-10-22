using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Students_OOP_Fall2019
{
    class StudentFile
    {
        public static Student[] ReadStudentFile()
        {
            Student[] myStudents = new Student[50];

            StreamReader inFile = new StreamReader("input.txt");

            char delimiter = '#';
            string[] tempArray = new string[3];
            Student.SetCount(0);

            string line = inFile.ReadLine();

            while (line != null)
            {
                tempArray = line.Split(delimiter);
                myStudents[Student.GetCount()] = new Student(tempArray[0], tempArray[1], int.Parse(tempArray[2]));

                Student.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();

            return myStudents;
        }
    }
}
