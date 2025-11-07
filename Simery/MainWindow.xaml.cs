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

            //ListBoxToDo.ItemsSource = CasesList;

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
            ListBoxToDo.ItemsSource = null;
            ListBoxToDo.ItemsSource = CasesList;
            casesCount = CasesList.Count;
            Max.Text = casesCount.ToString();
        }


        private void DelCase(object sender, RoutedEventArgs e)
        {
            //DataGridToDo.Remove(DataGridToDo.SelectedItem as ToDo);
            CasesList.Remove(ListBoxToDo.SelectedItem as ToDo);
            UpdateList();
            compleatedCases = 0;
            CasesProgress.Value = compleatedCases;
            CasesProgress.Maximum = casesCount;
            Val.Text = compleatedCases.ToString();
            Max.Text = casesCount.ToString();


        }

        /*
         * <DataGrid Name="DataGridToDo"  Background="#FDF5DF" Grid.ColumnSpan="2" Grid.Row="1" Grid.Column="0" Margin="5" HorizontalScrollBarVisibility="Auto" VerticalScrollBarVisibility="Auto">
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <CheckBox Checked="CasesPlus" Unchecked="CasesMin" IsThreeState="False"
                                      IsChecked="{Binding Path=IsCompleted}"></CheckBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <DataGridTextColumn  IsReadOnly="True" Width="*" Binding="{Binding Path=CaseName}" />
                <DataGridTextColumn IsReadOnly="True" Binding="{Binding Path=TimeOfCompleating, StringFormat=dd.MM.yyyy}" />
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Button Grid.Column="0" Grid.Row="2" Name="buttonDel" Click="DelCase"  Background="#5EBEC4" Height="15" Width="15" Margin="5">
                                <Image Source="Images/Крестик.jpg" Height="10"></Image>
                            </Button>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
            <DataGrid.RowDetailsTemplate>
                <DataTemplate>
                    <TextBox  TextWrapping="Wrap" IsReadOnly="True" MaxLines="8" Width="370" HorizontalScrollBarVisibility="Auto" VerticalScrollBarVisibility="Auto" Text="{Binding Path = Description}"></TextBox>
                </DataTemplate>
            </DataGrid.RowDetailsTemplate>
        </DataGrid>
         */



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
