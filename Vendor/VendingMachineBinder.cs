using System.Collections.Generic;
using Vendor.StateMachine;
using Vendor.ViewModels;

namespace Vendor.VendingStateMachine
{
    internal sealed class VendingMachineBinder
    {
        private StateMachine<Inputs, Outputs, StateTypes> stateMachine { get; }
        private Dictionary<Outputs, IViewModel> viewModelByOutput { get; }

        public VendingMachineBinder(StateMachine<Inputs, Outputs, StateTypes> stateMachine)
        {
            this.stateMachine = stateMachine;
            viewModelByOutput = new Dictionary<Outputs, IViewModel>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="input"></param>
        /// <param name="output"></param>
        public void Bind(IViewModel viewModel, Inputs? input, Outputs? output)
        {
            if(output.HasValue)
                viewModelByOutput[output.Value] = viewModel;
            if (input.HasValue)
                viewModel.OnAction += () => OnAction(input.Value);
        }

        private void OnAction(Inputs input)
        {
            var output = stateMachine.Handle(input);
            if (output != Outputs.None)
                viewModelByOutput[output].Switch();
        }
    }
}
