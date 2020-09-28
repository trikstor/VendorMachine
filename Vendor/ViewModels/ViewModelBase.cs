using System;

namespace Vendor.ViewModels
{
    internal abstract class ViewModelBase : IViewModel
    {
        public PassEventCommand Command => new PassEventCommand(OnAction);

        public event Action OnAction;

        public abstract void Switch();
    }
}
