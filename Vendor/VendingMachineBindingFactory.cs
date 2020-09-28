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
            binder.Bind(vendingMachineViewModel.TeaCup, Inputs.X5, Outputs.Y3);
            binder.Bind(vendingMachineViewModel.CoffeeCup, Inputs.X5, Outputs.Y4);
            binder.Bind(vendingMachineViewModel.TeaButton, Inputs.X3, Outputs.Y1);
            binder.Bind(vendingMachineViewModel.CoffeeButton, Inputs.X4, Outputs.Y1);
            binder.Bind(vendingMachineViewModel.RefundButton, Inputs.X2, Outputs.Y1);
            binder.Bind(vendingMachineViewModel.CoinAcceptor, Inputs.X1, Outputs.Y1);
            binder.Bind(vendingMachineViewModel.ExtraCoin, null, Outputs.Y2);
        }
    }
}
