using System.Collections.Generic;

namespace Vendor.StateMachine
{
    public class StateMachineBuilder<TInput, TOutput, TStateType>
    {
        private Dictionary<TStateType, State<TInput, TOutput, TStateType>> stateByType { get; }

        public StateMachineBuilder()
        {
            stateByType = new Dictionary<TStateType, State<TInput, TOutput, TStateType>>();
        }

        public void AddState(TStateType stateType)
        {
            stateByType[stateType] = new State<TInput, TOutput, TStateType>(stateType);
        }

        public void AddTransition(TStateType currentStateType, TInput input, TOutput output, TStateType nextStateType)
        {
            stateByType[currentStateType].AddTransition(
                new Transition<TInput, TOutput, TStateType>(
                    input, output, stateByType[nextStateType]));
        }

        public StateMachine<TInput, TOutput, TStateType> Build(TStateType startStateType)
        {
            return new StateMachine<TInput, TOutput, TStateType>(stateByType[startStateType]);
        }
    }
}
