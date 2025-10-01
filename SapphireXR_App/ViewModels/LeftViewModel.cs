using CommunityToolkit.Mvvm.ComponentModel;
using SapphireXR_App.Common;
using System.Windows.Media;
using System.Windows;
using System.Collections;
using System.ComponentModel;
using TwinCAT.Ads;
using SapphireXR_App.Enums;
using SapphireXR_App.Models;

namespace SapphireXR_App.ViewModels
{
    public partial class LeftViewModel : ObservableObject
    {
        public LeftViewModel()
        {
            //ObservableManager<float>.Subscribe("MonitoringPresentValue.ShowerHeadTemp.CurrentValue", showerHeaderTempSubscriber = new CoolingWaterValueSubscriber("ShowerHeadTemp", this));
            //ObservableManager<float>.Subscribe("MonitoringPresentValue.InductionCoilTemp.CurrentValue", inductionCoilTempSubscriber = new CoolingWaterValueSubscriber("InductionCoilTemp", this));
            //ObservableManager<BitArray>.Subscribe("HardWiringInterlockState", hardWiringInterlockStateSubscriber = new HardWiringInterlockStateSubscriber(this));
            ObservableManager<int>.Subscribe("MainView.SelectedTabIndex", mainViewTabIndexChagedSubscriber = new MainViewTabIndexChagedSubscriber(this));
            //ObservableManager<BitArray>.Subscribe("DeviceIOList", signalTowerStateSubscriber = new SignalTowerStateSubscriber(this));
            //ObservableManager<float[]>.Subscribe("LineHeaterTemperature", lineHeaterTemperatureSubscriber = new LineHeaterTemperatureSubscriber(this));
            //ObservableManager<bool>.Subscribe("Reset.CurrentRecipeStep", resetCurrentRecipeSubscriber = new ResetCurrentRecipeSubscriber(this));
            //ObservableManager<BitArray>.Subscribe("LogicalInterlockState", logicalInterlockSubscriber = new LogicalInterlockSubscriber(this));
            //ObservableManager<(string, string)>.Subscribe("GasIOLabelChanged", gasIOLabelSubscriber = new GasIOLabelSubscriber(this));
            ObservableManager<PLCConnection>.Subscribe("PLCService.Connected", plcConnectionStateSubscriber = new PLCConnectionStateSubscriber(this)); 
            ObservableManager<short>.Subscribe("SignalTowerLight", signalTowerLightSubscriber = new SignalTowerLightSubscriber(this));
            ObservableManager<(string, bool)>.Subscribe("ValveState", valveStateSubscriber = new ValveStateSubscriber(this));

            //CurrentSourceStatusViewModel = new SourceStatusFromCurrentPLCStateViewModel(this);
            //PropertyChanging += (object? sender, PropertyChangingEventArgs args) =>
            //{
            //    switch (args.PropertyName)
            //    {
            //        case nameof(CurrentSourceStatusViewModel):
            //            CurrentSourceStatusViewModel.dispose();
            //            break;
            //    }
            //};
            PropertyChanged += (object? sender, PropertyChangedEventArgs args) =>
            {
                switch (args.PropertyName)
                {
                    case nameof(PLCConnectionStatus):
                        switch(PLCConnectionStatus)
                        {
                            case "Connected":
                                PLCConnectionStatusColor = PLCConnectedFontColor;
                                break;

                            case "Disconnected":
                                PLCConnectionStatusColor = PLCDisconnectedFontColor;
                                SignalTowerImage = SignalTowerDefaultPath;
                                break;
                        }
                        break;
                }
            };
            setConnectionStatusText(PLCService.Connected);
        }

        public static string GetGas3Label(string? gas3Name, int index)
        {
            if (gas3Name != default)
            {
                return gas3Name + "#" + index;
            }
            else
            {
                return "";
            }
        }

        public static string GetIogicalInterlockLabel(string? gasName)
        {
            if (gasName != default)
            {
                return "Gas Pressure " + gasName;
            }
            else
            {
                return "";
            }
        }

        private void setConnectionStatusText(PLCConnection connectionStatus)
        {
            switch (connectionStatus)
            {
                case PLCConnection.Connected:
                    PLCConnectionStatus = "Connected";
                    break;

                case PLCConnection.Disconnected:
                    PLCConnectionStatus = "Disconnected";
                    break;
            }
        }


        [ObservableProperty]
        private static string _logicalInterlockGas1 = GetIogicalInterlockLabel(Util.GetGasDeviceName("Gas1"));
        [ObservableProperty]
        private static string _logicalInterlockGas2 = GetIogicalInterlockLabel(Util.GetGasDeviceName("Gas2"));
        [ObservableProperty]
        private static string _logicalInterlockGas3 = GetIogicalInterlockLabel(Util.GetGasDeviceName("Gas3"));
        [ObservableProperty]
        private static string _logicalInterlockGas4 = GetIogicalInterlockLabel(Util.GetGasDeviceName("Gas4"));


        //private static readonly Brush Gas1Color = Application.Current.Resources.MergedDictionaries[0]["NitrogenLineColor"] as Brush ?? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xCC));
        //private static readonly Brush Gas2Color = Application.Current.Resources.MergedDictionaries[0]["HClLineColor"] as Brush ?? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xCC));
        //private static readonly Brush Gas3Color = Application.Current.Resources.MergedDictionaries[0]["NH3LineColor"] as Brush ?? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xCC));
        //private static readonly Brush Gas4Color = Application.Current.Resources.MergedDictionaries[0]["DCSLineColor"] as Brush ?? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xCC));

        private static readonly Brush Gas1Color = Application.Current.Resources.MergedDictionaries[0]["NitrogenLineColor"] as Brush ?? Brushes.Black;
        private static readonly Brush Gas2Color = Application.Current.Resources.MergedDictionaries[0]["HClLineColor"] as Brush ?? Brushes.Black;
        private static readonly Brush Gas3Color = Application.Current.Resources.MergedDictionaries[0]["NH3LineColor"] as Brush ?? Brushes.Black;
        private static readonly Brush Gas4Color = Application.Current.Resources.MergedDictionaries[0]["DCSLineColor"] as Brush ?? Brushes.Black;

        private static readonly Brush OnLampColor = Application.Current.Resources.MergedDictionaries[0]["LampOnColor"] as Brush ?? Brushes.Lime;
        private static readonly Brush OffLampColor = Application.Current.Resources.MergedDictionaries[0]["LampOffColor"] as Brush ?? Brushes.DarkGray;
        private static readonly Brush ReadyLampColor = Application.Current.Resources.MergedDictionaries[0]["LampReadyColor"] as Brush ?? Brushes.Yellow;
        private static readonly Brush RunLampColor = Application.Current.Resources.MergedDictionaries[0]["LampRunolor"] as Brush ?? Brushes.Lime;
        private static readonly Brush FaultLampColor = Application.Current.Resources.MergedDictionaries[0]["LampFaultColor"] as Brush ?? Brushes.Red;

        private static readonly Brush InActiveSignalTowerRed = Application.Current.Resources.MergedDictionaries[0]["InActiveSignalTowerRed"] as Brush ?? new SolidColorBrush(Color.FromRgb(0xff, 0xa0, 0xa0));
        private static readonly Brush InActiveSignalTowerYellow = Application.Current.Resources.MergedDictionaries[0]["InActiveSignalTowerYellow"] as Brush ?? new SolidColorBrush(Color.FromRgb(0xff, 0xff, 0xC5));
        private static readonly Brush InActiveSignalTowerGreen = Application.Current.Resources.MergedDictionaries[0]["InActiveSignalTowerGreen"] as Brush ?? new SolidColorBrush(Color.FromRgb(0xcd, 0xf5, 0xdd));
        private static readonly Brush InActiveSignalTowerBlue = Application.Current.Resources.MergedDictionaries[0]["InActiveSignalTowerBlue"] as Brush ?? new SolidColorBrush(Color.FromRgb(0x86, 0xCE, 0xFA));
        private static readonly Brush InActiveSignalTowerWhite = Application.Current.Resources.MergedDictionaries[0]["InActiveSignalTowerWhite"] as Brush ?? Brushes.LightGray;
        private static readonly Brush ActiveSignalTowerRed = Application.Current.Resources.MergedDictionaries[0]["ActiveSignalTowerRed"] as Brush ?? Brushes.Red;
        private static readonly Brush ActiveSignalTowerYellow = Application.Current.Resources.MergedDictionaries[0]["ActiveSignalTowerYellow"] as Brush ?? Brushes.Yellow;
        private static readonly Brush ActiveSignalTowerGreen = Application.Current.Resources.MergedDictionaries[0]["ActiveSignalTowerGreen"] as Brush ?? Brushes.Green;
        private static readonly Brush ActiveSignalTowerBlue = Application.Current.Resources.MergedDictionaries[0]["ActiveSignalTowerBlue"] as Brush ?? Brushes.Blue;
        private static readonly Brush ActiveSignalTowerWhite = Application.Current.Resources.MergedDictionaries[0]["ActiveSignalTowerWhite"] as Brush ?? Brushes.White;

        private static readonly Brush PLCConnectedFontColor = Application.Current.Resources.MergedDictionaries[0]["Sapphire_Blue"] as Brush ?? new SolidColorBrush(Color.FromRgb(0x60, 0xCD, 0xFF));
        private static readonly Brush PLCDisconnectedFontColor = Application.Current.Resources.MergedDictionaries[0]["Alert_Red_02"] as Brush ?? new SolidColorBrush(Color.FromRgb(0xEC, 0x3D, 0x3F));

        private static readonly string SignalTowerRedPath = "/Resources/icons/icon=ani_signal_red.gif";
        private static readonly string SignalTowerBluePath = "/Resources/icons/icon=ani_signal_blue.gif";
        private static readonly string SignalTowerGreenath = "/Resources/icons/icon=ani_signal_green.gif";
        private static readonly string SignalTowerYellowPath = "/Resources/icons/icon=ani_signal_yellow.gif";
        private static readonly string SignalTowerWhitePath = "/Resources/icons/icon=ani_signal_white.gif";
        private static readonly string SignalTowerDefaultPath = "/Resources/icons/icon=ani_signal_default.gif";

        private static readonly string Gas1 = Util.GetGasDeviceName("Gas1") ?? "";
        private static readonly string Gas2 = Util.GetGasDeviceName("Gas2") ?? "";
        private static readonly string Gas3 = Util.GetGasDeviceName("Gas3") ?? "";
        private static readonly string Gas4 = Util.GetGasDeviceName("Gas4") ?? "";

        [ObservableProperty]
        private string _showerHeadTemp = "";
        [ObservableProperty]
        private string _inductionCoilTemp = "";

        [ObservableProperty]
        private Brush _maintenanceKeyLampColor = OnLampColor;
        [ObservableProperty]
        private Brush _inductionHeaterLampColor = ReadyLampColor;
        [ObservableProperty]
        private Brush _cleanDryAirLampColor = OnLampColor;
        [ObservableProperty]
        private Brush _doorReactorCabinetLampColor = OnLampColor;
        [ObservableProperty]
        private Brush _doorPowerDistributeCabinetLampColor = OnLampColor;
        [ObservableProperty]
        private Brush _doorGasDeliveryCabinetLampColor = OnLampColor;
        [ObservableProperty]
        private Brush _coolingWaterLampColor = OnLampColor;
        [ObservableProperty]
        private Brush _susceptorMotorLampColor = OnLampColor;
        [ObservableProperty]
        private Brush _vacuumPumpLampColor = ReadyLampColor;
        [ObservableProperty]
        private Brush _dorVacuumStateLampColor = ReadyLampColor;
        [ObservableProperty]
        private Brush _tempControllerAlarmLampColor = OnLampColor;

        [ObservableProperty]
        private double _glowOpacity = 0.0;

        [ObservableProperty]
        private Brush _gasPressureGas2StateColor = Brushes.Transparent;
        [ObservableProperty]
        private Brush _gasPressureGas1StateColor = Brushes.Transparent;
        [ObservableProperty]
        private Brush _gasPressureGas3StateColor = Brushes.Transparent;
        [ObservableProperty]
        private Brush _gasPressureGas4StateColor = Brushes.Transparent;
        [ObservableProperty]
        private Brush _recipeStartStateColor = Brushes.Transparent;
        [ObservableProperty]
        private Brush _reactorOpenStateColor = Brushes.Transparent;
        [ObservableProperty]
        private Brush _heaterTurnOnStateColor = Brushes.Transparent;
        [ObservableProperty]
        private Brush _pumpTurnOnStateColor = Brushes.Transparent;

        [ObservableProperty]
        private int _lineHeater1;
        [ObservableProperty]
        private int _lineHeater2;
        [ObservableProperty]
        private int _lineHeater3;
        [ObservableProperty]
        private int _lineHeater4;
        [ObservableProperty]
        private int _lineHeater5;
        [ObservableProperty]
        private int _lineHeater6;
        [ObservableProperty]
        private int _lineHeater7;
        [ObservableProperty]
        private int _lineHeater8;

        [ObservableProperty]
        private string backgroundInletGas = "";
        [ObservableProperty]
        private string galiumBoatInletGas = "";
        [ObservableProperty]
        private string ammoniaInletTubeGas = "";
        [ObservableProperty]
        private string aluminuimBoatInletGas = "";
        [ObservableProperty]
        private string etchingTubeInletGas = "";
        [ObservableProperty]
        private string h2O2InletGas = "";
        [ObservableProperty]
        private string backFlangeInletGas = "";

        [ObservableProperty]
        private Brush backgroundInletGasColor = Brushes.Transparent;
        [ObservableProperty]
        private Brush galiumBoatInletGasColor = Brushes.Transparent;
        [ObservableProperty]
        private Brush ammoniaInletTubeGasColor = Brushes.Transparent;
        [ObservableProperty]
        private Brush aluminuimBoatInletGasColor = Brushes.Transparent;
        [ObservableProperty]
        private Brush etchingTubeInletGasColor = Brushes.Transparent;
        [ObservableProperty]
        private Brush h2O2InletGasColor = Brushes.Transparent;
        [ObservableProperty]
        private Brush backFlangeInletGasColor = Brushes.Transparent;

        [ObservableProperty]
        private string _pLCAddressText = AmsNetId.Local.ToString();
        [ObservableProperty]
        private string _pLCConnectionStatus = "Diconnected";
        [ObservableProperty]
        private Brush _pLCConnectionStatusColor = PLCDisconnectedFontColor;

        //[ObservableProperty]
        //private SourceStatusViewModel _currentSourceStatusViewModel;

        [ObservableProperty]
        private string signalTowerImage = SignalTowerDefaultPath;

        //private readonly CoolingWaterValueSubscriber showerHeaderTempSubscriber;
        //private readonly CoolingWaterValueSubscriber inductionCoilTempSubscriber;
        //private readonly HardWiringInterlockStateSubscriber hardWiringInterlockStateSubscriber;
        private readonly MainViewTabIndexChagedSubscriber mainViewTabIndexChagedSubscriber;
        //private readonly SignalTowerStateSubscriber signalTowerStateSubscriber;
        //private readonly LineHeaterTemperatureSubscriber lineHeaterTemperatureSubscriber;
        //private readonly ResetCurrentRecipeSubscriber resetCurrentRecipeSubscriber;
       // private readonly LogicalInterlockSubscriber logicalInterlockSubscriber;
        //private readonly GasIOLabelSubscriber gasIOLabelSubscriber;
        private readonly PLCConnectionStateSubscriber plcConnectionStateSubscriber;
        private readonly SignalTowerLightSubscriber signalTowerLightSubscriber;
        private readonly ValveStateSubscriber valveStateSubscriber;
    }
}
