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

namespace Simery
{
    /// <summary>
    /// Логика взаимодействия для AddCaseWindow.xaml
    /// </summary>
    public partial class AddCaseWindow : Window
    {
        public AddCaseWindow()
        {
            InitializeComponent();
        }

        private void SaveCase(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            string case_name = titleToDo.Text;
            DateTime? date_case = dateToDo.SelectedDate;
            string case_description = descriptionToDo.Text;

            //this.Owner = mainWindow;

            if (this.Owner is MainWindow main)
            {

                main.CasesList.Add(new ToDo(case_name, date_case, case_description));

                titleToDo.Text = null;
                dateToDo.SelectedDate = null;
                descriptionToDo.Text = null;

                main.UpdateList();
                this.Close();
            }
            

         
        }
    }
}
