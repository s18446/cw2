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
            string inputDestination = @"data.csv";
            string outputDestination = @"result.xml";
            string dataType = "xml";

            if (args.Length == 3)
            {
                inputDestination = args[0];
                outputDestination = args[1];
                dataType = args[3];
            }








            
        ////Wczytywanie
        //var fi = new FileInfo(inputDestination);
        //    using (var stream = new StreamReader(fi.OpenRead()))
        //    {
        //        string line = null;
        //        while ((line = stream.ReadLine()) != null)
        //        {
        //            string[] kolumny = line.Split(',');
        //            Console.WriteLine(line);
        //        }
        //    }
        //    //stream.Dispose();

        //    //XML
        //    var list = new List<Student>();
        //    var st = new Student
        //    {
        //        Imie = "Jan",
        //        Nazwisko = "Kowalski",
        //        Email = "kowalski@wp.pl"
        //    };
        //    list.Add(st);

        //    FileStream writer = new FileStream(@"data.xml", FileMode.Create);
        //    XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
        //                                            new XmlRootAttribute("uczelnia"));
        //    serializer.Serialize(writer, list);
        //    serializer.Serialize(writer, list);


        }

    }
}
