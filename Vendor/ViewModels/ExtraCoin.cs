using System.ComponentModel;

namespace Vendor.ViewModels
{
    internal sealed class ExtraCoin : ViewModelBase, INotifyPropertyChanged
    {
        public string Visibility => isVisible ? "Visible" : "Collapsed";
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isVisible { get; set; }

        public override void Switch()
        {
            isVisible = true;
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Visibility)));
        }

        public void Collapse()
        {
            isVisible = false;
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Visibility)));
        }
    }
}
