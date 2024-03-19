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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AddOrUpdateWindow.xaml
    /// </summary>
    public partial class AddOrUpdateWindow : Window
    {
        public AddOrUpdateWindow()
        {
            InitializeComponent();
            Load();
            DataContext = new Users();
        }
        public AddOrUpdateWindow(Users user)
        {
            InitializeComponent();
            Load();
            DataContext = new Users();
        }

        private void Load()
        {
            CmbRoles.ItemsSource = Helper.context.Roles.ToList();
        }

        private void BtnSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Users user && user.Id == 0)
            {
                Helper.context.Users.Add(user);

            }
            Helper.context.SaveChanges();
            Close();
        }
    }
}
