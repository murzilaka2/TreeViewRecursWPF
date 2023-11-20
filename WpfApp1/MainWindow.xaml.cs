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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Task rooTask = new Task
            {
                Name = "Game Development",
                Description = "The turtule game"
            };

            Task firstTask = new Task { Name = "-Create a landspace", Description = "" };
            Task secondTask = new Task { Name = "-Create sky and tree textures", Description = "" };
            Task thirdTask = new Task { Name = "-Create a hero icons", Description = "" };

            secondTask.Tasks.Add(new Task { Name = "-- Create a sky" });
            secondTask.Tasks.Add(new Task
            {
                Name = "-- Create a tree textures",
                Tasks = new List<Task>(){
                    new Task{ Name = "--- Create a root"},
                    new Task{ Name = "--- Create a thunk"},
                    new Task{ Name = "--- Create a leaves"}
                    }
            });

            rooTask.Tasks.Add(firstTask);
            rooTask.Tasks.Add(secondTask);
            rooTask.Tasks.Add(thirdTask);

            treeViewTask.Items.Add(CreateRootTask(rooTask));
        }
        private TreeViewItem CreateRootTask(Task rootTask)
        {
            TreeViewItem treeViewItem = new TreeViewItem() { Header = rootTask.Name };
            foreach (var item in rootTask.Tasks)
            {
                if (item.IsInnerTasks)
                {
                    TreeViewItem treeViewItemInner = CreateRootTask(item);
                    treeViewItem.Items.Add(treeViewItemInner);
                }
                else
                {
                    treeViewItem.Items.Add(item.Name);
                }
            }
            return treeViewItem;
        }
    }
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsInnerTasks
        {
            get
            {
                return Tasks.Count > 0;
            }
        }
        public List<Task> Tasks { get; set; }
        public Task()
        {
            Tasks = new List<Task>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}