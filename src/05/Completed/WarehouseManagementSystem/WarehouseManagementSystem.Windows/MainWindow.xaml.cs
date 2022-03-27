using System.IO;
using System.Text.Json;
using System.Windows;
using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public OrderProcessor Processor { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            #region Populate the UI
            Orders.ItemsSource = JsonSerializer.Deserialize<Order[]>(File.ReadAllText("orders.json"));
            #endregion

            Processor = new();
        }

        private void ProcessOrder_Click(object sender, 
            RoutedEventArgs e)
        {
            var order = Orders.SelectedItem as Order ?? new();

            var receipt = new ReceiptWindow(Processor);
            receipt.Owner = this;
            receipt.Show();

            Processor.Process(order);
        }
    }
}
