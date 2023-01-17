using System;
using System.Collections.Generic;
using System.Data;
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
using TMBL;


namespace TechMangoWPFControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_Bind dgbind = new DataGrid_Bind();
            dgbind.Show();
          
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ComboBind bind = new ComboBind();
            bind.Show();
        }
        private void exittab_GotFocus(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
