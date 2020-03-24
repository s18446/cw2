using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.Models
{
    class Student
    {
        [XmlAttribute(attributeName: "indexNumber")]
        public string indexNumber { get; set; }

        [XmlAttribute(attributeName: "fname")]
        public string name { get; set; }

        [XmlAttribute(attributeName: "lname")]
        public string lastName { get; set; }

        [XmlAttribute(attributeName: "birthdate")]
        public string birthdate { get; set; }

        [XmlAttribute(attributeName: "email")]
        public string email { get; set; }

        [XmlAttribute(attributeName: "mothersName")]
        public string mothersName { get; set; }

        [XmlAttribute(attributeName: "fathersName")]
        public string fathersName { get; set; }

        [XmlAttribute(attributeName: "studies")]
        public Studies studies { get; set; }



        //propfull + tabx2

        //     private string _nazwisko;
        //   public string Nazwisko
        // {
        //   get { return _nazwisko; }
        // set
        // {
        //    if (value == null) throw new ArgumentException();
        //   _nazwisko = value;
        //   }
        // }
    }
}
