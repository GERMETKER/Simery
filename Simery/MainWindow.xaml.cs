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

        public int compleatedCases {  get; set; }

        public int casesCount { get; set; }
       

        public MainWindow()
        {
            InitializeComponent();

            CasesList.Add(new ToDo("Приготовить покушать", new DateTime(2024, 1, 15), "Нет описания"));
            CasesList.Add(new ToDo("Поработать", new DateTime(2024, 1, 20), "Съездить на совещание в Москву"));
            CasesList.Add(new ToDo("Отдохнуть", new DateTime(2024, 2, 1), "Съездить в отпуск в Сочи"));

            DataGridToDo.ItemsSource = CasesList;

            casesCount = CasesList.Count;

            CasesProgress.Maximum = casesCount;

            Max.Text = casesCount.ToString();
            Val.Text = compleatedCases.ToString();

            
        }

        /*
         * <Window.Resources>
        <Style x:Key="TextStyle">
            <Setter Property="ItemsControl.BorderBrush" Value="#5EBEC4"/>
            <Setter Property="ItemsControl.BorderThickness" Value="1,5"/>
        </Style>

        <Style TargetType="TextBox">
            <Setter Property="ItemsControl.BorderBrush" Value="#5EBEC4"/>
            <Setter Property="ItemsControl.BorderThickness" Value="1,5"/>
        </Style>
    </Window.Resources>
        Style="{StaticResource TextStyle}"
         */

        private void AddCase(object sender, RoutedEventArgs e)
        {
            AddCaseWindow addCaseWindow = new AddCaseWindow();
            addCaseWindow.Owner = this;
            addCaseWindow.Show();

            casesCount = CasesList.Count;
            CasesProgress.Maximum = casesCount;
            Max.Text = casesCount.ToString();
        }
       
        public void UpdateList()
        {
            DataGridToDo.ItemsSource = null;
            DataGridToDo.ItemsSource = CasesList;
            casesCount = CasesList.Count;
            Max.Text = casesCount.ToString();
        }


        private void DelCase(object sender, RoutedEventArgs e)
        {
            //DataGridToDo.Remove(DataGridToDo.SelectedItem as ToDo);
            CasesList.Remove(DataGridToDo.SelectedItem as ToDo);
            UpdateList();
            compleatedCases = 0;
            CasesProgress.Value = compleatedCases;
            CasesProgress.Maximum = casesCount;
            Val.Text = compleatedCases.ToString();
            Max.Text = casesCount.ToString();


        }


        private void CasesPlus(object sender, RoutedEventArgs e)
        {
            compleatedCases++;
            CasesProgress.Value = compleatedCases;
            Val.Text = compleatedCases.ToString();
            Max.Text = casesCount.ToString();

            var todo = (sender as CheckBox)?.DataContext as ToDo;
            todo.IsCompleted = true;


        }

        private void CasesMin(object sender, RoutedEventArgs e)
        {
            compleatedCases--;
            CasesProgress.Value = compleatedCases;
            Val.Text = compleatedCases.ToString();
            Max.Text = casesCount.ToString();

            var todo = (sender as CheckBox)?.DataContext as ToDo;
            todo.IsCompleted = false;
        }
    }
}
