using Vendor.StateMachine;

namespace Vendor
{
    internal class VendingStateMachineFactory
    {
        public StateMachine<Inputs, Outputs, StateTypes> Create()
        {
            var stateMachineBuilder = new StateMachineBuilder<Inputs, Outputs, StateTypes>();

            stateMachineBuilder.AddState(StateTypes.Waiting);
            stateMachineBuilder.AddState(StateTypes.Payed);
            stateMachineBuilder.AddState(StateTypes.MakingTea);
            stateMachineBuilder.AddState(StateTypes.MakingCoffe);

            stateMachineBuilder.AddTransition(StateTypes.Waiting, Inputs.InsertMoney, Outputs.None, StateTypes.Payed);
            stateMachineBuilder.AddTransition(StateTypes.Waiting, Inputs.PressCoffee, Outputs.None, StateTypes.Waiting);
            stateMachineBuilder.AddTransition(StateTypes.Waiting, Inputs.PressRefund, Outputs.None, StateTypes.Waiting);
            stateMachineBuilder.AddTransition(StateTypes.Waiting, Inputs.PressTea, Outputs.None, StateTypes.Waiting);
            stateMachineBuilder.AddTransition(StateTypes.Waiting, Inputs.TakeDrink, Outputs.None, StateTypes.Waiting);

            stateMachineBuilder.AddTransition(StateTypes.Payed, Inputs.PressRefund, Outputs.Money, StateTypes.Waiting);
            stateMachineBuilder.AddTransition(StateTypes.Payed, Inputs.InsertMoney, Outputs.Money, StateTypes.Payed);
            stateMachineBuilder.AddTransition(StateTypes.Payed, Inputs.PressTea, Outputs.Tea, StateTypes.MakingTea);
            stateMachineBuilder.AddTransition(StateTypes.Payed, Inputs.PressCoffee, Outputs.Coffee, StateTypes.MakingCoffe);
            stateMachineBuilder.AddTransition(StateTypes.Payed, Inputs.TakeDrink, Outputs.None, StateTypes.Payed);

            stateMachineBuilder.AddTransition(StateTypes.MakingTea, Inputs.TakeDrink, Outputs.Tea, StateTypes.Waiting);
            stateMachineBuilder.AddTransition(StateTypes.MakingTea, Inputs.InsertMoney, Outputs.Money, StateTypes.MakingTea);
            stateMachineBuilder.AddTransition(StateTypes.MakingTea, Inputs.PressCoffee, Outputs.None, StateTypes.MakingTea);
            stateMachineBuilder.AddTransition(StateTypes.MakingTea, Inputs.PressRefund, Outputs.None, StateTypes.MakingTea);
            stateMachineBuilder.AddTransition(StateTypes.MakingTea, Inputs.PressTea, Outputs.None, StateTypes.MakingTea);

            stateMachineBuilder.AddTransition(StateTypes.MakingCoffe, Inputs.TakeDrink, Outputs.Coffee, StateTypes.Waiting);
            stateMachineBuilder.AddTransition(StateTypes.MakingCoffe, Inputs.InsertMoney, Outputs.Money, StateTypes.MakingCoffe);
            stateMachineBuilder.AddTransition(StateTypes.MakingCoffe, Inputs.PressCoffee, Outputs.None, StateTypes.MakingCoffe);
            stateMachineBuilder.AddTransition(StateTypes.MakingCoffe, Inputs.PressRefund, Outputs.None, StateTypes.MakingCoffe);
            stateMachineBuilder.AddTransition(StateTypes.MakingCoffe, Inputs.PressTea, Outputs.None, StateTypes.MakingCoffe);

            return stateMachineBuilder.Build(StateTypes.Waiting);
        }
    }
}
