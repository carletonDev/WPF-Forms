using BLL;
using DatabaseObjects;
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

namespace UserInformation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Insert.Visibility=Visibility.Hidden;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.FirstName = First.Text;
            user.LastName = Last.Text;
            user.State = State.Text;
            user.Zip = Convert.ToInt32(Zip.Text);
            user.City = City.Text;
            user.DOB = Dob.SelectedDate.Value;


            BusinessLogic.InsertUser(user);

            List<User> getUsers = BusinessLogic.GetUsers();
            User check = getUsers.Find(m => m.FirstName == user.FirstName && m.LastName == user.LastName);

            if(check.FirstName != null)
            {
                
                Insert.Content = "User Added";
                Insert.Visibility = Visibility.Visible;
                Clear();
                
            }
            
        }
        public void Clear()
        {
            First.Text = "";
            Last.Text = "";
            State.Text = "";
            Zip.Text = "";
            City.Text = "";
        }
    }
}
