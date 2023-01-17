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
    /// Interaction logic for DataGrid_Bind.xaml
    /// </summary>
    public partial class DataGrid_Bind : Window
    {
      private int pageNumber = DataConfig.PageNumber;
        public DataGrid_Bind()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataConfig.SQLQuery = "[SP_DataGrid]";
            DataConfig.TableName = "[Tbl_EmployeeTest]";
            DataConfig.PrimaryColumn = "[Emp_Id]";
            DataConfig.SortColumn = "[Emp_Id]";
            DataConfig.SortOrder = "asc"; 
            DataConfig.PageNumber = 1;
            DataConfig.PageSize = 5;
            int pagenumber = DataConfig.PageNumber;
            gridEmployee.ItemsSource = Helper.BindDataGrid(DataConfig.SQLQuery, DataConfig.TableName, DataConfig.SortColumn, DataConfig.SortOrder, pagenumber, DataConfig.PageSize);
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
            string filterValue = txt_SearchName.Text;
            int pagenumber = DataConfig.PageNumber;
            gridEmployee.ItemsSource = Helper.BindDataGrid(DataConfig.SQLQuery, DataConfig.TableName, DataConfig.SortColumn, DataConfig.SortOrder, pagenumber, DataConfig.PageSize, filterColumn, filterValue);

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
           // DataRowView selectedRow = (DataRowView)gridEmployee.SelectedItem;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int currentPage = pageNumber + 1;
            int pagenumber = currentPage;

            gridEmployee.ItemsSource = Helper.BindDataGrid(DataConfig.SQLQuery,DataConfig.TableName, DataConfig.SortColumn, DataConfig.SortOrder, pagenumber, DataConfig.PageSize);

            lblPageNo.Content = currentPage;
            pageNumber = currentPage;

            if (pageNumber > 1)
            {
                btnPrev.IsEnabled = true;
            }

            if (gridEmployee.Items.Count <= DataConfig.PageSize)
            {
                btnNext.IsEnabled = false;
            }
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            int currentPage = pageNumber - 1;
            int pagenumber = currentPage;
            gridEmployee.ItemsSource = Helper.BindDataGrid(DataConfig.SQLQuery, DataConfig.TableName, DataConfig.SortColumn, DataConfig.SortOrder, pagenumber, DataConfig.PageSize);
            pageNumber = currentPage;
            lblPageNo.Content = currentPage;
            if (pageNumber <= 1)
            {
                btnPrev.IsEnabled = false;
            }

            if (gridEmployee.Items.Count >= 5)
            {
                btnNext.IsEnabled = true;
            }
        }
    }
}
