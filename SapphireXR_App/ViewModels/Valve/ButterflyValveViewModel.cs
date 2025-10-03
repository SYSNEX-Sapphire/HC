using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;

namespace SapphireXR_App.ViewModels
{
    internal partial class ButterflyValveViewModel : ValveViewModel
    {
        protected override void OnClicked()
        {
        }

        [ObservableProperty]
        private bool isControlv = false;

        [ObservableProperty]
        private int setValue = 0;
    }
}
