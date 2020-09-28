namespace Vendor.StateMachine
{
    public sealed class Transition<TInput, TOutput, TStateType>
    {
        public Transition(TInput input, TOutput output, State<TInput, TOutput, TStateType> nextState)
        {
            Input = input;
            Output = output;
            NextState = nextState;
        }

        public TInput Input { get; }
        public TOutput Output { get; }
        public State<TInput, TOutput, TStateType> NextState { get; }
    }
}
