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
using System.Windows.Shapes;
using TMBL;

namespace TechMangoWPFControls
{
    /// <summary>
    /// Interaction logic for ComboBind.xaml
    /// </summary>
    public partial class ComboBind : Window
    {
        string cmbtext = "";
        public ComboBind()
        {
            InitializeComponent();
        }

        private void demoCmb_Loaded(object sender, RoutedEventArgs e)
        {
            ComboControlLib obj = new ComboControlLib();
            DataTable dt = obj.BindComboControls();
            demoCmb.ItemsSource = dt.DefaultView;
            demoCmb.DisplayMemberPath = "EmpName";
            demoCmb.SelectedValuePath = "Emp_Id";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbtext))
            {
                demoCmb.ItemsSource = Helper.BindCombo("SP_TMComboBind", "Emp_Id", "EmpName", "IsActive", "Tbl_EmployeeTest", "U", "EmpName", "Asc", 1, 1);
                cmbtext = "";
            }
            else
            {
                demoCmb.ItemsSource = Helper.BindCombo("SP_TMComboBind", "Emp_Id", "EmpName", "IsActive", "Tbl_EmployeeTest", cmbtext, "EmpName", "Asc", 1, 1);
                cmbtext = "";
            }
            demoCmb.DisplayMemberPath = "EmpName";
            demoCmb.SelectedValuePath = "Emp_Id";
            
        }
     
        private void demoCmb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                cmbtext = demoCmb.Text;
                demoCmb.SelectedItem = cmbtext;
                Button_Click(null, null);
            }

        }
      
    }
}
