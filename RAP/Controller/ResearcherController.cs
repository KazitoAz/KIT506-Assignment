using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using RAP.Research;
using RAP.Database;

namespace RAP.Controller
{
    class ResearcherController
    {
        private List<Researcher> researcherList;
        public List<Researcher> Workers { get { return researcherList; } set { } }

        private ObservableCollection<Researcher> ResearcherVisibility;
        public ObservableCollection<Researcher> VisibleResearcher { get { return ResearcherVisibility; } set { } }

        public ResearcherController()
        {
            //Retrieve the details of the researcher from the database.
            researcherList = database.LoadAll();
            ResearcherVisibility = new ObservableCollection<Researcher>(researcherList);

            //Loop through the search list, taking a different section each time and displaying it separately.
            foreach (Researcher a in researcherList)
            {

                a.PositionId = database.LoadPosition(a.Id);            //error????
                a.PublicationsCount = database.CntPublications(a.Id);
                a.PublicationId = database.LoadPublication(a.Id);

                //Load students
                if (a.CurrentTitle == "Student")
                {

                    a.Student = database.LoadStudent(a.Id);

                }
                //Load Other staffs
                else
                {

                    a.Staff = database.LoadStaff(a.Id);

                }
            }
        }


        //Filter
        public void Filter(string name, string level)
        {

            // if researcher level has not been selected.
            SearchByFamilyName(name) ;
            if (level == "All")
            {

            }
            // if researcher level has been selected.
            else
            {
            SearchByLevel(level);
            }
        }

        public ObservableCollection<Researcher> GetViewableList()
        {
            return VisibleResearcher;
        }


        //Filter the list of researchers by their level.
        public void SearchByLevel(string level)
        {

            List<Researcher> view = ResearcherVisibility.ToList();
            foreach (Researcher a in view)
            {

                if (level == a.CurrentTitle)
                {

                }

                else
                {

                    ResearcherVisibility.Remove(a);
                }
            }
        }


        //Filter the list of researchers by their name.
        public void SearchByGivenName(string name)
        {
            var SearchName = from Researcher a in researcherList
            where (a.GivenName.ToLower()).Contains(name.ToLower())
            select a;
            ResearcherVisibility.Clear(); //hide researcher
            SearchName.ToList().ForEach(ResearcherVisibility.Add);
        }

        public void SearchByFamilyName(string name)
        {
            var SearchName = from Researcher a in researcherList
            where (a.FamilyName.ToLower()).Contains(name.ToLower())
            select a;
            ResearcherVisibility.Clear(); //hide researcher
            SearchName.ToList().ForEach(ResearcherVisibility.Add);
        }




    }
}
