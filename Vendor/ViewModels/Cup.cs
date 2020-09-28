using System.ComponentModel;

namespace Vendor.ViewModels
{
    internal sealed class Cup : ViewModelBase, INotifyPropertyChanged
    {
        public string Visibility => isVisible ? "Visible" : "Collapsed";
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isVisible { get; set; }

        public override void Switch()
        {
            isVisible = !isVisible;
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Visibility)));
        }
    }
}
