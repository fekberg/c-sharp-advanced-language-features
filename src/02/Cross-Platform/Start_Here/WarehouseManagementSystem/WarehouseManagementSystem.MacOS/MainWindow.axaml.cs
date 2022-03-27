using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.IO;
using System.Text.Json;
using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.MacOS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            #region Populate the UI
            var json = File.ReadAllText("orders.json");
            Orders.Items = JsonSerializer.Deserialize<Order[]>(json);
            #endregion
        }
        private void ProcessOrder_Click(object sender, RoutedEventArgs args)
        {
            var order = Orders.SelectedItem as Order ?? new();

            var receipt = new ReceiptWindow();
            receipt.ShowDialog(this);
        }
    }
}
