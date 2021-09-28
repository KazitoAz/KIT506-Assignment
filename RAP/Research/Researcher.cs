using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    public class Researcher
    {
        public int Id { get; set; } //researcher table id
        public Type JobType { get; set; } //researcher table type
        public string GivenName { get; set; } //researcher table given_name
        public string FamilyName { get; set; } //researcher table family_name
        public string Title { get; set; } //researcher table title
        public string Unit { get; set; } //researcher table unit
        public string Campus { get; set; } //researcher table campus
        public string Email { get; set; } //researcher table email
        public string Photo { get; set; } //researcher table photo
        public DateTime CurrentStart { get; set; } //researcher current_start
        public DateTime UtasStart { get; set; } //researcher utas_start
        public level CurrentLevel { get; set; } //researcher level
        public string CurrentTitle
        {
            get
            {
                if ((int)JobType == 0)
                {
                    return "Student";
                }
                else
                {

                    if ((int)CurrentLevel == 1)
                    {
                        return "Postdoc";
                    }
                    else if ((int)CurrentLevel == 2)
                    {
                        return "Lecturer";
                    }
                    else if ((int)CurrentLevel == 3)
                    {
                        return "Senior Lecturer";
                    }
                    else if ((int)CurrentLevel == 4)
                    {
                        return "Associate Professor";
                    }
                    else
                    {
                        return "Professor";
                    }
                }
            }
        }
        public float Tenure
        {
            get { return (DateTime.Today - UtasStart).Days / 365; }
        }
        public string CurrentJob
        {
            get
            {
                if ((int)JobType == 0)
                {
                    return "Student";
                }
                else
                {
                    return CurrentLevel.ToString();
                }
            }
        }
        public string EarliestJob { get; set; } //from position table, get the smallest start of a certain id, and return with the level
        public int PublicationsCount { get; set; } //from researcher_publication table, get count number of a certain id
        public override string ToString() //for testing, can be changed
        {
            return Id + "\t" + GivenName + "\t" + FamilyName + "\t" + JobType + "\t" + CurrentTitle;
        }
    }
}
