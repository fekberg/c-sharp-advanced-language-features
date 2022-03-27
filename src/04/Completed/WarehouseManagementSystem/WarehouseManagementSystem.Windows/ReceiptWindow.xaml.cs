using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WarehouseManagementSystem.Business;

namespace WarehouseManagementSystem.Windows
{
    /// <summary>
    /// Interaction logic for ReceiptWindow.xaml
    /// </summary>
    public partial class ReceiptWindow : Window
    {
        private readonly OrderProcessor processor;

        public ReceiptWindow(OrderProcessor processor)
        {
            InitializeComponent();
            this.processor = processor;
            this.processor.OrderCreated += Processor_OrderCreated;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.processor.OrderCreated -= Processor_OrderCreated;
            base.OnClosing(e);
        }

        private void Processor_OrderCreated(object sender,
            OrderCreatedEventArgs args)
        {
            MessageBox.Show($"Processed {args.Order.OrderNumber}");
        }
    }
}
