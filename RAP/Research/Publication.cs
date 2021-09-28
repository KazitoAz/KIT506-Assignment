using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
   
    public class Publication
    {
        public string Doi { get; set; } //publication table doi
        public string PublicationTitle { get; set; } //publication table title
        public string Authors { get; set; } //publication table authors
        public DateTime Year { get; set; } //publication table year
        public OutputType PublicationType { get; set; } //publication table type
        public string CiteAs { get; set; } //publication table cite_as
        public DateTime Available { get; set; } //publication table available
        public int Age
        {
            get { return (DateTime.Today - Year).Days / 365; }
        }
        public override string ToString() //for testing, can be changed
        {
            return Doi + "\t" + PublicationTitle + "\t" + Year + "\t" + Authors + "\t" + Available;
        }

    }
}
