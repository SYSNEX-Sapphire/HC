using SapphireXR_App.ViewModels.Valve;
using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;
using SapphireXR_App.Common;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SapphireXR_App.ViewModels
{
    public partial class SingleValveViewModel: OnOffValveViewModel
    {
        protected override PopupMessage getPopupMessage()
        {
            return popUpMessage;
        }

        public SingleValveViewModel(): base()
        {
            OnLoadedCommand = new RelayCommand<object?>((object? args) =>
            {
                if (args != null)
                {
                    object[] argArray = (object[])args;
                    if (4 <= argArray.Length)
                    {
                        if (argArray[0] is string && argArray[1] is Controls.Valve.UpdateTarget)
                        {
                            Init((string)argArray[0], (Controls.Valve.UpdateTarget)argArray[1]);
                            OnColor = Brushes.Lime;
                            OffColor = Brushes.White;
                            popUpMessage = CreateDefaultPopupMessage(ValveID!);
                        }
                    }
                }
            });
        }

        private static PopupMessage CreateDefaultPopupMessage(string valveID)
        {
            return new PopupMessage()
            {
                messageWithOpen = $"{valveID} 밸브를 닫으시겠습니까?",
                confirmWithOpen = $"{valveID} 밸브 닫음",
                cancelWithOpen = $"{valveID} 취소됨",
                messageWithoutOpen = $"{valveID} 밸브를 열겠습니까?",
                confirmWithoutOpen = $"{valveID} 밸브 열음",
                cancelWithoutOpen = $"{valveID} 취소됨"
            };
        }

        private PopupMessage popUpMessage = new PopupMessage() { cancelWithOpen = "", cancelWithoutOpen = "", confirmWithOpen = "", confirmWithoutOpen = "", messageWithOpen = "", messageWithoutOpen = ""};

        [ObservableProperty]
        private Brush onColor = Brushes.Lime;

        [ObservableProperty]
        private Brush offColor = Brushes.Lime;

        [ObservableProperty]
        private bool isNormallyOpen = false;
    }
}
