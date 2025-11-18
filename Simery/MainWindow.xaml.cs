using Newtonsoft.Json;
using System.IO;
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

        /*
         * <DataTrigger Binding="{Binding Path=TimeOfCompleating, Converter={StaticResource LessDayConverter}}" Value="True">
                     <Setter Property="Foreground" Value="Red"></Setter>
                 </DataTrigger>

                 <DataTrigger Binding="{Binding Path=TimeOfCompleating, Converter={StaticResource LessDayConverter}}" Value="False">
                     <Setter Property="Foreground" Value="Green"></Setter>
                 </DataTrigger>
        */

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
            UpdateList();


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
            
            int n = 0;
            foreach(var i in CasesList)
            {
                if (i.IsCompleted == true)
                {
                    n++;
                }
                else { }
            }
            compleatedCases = n;
            CasesProgress.Value = compleatedCases;
            CasesProgress.Maximum = casesCount;
            Val.Text = CasesProgress.Value.ToString();
        }


        private void DelCase(object sender, RoutedEventArgs e)
        {
            //DataGridToDo.Remove(DataGridToDo.SelectedItem as ToDo);
            if (MessageBox.Show("Вы уверены, что хотите удалить дело?",
                    "Удаление дела",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ((sender as Button).DataContext as ToDo).IsCompleted = false;
                CasesList.Remove((sender as Button).DataContext as ToDo);

                CasesProgress.Value = compleatedCases;
                CasesProgress.Maximum = casesCount;
                Val.Text = compleatedCases.ToString();
                Max.Text = casesCount.ToString();
                UpdateList();
            }
            

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

        private void SaveInCase(object sender, RoutedEventArgs e)
        {
            if (CasesList.Count == 0)
            {
                MessageBox.Show("В списке нет дел");
            }
            else
            {



                var dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.FileName = "Saved_list"; // Default file name
                dialog.DefaultExt = ".txt"; // Default file extension
                dialog.Filter = "Text File|*.txt"; // Filter files by extension

                // Show save file dialog box
                bool? result = dialog.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    string filePath = dialog.FileName;
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {

                        foreach (var i in CasesList)
                        {
                            DateOnly d = DateOnly.FromDateTime(i.TimeOfCompleating.Value);
                            if (i.IsCompleted == true)
                            {
                                writer.Write("✓");
                            }
                            else
                            {
                                writer.Write(" ");
                            }
                            writer.WriteLine(i.CaseName);
                            writer.WriteLine("");
                            writer.WriteLine(i.Description);
                            writer.WriteLine("");
                            writer.WriteLine(d.ToString());
                            writer.WriteLine("");
                            writer.WriteLine("");
                        }
                    }
                }

                var dialog2 = new Microsoft.Win32.SaveFileDialog();
                dialog2.FileName = "Saved_list"; // Default file name
                dialog2.DefaultExt = ".json"; // Default file extension
                dialog2.Filter = "Text File|*.json"; // Filter files by extension

                // Show save file dialog box
                bool? result2 = dialog2.ShowDialog();

                // Process save file dialog box results
                if (result2 == true)
                {
                    string filePath2 = dialog2.FileName;
                    var settings = new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented
                    };
                    string json = JsonConvert.SerializeObject(CasesList, settings);
                    File.WriteAllText(filePath2, json);
                }
            }
        }
    }
}
