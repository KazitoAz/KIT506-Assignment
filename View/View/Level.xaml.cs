using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Level.xaml 的交互逻辑
    /// </summary>
    public partial class Level : UserControl
    {
        private const string Key = "researcherList";
        //  private //定义的researcher controller的名字// researcherController;

        public Level()
        {
            InitializeComponent();
            //定义researchr controller
            // researcherController = (ResearcherController)(Application.Current.FindResource(Key) as ObjectDataProvider).ObjectInstance;

        }

        //定义searchbox
        private void Search_TextChanged(object sender, TextChangedEventArgs a) 
            //Searching by key word achieved here through LINQ
        {

            if (researcherController == null)
            {
                //null in the box
            }
            else
            {
                string name = SearchKeyWord.Text;
                string level = Combo1.SelectedItem.ToString();
                researcherController.Filter(name, level);
            }
        }


        //定义下拉单
        private void Combo1_SelectionChanged(object sender, SelectionChangedEventArgs a)
        {
            if (researcherController == null)
            {
                // noll in the box
            }
            else
            {
                string name = SearchKeyWord.Text;
                string level = null;
                if (null == Combo1.SelectedItem)
                {
                    level = "All";
                }
                else
                {
                    level = Combo1.SelectedItem.ToString();
                }
                researcherController.Filter(name, level);
            }
        }

        //自定义函数Level_loaded
        private void Level_Loaded(object sender, RoutedEventArgs a)
        {
            // Using enum to define employmentlevel (在researcher中定义的level)
            var EmployeeLevelList = Enum.GetValues(typeof(EmploymentLevelEnum)).Cast<EmploymentLevelEnum>();
            Combo1.ItemsSource = EmployeeLevelList;
            Combo1.SelectedIndex = 0;

        }







    }
}
