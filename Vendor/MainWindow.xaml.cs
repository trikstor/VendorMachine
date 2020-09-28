using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Vendor.VendingStateMachine;
using Vendor.ViewModels;

namespace Vendor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vendingMachineViewModel = new VendingMachine();
            var stateMachine = new VendingStateMachineFactory().Create();
            new VendingMachineBindingFactory().Create(vendingMachineViewModel, stateMachine);

            DataContext = vendingMachineViewModel;
        }

        private void coinImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var img = (Image)sender;
            DragDrop.DoDragDrop(img, img, DragDropEffects.Copy);
        }

        private void coinAcceptor_Drop(object sender, DragEventArgs e)
        {
            ((VendingMachine)DataContext).CoinAcceptor.Command.Execute(null);
        }

        private void ExtraCoin_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((VendingMachine)DataContext).ExtraCoin.Collapse();
        }
    }
}
