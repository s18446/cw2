using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using cw2.Models;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDestination = @"dane.csv";
            string outputDestination = @"result.xml";
            string dataType = "xml";
            if (args.Length == 3)
            {
                inputDestination = args[0];
                outputDestination = args[1];
                dataType = args[3];
            }

            try
            {

                if (dataType.Equals("xml"))
                {
                    var students = handleData(inputDestination);
                    var uczelnia = new Uczelnia
                    {
                        createdAt = $"{ DateTime.Now}",
                        author = "Daniel Rogowski",
                        students = new List<Student>()
                    };


                    FileStream writer = new FileStream(outputDestination, FileMode.Create);

                    XmlSerializer serializer = new XmlSerializer(typeof(Uczelnia),
                                               new XmlRootAttribute("uczelnia"));
                    serializer.Serialize(writer, uczelnia);
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static List<Student> handleData(string path)
        {
            var students = new List<Student>();
            var activeStudies = new List<ActiveStudies>();
            var fi = new FileInfo(path);
            bool corrupted = false;
            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    foreach (var column in columns)
                    {
                        if (column.Equals(""))
                        {
                            corrupted = true;
                            break;
                        }
                    }
                    if (columns.Length != 9 || corrupted)
                    {
                        string errorMessage = "The numbers of rows is to small or data contained in one of rows is corrupted.";
                        handleCorruptedData(errorMessage);
                    }
                    else
                    {
                        var studentToAdd = new Student
                        {
                            name = columns[0],
                            lastName = columns[1],
                            studiesName = columns[2],
                            studiesMode = columns[3],
                            indexNumber = $"s{columns[4]}",
                            birthdate = DateTime.Parse(columns[5]).Date,
                            email = columns[6],
                            mothersName = columns[7],
                            fathersName = columns[8]
                        };

                        bool duplicateStudent = false;
                        string duplicateInfo = "Duplikat danych studenta: ";
                        foreach (var student in students)
                        {
                            if (student.Equals(studentToAdd))
                            {
                                duplicateStudent = true;
                                handleCorruptedData(duplicateInfo + student.indexNumber);
                                break;
                            }
                        }

                        bool studiesInList = false;
                        if (!duplicateStudent)
                        {
                            foreach (var study in activeStudies)
                            {
                                if ((study.name.Equals(studentToAdd.studiesName)))
                                {
                                    studiesInList = true;
                                    study.numberOfStudents++;
                                }
                            }

                            if (!studiesInList)
                            {
                                var studies = new ActiveStudies
                                {
                                    name = columns[2],
                                    numberOfStudents = 1
                                };
                                activeStudies.Add(studies);
                            }
                            students.Add(studentToAdd);
                        }

                    }
                }

            }
            return students;
        }
        private static void handleCorruptedData(string message)
        {
            using (StreamWriter writer = new StreamWriter("log.txt"))
            {
                writer.WriteLine($"LOG [{DateTime.Now}] {message}");
                Console.WriteLine($"LOG [{DateTime.Now}] {message}");
            }
        }

    }
}

