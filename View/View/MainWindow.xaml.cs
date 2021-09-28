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
//using Controller;(Controller文件的名字)
//using Researcher;(Researcher文件的名字)
//using Database; （Database文件的名字）

namespace View
{
   
    public partial class MainWindow : Window
    {
        private const string Key = "researcherList";
        //  private //定义的researcher controller的名字// researcherController;

        public MainWindow()
        {

            //RAPAdapter.LoadAll()//

            //定义researchr controller
            // researcherController = (ResearcherController)(Application.Current.FindResource(Key) as ObjectDataProvider).ObjectInstance;

           // 初始为空
            CumulitiveCount.Visibility = System.Windows.Visibility.Hidden;



            InitializeComponent();
        }
        //Button 1 Show
        private void Button_Click_1(object sender, RoutedEventArgs a)
        {
            SupervisionName Button1 = new SupervisionName();
            Button1.DataContext = Show.DataContext;
            Button1.ShowDialog();
        }

        //Button 2 CumulitiveCount  按钮后显示在下方listbox里
       
        private void Button_Click_2(object sender, RoutedEventArgs a)
        {

            if (CumulitiveCount.Visibility == System.Windows.Visibility.Hidden) // 保证点击一次显示出对应内容，两次则隐藏
            {
                CumulitiveCount.Visibility = System.Windows.Visibility.Visible;
            }
            else
                CumulitiveCount.Visibility = System.Windows.Visibility.Hidden; // 保证初始页面没有内容。
        }

        //Button 3 Year range的Search 触发按钮
        private void Button_Click_3(object sender, RoutedEventArgs a)
        {

            //将researcher文件命名为R, 在这个里面取出对应的信息。

            Researcher R = listbox_Researcher.SelectedItem as Researcher;

            // 定义两个textbox中填入的年份的格式（int）
            int From = Int32.Parse(T1.Text);
            int To = Int32.Parse(T2.Text);

            //将publication中的资料加入publicationlist里面，然后P中的年份与输入的进行对比，最终输出P。

            var Yearrange = from Publication P in R.PublicationList
                         where (P.Year >= From) && (P.Year <= To)
                         select P;

            // 将得到的Yearrange输入到下边的list中显示。
            listbox_Publication.ItemsSource = Yearrange;
        }

           // Button 4 Year range的clear 触发按钮
        private void Button_Click_4(object sender, RoutedEventArgs a)
        {
            List<Publication> PList = ((Researcher)listbox_Researcher.SelectedItem).PublicaitonList;
            
            // 确定好表格里的内容，然后清除。
            listbox_Publication.ItemsSource = null;
            listbox_Publication.ItemsSource = PList;
        }


        // 定义publication中From的textbox_T1
        private void T1_TextChanged(object sender, TextChangedEventArgs a)
        {

        }

        // 定义publication中To的textbox_T2
        private void T2_TextChanged(object sender, TextChangedEventArgs a)
        {

        }




        //定义Listbox，researcher name list里面的。
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs RNL)
        {

            // 初始化表格，当其中有名字但未选择的时候，先不显示。
            if (RNL.AddedItems.Count > 0)
            {
                DetailsPanel.DataContext = RNL.AddedItems[0];
                Photo.DataContext = RNL.AddedItems[0];
                CumulitiveCount.DataContext = RNL.AddedItems[0];

                listbox_Publication.DataContext = RNL.AddedItems[0];
            }

        }


        //定义publication部分的list的初始状态，在controller不回复时为空，回复时显示对应的信息。
        private void Listbox_Publication_SelectionChanged(object sender, SelectionChangedEventArgs a)
        {
            if (researcherController == null)
            {
            }
            else
            {
                PublicationPanel.DataContext = listbox_Publication.SelectedItem;
            }

        }


        //自定义函数。从而将子页面Level.xaml加载到主页面。
        private void Level_loaded (object sender, RoutedEventArgs e)
        {

        }


        //自定义FrameworkElement.loaded
        private void Window_loaded(object sender, RoutedEventArgs a)
        {

        }
    }
