using Vendor.StateMachine;
using Vendor.VendingStateMachine;
using Vendor.ViewModels;

namespace Vendor
{
    internal sealed class VendingMachineBindingFactory
    {
        public void Create(VendingMachine vendingMachineViewModel, StateMachine<Inputs, Outputs, StateTypes> stateMachine)
        {
            var binder = new VendingMachineBinder(stateMachine);
            binder.Bind(vendingMachineViewModel.TeaCup, Inputs.TakeDrink, Outputs.Tea);
            binder.Bind(vendingMachineViewModel.CoffeeCup, Inputs.TakeDrink, Outputs.Coffee);
            binder.Bind(vendingMachineViewModel.TeaButton, Inputs.PressTea, Outputs.None);
            binder.Bind(vendingMachineViewModel.CoffeeButton, Inputs.PressCoffee, Outputs.None);
            binder.Bind(vendingMachineViewModel.RefundButton, Inputs.PressRefund, Outputs.None);
            binder.Bind(vendingMachineViewModel.CoinAcceptor, Inputs.InsertMoney, Outputs.None);
            binder.Bind(vendingMachineViewModel.ExtraCoin, null, Outputs.Money);
        }
    }
}
