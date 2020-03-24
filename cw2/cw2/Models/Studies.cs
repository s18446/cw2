using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.Models
{
    class Studies
    {
        [XmlAttribute(attributeName: "name")]
        public string name { get; set; }

        [XmlAttribute(attributeName: "mode")]
        public string mode { get; set; }


    }


}
