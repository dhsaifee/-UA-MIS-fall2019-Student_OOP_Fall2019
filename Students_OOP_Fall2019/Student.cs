using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Students_OOP_Fall2019
{
    class Student
    {
        private string name;
        private string classRank;
        private int grade;
        private static int count;


        public Student(string name, string classRank, int grade)
        {
            this.name = name;
            this.classRank = classRank;
            this.grade = grade; ;
        }

        public Student()
        {

        }


        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }


        public string GetClassRank()
        {
            return classRank;
        }

        public void SetClassRank(string classRank)
        {
            this.classRank = classRank;
        }


        public int GetGrade()
        {
            return grade;
        }

        public void SetGrade(int grade)
        {
            this.grade = grade;
        }


        public static int GetCount()
        {
            return count;
        }

        public static void SetCount(int count)
        {
            Student.count = count;
        }

        public static void IncCount()
        {
            count++;
        }


        public override string ToString()
        {
            return name + "\t" + classRank + "\t\t" + grade;
        }


        public int CompareTo(Student myStudent)
        {
            return name.CompareTo(myStudent.GetName());
        }


        public static void PrintStudentData(Student[] myStudents)
        {
            Console.WriteLine("\nName\t\tClass\t\tGrade");

            for(int i = 0; i < GetCount(); i++)
            {
                Console.WriteLine(myStudents[i].ToString());
            }

            Console.WriteLine("\n");
        }


        public static void WriteStudentFile(Student[] myStudents)
        {
            StreamWriter outFile = new StreamWriter("output.txt");

            for (int i = 0; i < GetCount(); i++)
            {
                Console.WriteLine(myStudents[i].ToString());
            }

            outFile.Close();
        }


        public static void SortByClass(Student[] myStudents)
        {
            int minIndex;

            for (int i = 0; i < GetCount() - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < GetCount(); j++)
                {
                    if (myStudents[j].GetClassRank().CompareTo(myStudents[minIndex].GetClassRank()) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    SwapStudents(myStudents, i, minIndex);
                }
            }
        }


        public static void SwapStudents(Student[] myStudents, int x, int y)
        {
            Student temp = myStudents[x];
            myStudents[x] = myStudents[y];
            myStudents[y] = temp;
        }


        public static void SortByName(Student[] myStudents)
        {
            int minIndex;

            for (int i = 0; i < GetCount() - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < GetCount(); j++)
                {
                    if (myStudents[j].CompareTo(myStudents[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    SwapStudents(myStudents, i, minIndex);
                }
            }
        }

        public static int SearchByName(Student[] myStudents, string searchVal)
        {
            int foundIndex = -1;
            bool notFound = true;
            int first = 0;
            int last = GetCount() - 1;
            int middle;
            searchVal = searchVal.ToLower();

            while (notFound && first <= last)
            {
                middle = (first + last) / 2;

                if (searchVal == myStudents[middle].GetName().ToLower())
                {
                    foundIndex = middle;
                    notFound = false;
                }
                else if (searchVal.CompareTo(myStudents[middle].GetName()) > 0)
                {
                    first = middle + 1;
                }
                else
                {
                    last = middle - 1;
                }
            }

            return foundIndex;
        }



    }
}
