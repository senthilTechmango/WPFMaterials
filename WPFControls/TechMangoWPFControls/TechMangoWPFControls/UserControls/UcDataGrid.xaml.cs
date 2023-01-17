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

namespace TechMangoWPFControls.UserControls
{
    /// <summary>
    /// Interaction logic for UcDataGrid.xaml
    /// </summary>
    public partial class UcDataGrid 
    {

        public string tablename;
        public UcDataGrid()
        {
            InitializeComponent();
        }
        private void gridEmployee_Loaded(object sender, RoutedEventArgs e)
        {
            tablename = "Tbl_EmployeeTest";
            DataGridControlLib obj = new DataGridControlLib();
            DataTable dt = obj.BindDataGridCtrls(tablename);
            gridEmployee.ItemsSource = dt.DefaultView;
            //gridEmployee.DisplayMemberPath = "EmpName";
            //gridEmployee.SelectedValuePath = "Emp_Id";
        }

        private void txt_SearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string empname;
            DataGridControlLib obj = new DataGridControlLib();
            empname = txt_SearchName.Text;
            tablename = "Tbl_EmployeeTest";
            DataTable dt = obj.SearchDataGrid(tablename,empname);
            gridEmployee.ItemsSource = dt.DefaultView;

        }
    }
}
