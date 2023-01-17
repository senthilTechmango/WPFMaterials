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
    /// Interaction logic for UcDataGridComboBox.xaml
    /// </summary>
    public partial class UcDataGridComboBox 
    {
        string searchText = "";
        int pageNumber = 1;
        public UcDataGridComboBox()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            int pagenumber =1;
            gridEmployee.ItemsSource = Helper.BindDataGridCtrls("SP_DataGrid", "Tbl_EmployeeTest", "Emp_Id","asc",1,5);
            demoCmb.ItemsSource = Helper.ComboBoxData();
            if (pagenumber <= 1)
            {
                btnPrev.IsEnabled = false;
            }
            lblPageNo.Content = pagenumber;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        { 
            string filterColumn = demoCmb.Text;
            if (filterColumn == "")
            {
                filterColumn = "[EmpName]";
            }

            if (string.IsNullOrEmpty(searchText))
            {
                string filterValue1 = txt_SearchName.Text;
                gridEmployee.ItemsSource = Helper.BindDataGrid("SP_DataGrid", "Tbl_EmployeeTest", "Emp_Id", "asc", 1, 5, filterColumn, filterValue1);
                searchText = "";
            }
            else
            {
                string filterValue = searchText;
                gridEmployee.ItemsSource = Helper.BindDataGrid("SP_DataGrid", "Tbl_EmployeeTest", "Emp_Id", "asc", 1, 5, filterColumn, filterValue);
                searchText = "";
            }
        }
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            int currentPage = pageNumber - 1;
            pageNumber = currentPage;
            gridEmployee.ItemsSource = Helper.BindDataGrid("SP_DataGrid", "Tbl_EmployeeTest", "Emp_Id", "asc", currentPage, 5);
            lblPageNo.Content = currentPage;
            if (pageNumber <= 1)
            {
                btnPrev.IsEnabled = false;
                btn_First.IsEnabled = false;
            }

            if (gridEmployee.Items.Count >= 5)
            {
                btnNext.IsEnabled = true;
                btn_Last.IsEnabled = true;
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int currentPage = pageNumber + 1;
            gridEmployee.ItemsSource = Helper.BindDataGrid("SP_DataGrid", "Tbl_EmployeeTest", "Emp_Id", "asc", currentPage, 5);
            lblPageNo.Content = currentPage;
            pageNumber = currentPage;
            if (pageNumber > 1)
            {
                btnPrev.IsEnabled = true;
                btn_First.IsEnabled = true;
            }
            if (gridEmployee.Items.Count <= 5)
            {
                btnNext.IsEnabled = false;
                btn_Last.IsEnabled = false;
            }
        }

        private void txt_SearchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                searchText = txt_SearchName.Text;
                txt_SearchName.Text= searchText;
                btnSearch_Click(null, null);
            }

        }

        private void btn_First_Click(object sender, RoutedEventArgs e)
        {
            int currentPage = 1;
            pageNumber = currentPage;
            gridEmployee.ItemsSource = Helper.BindDataGrid("SP_DataGrid", "Tbl_EmployeeTest", "Emp_Id", "asc", currentPage, 5);
            lblPageNo.Content = currentPage;
            btn_First.IsEnabled = false;
            btnPrev.IsEnabled = false;
            btnNext.IsEnabled = true;
            btn_Last.IsEnabled = true;
        }

        private void btn_Last_Click(object sender, RoutedEventArgs e)
        {
            ////int currentPage = DataGridConfig.TotalPages;
            ////pageNumber = currentPage;
            //gridEmployee.ItemsSource = Helper.BindDataGrid("SP_DataGrid", "Tbl_EmployeeTest", "Emp_Id", "asc", currentPage, 5);
            ////lblPageNo.Content = currentPage;
         
            //btnNext.IsEnabled = false;
            //btn_Last.IsEnabled = false;

            //btn_First.IsEnabled = true;
            //btnPrev.IsEnabled = true;
          
        }
    }
}
