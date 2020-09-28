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
        /// Привязать к модели входы и выходы автомата
        /// </summary>
        /// <param name="viewModel">Презентационная модель</param>
        /// <param name="input">Поступает в автомат, если вызвано событие презентационной модели</param>
        /// <param name="output">Если на выходе автомата это значение, то изменяется состояние презентационной модели</param>
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
            if (output != Outputs.Y1)
                viewModelByOutput[output].Switch();
        }
    }
}
