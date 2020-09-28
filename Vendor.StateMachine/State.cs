using System;
using System.Collections.Generic;

namespace Vendor.StateMachine
{
    public sealed class State<TInput, TOutput, TStateType>
    {
        public State(TStateType stateType)
        {
            StateType = stateType;
            transitionByInput = new Dictionary<TInput, Transition<TInput, TOutput, TStateType>>();
        }

        public TStateType StateType { get; }
        private Dictionary<TInput, Transition<TInput, TOutput, TStateType>> transitionByInput { get; set; }

        public void AddTransition(Transition<TInput, TOutput, TStateType> transition)
        {
            transitionByInput[transition.Input] = transition;
        }

        public Transition<TInput, TOutput, TStateType> GetTransition(TInput input)
        {
            if (!transitionByInput.ContainsKey(input))
                throw new ApplicationException($"В состоянии {StateType} не объявлены переходы для всего входного алфавита");
            return transitionByInput[input];
        }
    }
}
