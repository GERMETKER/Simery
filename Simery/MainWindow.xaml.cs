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

            ListToDo.ItemsSource = CasesList;

            



        }

        private void AddCase(object sender, RoutedEventArgs e)
        {
            addCaseWindow.Show();

            
        }
        //<CheckBox Grid.Column="1" Grid.Row="0" Content="Добавление новых дел" VerticalAlignment="Bottom" Name="Box" Checked="Box_Checked" Unchecked="Box_Unchecked"/>
        public void UpdateList()
        {
            ListToDo.ItemsSource = null;
            ListToDo.ItemsSource = CasesList;
        }

       /* private void Box_Checked(object sender, RoutedEventArgs e)
        {
            groupBoxToDo.Visibility = Visibility.Visible;
        }
        private void Box_Unchecked(object sender, RoutedEventArgs e)
        {
            groupBoxToDo.Visibility = Visibility.Hidden;
        }*/

        private void DelCase(object sender, RoutedEventArgs e)
        {
            CasesList.Remove(ListToDo.SelectedItem as ToDo);
            UpdateList();
        }

    }
}