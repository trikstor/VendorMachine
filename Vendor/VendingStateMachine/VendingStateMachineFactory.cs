using Vendor.StateMachine;

namespace Vendor
{
    internal class VendingStateMachineFactory
    {
        public StateMachine<Inputs, Outputs, StateTypes> Create()
        {
            var stateMachineBuilder = new StateMachineBuilder<Inputs, Outputs, StateTypes>();

            stateMachineBuilder.AddState(StateTypes.Z1);
            stateMachineBuilder.AddState(StateTypes.Z2);
            stateMachineBuilder.AddState(StateTypes.Z3);
            stateMachineBuilder.AddState(StateTypes.Z4);

            stateMachineBuilder.AddTransition(StateTypes.Z1, Inputs.X1, Outputs.Y1, StateTypes.Z2);
            stateMachineBuilder.AddTransition(StateTypes.Z1, Inputs.X4, Outputs.Y1, StateTypes.Z1);
            stateMachineBuilder.AddTransition(StateTypes.Z1, Inputs.X2, Outputs.Y1, StateTypes.Z1);
            stateMachineBuilder.AddTransition(StateTypes.Z1, Inputs.X3, Outputs.Y1, StateTypes.Z1);
            stateMachineBuilder.AddTransition(StateTypes.Z1, Inputs.X5, Outputs.Y1, StateTypes.Z1);

            stateMachineBuilder.AddTransition(StateTypes.Z2, Inputs.X2, Outputs.Y2, StateTypes.Z1);
            stateMachineBuilder.AddTransition(StateTypes.Z2, Inputs.X1, Outputs.Y2, StateTypes.Z2);
            stateMachineBuilder.AddTransition(StateTypes.Z2, Inputs.X3, Outputs.Y3, StateTypes.Z3);
            stateMachineBuilder.AddTransition(StateTypes.Z2, Inputs.X4, Outputs.Y4, StateTypes.Z4);
            stateMachineBuilder.AddTransition(StateTypes.Z2, Inputs.X5, Outputs.Y1, StateTypes.Z2);

            stateMachineBuilder.AddTransition(StateTypes.Z3, Inputs.X5, Outputs.Y3, StateTypes.Z1);
            stateMachineBuilder.AddTransition(StateTypes.Z3, Inputs.X1, Outputs.Y2, StateTypes.Z3);
            stateMachineBuilder.AddTransition(StateTypes.Z3, Inputs.X4, Outputs.Y1, StateTypes.Z3);
            stateMachineBuilder.AddTransition(StateTypes.Z3, Inputs.X2, Outputs.Y1, StateTypes.Z3);
            stateMachineBuilder.AddTransition(StateTypes.Z3, Inputs.X3, Outputs.Y1, StateTypes.Z3);

            stateMachineBuilder.AddTransition(StateTypes.Z4, Inputs.X5, Outputs.Y4, StateTypes.Z1);
            stateMachineBuilder.AddTransition(StateTypes.Z4, Inputs.X1, Outputs.Y2, StateTypes.Z4);
            stateMachineBuilder.AddTransition(StateTypes.Z4, Inputs.X4, Outputs.Y1, StateTypes.Z4);
            stateMachineBuilder.AddTransition(StateTypes.Z4, Inputs.X2, Outputs.Y1, StateTypes.Z4);
            stateMachineBuilder.AddTransition(StateTypes.Z4, Inputs.X3, Outputs.Y1, StateTypes.Z4);

            return stateMachineBuilder.Build(StateTypes.Z1);
        }
    }
}
