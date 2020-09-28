namespace Vendor.StateMachine
{
    public sealed class StateMachine<TInput, TOutput, TStateType>
    {
        public StateMachine(State<TInput, TOutput, TStateType> startState)
        {
            currentState = startState;
        }

        private State<TInput, TOutput, TStateType> currentState { get; set; }

        public TOutput Handle(TInput input)
        {
            var transition = currentState.GetTransition(input);
            currentState = transition.NextState;
            return transition.Output;
        }
    }
}
