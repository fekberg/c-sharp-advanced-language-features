using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace WarehouseManagementSystem.MacOS
{
    public partial class ReceiptWindow : Window
    {
        public ReceiptWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
