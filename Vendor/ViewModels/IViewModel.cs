using System;

namespace Vendor.ViewModels
{
    internal interface IViewModel
    {
        PassEventCommand Command { get; }
        event Action OnAction;
        void Switch();
    }
}
