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

namespace TechMangoWPFControls.UserControl
{
    /// <summary>
    /// Interaction logic for UcComboBind.xaml
    /// </summary>
    public partial class UcComboBind
    {
        public UcComboBind()
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
            demoCmb.ItemsSource = Helper.BindCombo("SP_TMComboBind", "Emp_Id", "EmpName", "IsActive", "Tbl_EmployeeTest", "S", "EmpName", "desc", 1, 1);
            demoCmb.DisplayMemberPath = "EmpName";
            demoCmb.SelectedValuePath = "Emp_Id";
        }
    }
}
