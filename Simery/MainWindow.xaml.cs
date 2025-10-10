using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Simery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ToDo> CasesList;

        public MainWindow()
        {
            CasesList = new List<ToDo>();



            InitializeComponent();

            CasesList.Add(new ToDo("Приготовить покушать", new DateTime(2024, 1, 15), "Нет описания"));
            CasesList.Add(new ToDo("Поработать", new DateTime(2024, 1, 20), "Съездить на совещание в Москву"));
            CasesList.Add(new ToDo("Отдохнуть", new DateTime(2024, 2, 1), "Съездить в отпуск в Сочи"));


            ListToDo.ItemsSource = CasesList;

            



        }

        private void AddCase(object sender, RoutedEventArgs e)
        {

            ListToDo.ItemsSource = CasesList;
            string case_name = titleToDo.Text;
            DateTime? date_case = dateToDo.SelectedDate;
            string case_description = descriptionToDo.Text;



            CasesList.Add(new ToDo(case_name, date_case, case_description));

            titleToDo.Text = null;
            dateToDo.SelectedDate = null;
            descriptionToDo.Text = null;

            UpdateList();

        }

        private void UpdateList()
        {
            ListToDo.ItemsSource = null;
            ListToDo.ItemsSource = CasesList;
        }

        private void Box_Checked(object sender, RoutedEventArgs e)
        {
            groupBoxToDo.Visibility = Visibility.Visible;
        }
        private void Box_Unchecked(object sender, RoutedEventArgs e)
        {
            groupBoxToDo.Visibility = Visibility.Hidden;
        }

        private void DelCase(object sender, RoutedEventArgs e)
        {
            CasesList.Remove(ListToDo.SelectedItem as ToDo);
            UpdateList();
        }
    }
}