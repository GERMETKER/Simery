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

            /*foreach (var i in CasesList)
            {
                ListToDo.Items.Add(i);

            }*/



            CasesList.Add(new ToDo("Приготовить покушать", new DateTime(2024, 1, 15), "Нет описания"));
            CasesList.Add(new ToDo("Поработать", new DateTime(2024, 1, 20), "Съездить на совещание в Москву"));
            CasesList.Add(new ToDo("Отдохнуть", new DateTime(2024, 2, 1), "Съездить в отпуск в Сочи"));

            ListToDo.ItemsSource = CasesList;




            InitializeComponent();

           

        }

        private void AddCase(object sender, RoutedEventArgs e)
        {
            string case_name = titleToDo.Text;
            DateTime? date_case = dateToDo.SelectedDate;
            string case_description = descriptionToDo.Text;

            CasesList.Add(new ToDo(case_name, date_case, case_description));

            
        }

        private void Box_Checked(object sender, RoutedEventArgs e)
        {
            groupBoxToDo.Visibility = Visibility.Visible;
        }
        private void Box_Unchecked(object sender, RoutedEventArgs e)
        {
            groupBoxToDo.Visibility = Visibility.Hidden;
        }

    }
}