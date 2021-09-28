using RAP.Database;
using RAP.Research;
using System.Collections.ObjectModel;
using System.Linq;

namespace RAP.Controller
{
    //Display publication details in a new view screen.
    public class PublicationCount
    {
        public int Year { get; set; }
        public int Count { get; set; }

        private database dbadapter = null;

        //Number of publications acquired.
        public override string ToString()
        {

            return "Year: " + Year + "  Quantity:   " + Count;

        }

        public ObservableCollection<Publication> GetPublicationsByRange(int rid, int start, int end)    //Filter publications by a user-selected range of years.
        {

            ObservableCollection<Publication> allPublications = new ObservableCollection<Publication>();

            allPublications = dbadapter.GetPubByID(rid);

            ObservableCollection<Publication> filteredPublications = new ObservableCollection<Publication>();
            var result = from Publication c in allPublications
                         where (c.Year >= start) && (c.Year <= end)  //error????
                         select c;

            ObservableCollection<Publication> filterPublications = new ObservableCollection<Publication>(result.ToList());
            return filteredPublications;
        }


        public ObservableCollection<Publication> FilterByRange(int rid, int starty, int endy)
        {

            return dbadapter.FilterPubByYear(rid, starty, endy);

        }
    }
}
