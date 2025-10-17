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
        public List<ToDo> CasesList = new List<ToDo>();
        public AddCaseWindow addCaseWindow = new AddCaseWindow();


       

        public MainWindow()
        {
            InitializeComponent();

            CasesList.Add(new ToDo("Приготовить покушать", new DateTime(2024, 1, 15), "Нет описания"));
            CasesList.Add(new ToDo("Поработать", new DateTime(2024, 1, 20), "Съездить на совещание в Москву"));
            CasesList.Add(new ToDo("Отдохнуть", new DateTime(2024, 2, 1), "Съездить в отпуск в Сочи"));

            DataGridToDo.ItemsSource = CasesList;

            



        }

        private void AddCase(object sender, RoutedEventArgs e)
        {
            addCaseWindow.Owner = this;
            addCaseWindow.Show();
            
            
        }
       
        public void UpdateList()
        {
            DataGridToDo.ItemsSource = null;
            DataGridToDo.ItemsSource = CasesList;
        }


        private void DelCase(object sender, RoutedEventArgs e)
        {
            //DataGridToDo.Remove(DataGridToDo.SelectedItem as ToDo);
            CasesList.Remove(DataGridToDo.SelectedItem as ToDo);
            UpdateList();
        }

    }
}