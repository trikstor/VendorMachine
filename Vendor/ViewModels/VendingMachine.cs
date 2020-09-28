namespace Vendor.ViewModels
{
    internal sealed class VendingMachine
    {
        public VendingMachine()
        {
            TeaCup = new Cup();
            CoffeeCup = new Cup();
            CoinAcceptor = new StaticViewModel();
            TeaButton = new StaticViewModel();
            CoffeeButton = new StaticViewModel();
            RefundButton = new StaticViewModel();
            ExtraCoin = new ExtraCoin();
        }

        public Cup TeaCup { get; }
        public Cup CoffeeCup { get; }
        public StaticViewModel CoinAcceptor { get; }
        public StaticViewModel TeaButton { get;}
        public StaticViewModel CoffeeButton { get; }
        public StaticViewModel RefundButton { get; }
        public ExtraCoin ExtraCoin { get; }
    }
}
