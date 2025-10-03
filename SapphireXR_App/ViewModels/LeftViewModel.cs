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
        public abstract partial class SourceStatusViewModel : ObservableObject, IDisposable
        {
            private class ValveStateSubscriber : IObserver<bool>
            {
                internal ValveStateSubscriber(SourceStatusViewModel vm, Action<bool> onNextValveStateAC, string valveIDStr)
                {
                    onNextValveState = onNextValveStateAC;
                    sourceStatusViewModel = vm;
                    valveID = valveIDStr;
                }

                void IObserver<bool>.OnCompleted()
                {
                    throw new NotImplementedException();
                }

                void IObserver<bool>.OnError(Exception error)
                {
                    throw new NotImplementedException();
                }

                void IObserver<bool>.OnNext(bool value)
                {
                    if (currentValveState == null || currentValveState != value)
                    {
                        onNextValveState(value);
                        currentValveState = value;
                    }
                }

                protected readonly SourceStatusViewModel sourceStatusViewModel;
                private readonly Action<bool> onNextValveState;
                public readonly string valveID;
                private bool? currentValveState = null;
            }

            public SourceStatusViewModel(LeftViewModel vm, string valveStateSubscsribePostfixStr)
            {
                PropertyChanged += (sender, args) =>
                {
                    switch (args.PropertyName)
                    {
                        case nameof(V01):
                        case nameof(V14):
                            if(V01 == true && V14 == true)
                            {
                                BackgroundInletGas = vm.Gas1;
                                BackgroundInletGasColor = Gas1Color;
                            }
                            else
                            {
                                BackgroundInletGas = "";
                            }
                            break;

                        case nameof(V02):
                        case nameof(V03):
                        case nameof(V15):
                            if (V02 == true && V15 == true)
                            {
                                GaliumBoatInletGas = vm.Gas2;
                                GaliumBoatInletGasColor = Gas2Color;
                            }
                            else if (V03 == true && V15 == true)
                            {
                                GaliumBoatInletGas = vm.Gas1;
                                GaliumBoatInletGasColor = Gas1Color;
                            }
                            else
                            {
                                GaliumBoatInletGas = "";
                            }
                            break;

                        case nameof(V04):
                        case nameof(V05):
                        case nameof(V16):
                            if (V04 == true && V16 == true)
                            {
                                AmmoniaInletTubeGas = vm.Gas3;
                                AmmoniaInletTubeGasColor = Gas3Color;
                            }
                            else if (V05 == true && V16 == true)
                            {
                                AmmoniaInletTubeGas = vm.Gas1;
                                AmmoniaInletTubeGasColor = Gas1Color;
                            }
                            else
                            {
                                AmmoniaInletTubeGas = "";
                            }
                            break;

                        case nameof(V06):
                        case nameof(V07):
                        case nameof(V17):
                            if (V06 == true && V17 == true)
                            {
                                AluminuimBoatInletGas = vm.Gas2;
                                AluminuimBoatInletGasColor = Gas2Color;
                            }
                            else if (V07 == true && V17 == true)
                            {
                                AluminuimBoatInletGas = vm.Gas1;
                                AluminuimBoatInletGasColor = Gas1Color;
                            }
                            else
                            {
                                AluminuimBoatInletGas = "";
                            }
                            break;

                        case nameof(V08):
                        case nameof(V09):
                        case nameof(V18):
                            if (V08 == true && V18 == true)
                            {
                                EtchingTubeInletGas = vm.Gas2;
                                EtchingTubeInletGasColor = Gas2Color;
                            }
                            else if (V09 == true && V18 == true)
                            {
                                EtchingTubeInletGas = vm.Gas1;
                                EtchingTubeInletGasColor = Gas1Color;
                            }
                            else
                            {
                                EtchingTubeInletGas = "";
                            }
                            break;

                        case nameof(V10):
                        case nameof(V11):
                        case nameof(V19):
                            if (V10 == true && V19 == true)
                            {
                                H2O2InletGas = vm.Gas4;
                                H2O2InletGasColor = Gas4Color;
                            }
                            else if (V11 == true && V19 == true)
                            {
                                H2O2InletGas = vm.Gas1;
                                H2O2InletGasColor = Gas1Color;
                            }
                            else
                            {
                                H2O2InletGas = "";
                            }
                            break;

                        case nameof(V12):
                        case nameof(V20):
                            if(V12 == true && V20 == true)
                            {
                                BackFlangeInletGas = vm.Gas1;
                                BackFlangeInletGasColor = Gas1Color;
                            }
                            else
                            {
                                BackFlangeInletGas = "";
                            }
                            break;
                    }
                };
             
                valveStateSubscsribePostfix = valveStateSubscsribePostfixStr;
                valveStateSubscrbers = [
                    new ValveStateSubscriber(this, (bool nextValveState) => V01 = nextValveState, "V01"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V02 = nextValveState, "V02"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V03 = nextValveState, "V03"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V04 = nextValveState, "V04"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V05 = nextValveState, "V05"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V06 = nextValveState, "V06"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V07 = nextValveState, "V07"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V08 = nextValveState, "V08"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V09 = nextValveState, "V09"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V10 = nextValveState, "V10"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V11 = nextValveState, "V11"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V12 = nextValveState, "V12"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V14 = nextValveState, "V14"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V15 = nextValveState, "V15"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V16 = nextValveState, "V16"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V17 = nextValveState, "V17"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V18 = nextValveState, "V18"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V19 = nextValveState, "V19"),
                    new ValveStateSubscriber(this, (bool nextValveState) => V20 = nextValveState, "V20")
                ];
                foreach (ValveStateSubscriber valveStateSubscriber in valveStateSubscrbers)
                {
                    unsubscribers.Add(ObservableManager<bool>.Subscribe("Valve.OnOff." + valveStateSubscriber.valveID + "." + valveStateSubscsribePostfix, valveStateSubscriber));
                }
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        foreach (IDisposable unsubscriber in unsubscribers)
                        {
                            unsubscriber.Dispose();
                        }
                        unsubscribers.Clear();
                    }

                    // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                    // TODO: 큰 필드를 null로 설정합니다.
                    disposedValue = true;
                }
            }

            void IDisposable.Dispose()
            {
                // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }

            public void dispose()
            {
                Dispose(disposing: true);
            }

            private static readonly Brush Gas1Color = Application.Current.Resources.MergedDictionaries[0]["NitrogenLineColor"] as Brush ?? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xCC));
            private static readonly Brush Gas2Color = Application.Current.Resources.MergedDictionaries[0]["HClLineColor"] as Brush ?? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xCC));
            private static readonly Brush Gas3Color = Application.Current.Resources.MergedDictionaries[0]["NH3LineColor"] as Brush ?? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xCC));
            private static readonly Brush Gas4Color = Application.Current.Resources.MergedDictionaries[0]["DCSLineColor"] as Brush ?? new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xCC));

            private readonly ValveStateSubscriber[] valveStateSubscrbers;
            private IList<IDisposable> unsubscribers = new List<IDisposable>();
            private readonly string valveStateSubscsribePostfix;

            private bool disposedValue = false;

            [ObservableProperty]
            private bool v01 = false;

            [ObservableProperty]
            private bool v02 = false;

            [ObservableProperty]
            private bool v03 = false;

            [ObservableProperty]
            private bool v04 = false;

            [ObservableProperty]
            private bool v05 = false;

            [ObservableProperty]
            private bool v06 = false;

            [ObservableProperty]
            private bool v07 = false;

            [ObservableProperty]
            private bool v08 = false;

            [ObservableProperty]
            private bool v09 = false;

            [ObservableProperty]
            private bool v10 = false;

            [ObservableProperty]
            private bool v11 = false;

            [ObservableProperty]
            private bool v12 = false;

            [ObservableProperty]
            private bool v14 = false;

            [ObservableProperty]
            private bool v15 = false;

            [ObservableProperty]
            private bool v16 = false;

            [ObservableProperty]
            private bool v17 = false;

            [ObservableProperty]
            private bool v18 = false;

            [ObservableProperty]
            private bool v19 = false;

            [ObservableProperty]
            private bool v20 = false;

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
        }

        public class SourceStatusFromCurrentPLCStateViewModel : SourceStatusViewModel
        {
            public SourceStatusFromCurrentPLCStateViewModel(LeftViewModel vm) : base(vm, "CurrentPLCState") { }
        }

        public class SourceStatusFromCurrentRecipeStepViewModel : SourceStatusViewModel
        {
            public SourceStatusFromCurrentRecipeStepViewModel(LeftViewModel vm) : base(vm, "CurrentRecipeStep") { }

            public void reset()
            {
                GaliumBoatInletGas = "";
                BackFlangeInletGas = "";
                AmmoniaInletTubeGas = "";
                AluminuimBoatInletGas = "";
                EtchingTubeInletGas = "";
                H2O2InletGas = "";
                BackgroundInletGas = "";
            }
        }
        public LeftViewModel()
        {
            //ObservableManager<float>.Subscribe("MonitoringPresentValue.ShowerHeadTemp.CurrentValue", showerHeaderTempSubscriber = new CoolingWaterValueSubscriber("ShowerHeadTemp", this));
            //ObservableManager<float>.Subscribe("MonitoringPresentValue.InductionCoilTemp.CurrentValue", inductionCoilTempSubscriber = new CoolingWaterValueSubscriber("InductionCoilTemp", this));
            //ObservableManager<BitArray>.Subscribe("HardWiringInterlockState", hardWiringInterlockStateSubscriber = new HardWiringInterlockStateSubscriber(this));
            ObservableManager<int>.Subscribe("MainView.SelectedTabIndex", mainViewTabIndexChagedSubscriber = new MainViewTabIndexChagedSubscriber(this));
            //ObservableManager<BitArray>.Subscribe("DeviceIOList", signalTowerStateSubscriber = new SignalTowerStateSubscriber(this));
            //ObservableManager<float[]>.Subscribe("LineHeaterTemperature", lineHeaterTemperatureSubscriber = new LineHeaterTemperatureSubscriber(this));
            ObservableManager<bool>.Subscribe("Reset.CurrentRecipeStep", resetCurrentRecipeSubscriber = new ResetCurrentRecipeSubscriber(this));
            //ObservableManager<BitArray>.Subscribe("LogicalInterlockState", logicalInterlockSubscriber = new LogicalInterlockSubscriber(this));
            ObservableManager<(string, string)>.Subscribe("GasIOLabelChanged", gasIOLabelSubscriber = new GasIOLabelSubscriber(this));
            ObservableManager<PLCConnection>.Subscribe("PLCService.Connected", plcConnectionStateSubscriber = new PLCConnectionStateSubscriber(this)); 
            ObservableManager<short>.Subscribe("SignalTowerLight", signalTowerLightSubscriber = new SignalTowerLightSubscriber(this));

            CurrentSourceStatusViewModel = getSourceStatusFromCurrentPLCStateViewModel();
          
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

        public SourceStatusViewModel getSourceStatusFromCurrentPLCStateViewModel()
        {
            return (sourceStatusFromCurrentPLCStateViewModel ??= new SourceStatusFromCurrentPLCStateViewModel(this));
        }

        public SourceStatusViewModel getSourceStatusFromCurrentRecipeStepViewModel()
        {
            return (sourceStatusFromCurrentRecipeStepViewModel ??= new SourceStatusFromCurrentRecipeStepViewModel(this));
        }


        [ObservableProperty]
        private static string _logicalInterlockGas1 = GetIogicalInterlockLabel(Util.GetGasDeviceName("Gas1"));
        [ObservableProperty]
        private static string _logicalInterlockGas2 = GetIogicalInterlockLabel(Util.GetGasDeviceName("Gas2"));
        [ObservableProperty]
        private static string _logicalInterlockGas3 = GetIogicalInterlockLabel(Util.GetGasDeviceName("Gas3"));
        [ObservableProperty]
        private static string _logicalInterlockGas4 = GetIogicalInterlockLabel(Util.GetGasDeviceName("Gas4"));

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


        [ObservableProperty]
        private string gas1 = Util.GetGasDeviceName("Gas1") ?? "";
        [ObservableProperty]
        private string gas2 = Util.GetGasDeviceName("Gas2") ?? "";
        [ObservableProperty]
        private string gas3 = Util.GetGasDeviceName("Gas3") ?? "";
        [ObservableProperty]
        private string gas4 = Util.GetGasDeviceName("Gas4") ?? "";

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
        private string _pLCAddressText = AmsNetId.Local.ToString();
        [ObservableProperty]
        private string _pLCConnectionStatus = "Diconnected";
        [ObservableProperty]
        private Brush _pLCConnectionStatusColor = PLCDisconnectedFontColor;

        [ObservableProperty]
        private SourceStatusViewModel _currentSourceStatusViewModel;

        [ObservableProperty]
        private string signalTowerImage = SignalTowerDefaultPath;

        //private readonly CoolingWaterValueSubscriber showerHeaderTempSubscriber;
        //private readonly CoolingWaterValueSubscriber inductionCoilTempSubscriber;
        //private readonly HardWiringInterlockStateSubscriber hardWiringInterlockStateSubscriber;
        private readonly MainViewTabIndexChagedSubscriber mainViewTabIndexChagedSubscriber;
        //private readonly SignalTowerStateSubscriber signalTowerStateSubscriber;
        //private readonly LineHeaterTemperatureSubscriber lineHeaterTemperatureSubscriber;
        private readonly ResetCurrentRecipeSubscriber resetCurrentRecipeSubscriber;
       // private readonly LogicalInterlockSubscriber logicalInterlockSubscriber;
        private readonly GasIOLabelSubscriber gasIOLabelSubscriber;
        private readonly PLCConnectionStateSubscriber plcConnectionStateSubscriber;
        private readonly SignalTowerLightSubscriber signalTowerLightSubscriber;

        private SourceStatusFromCurrentPLCStateViewModel? sourceStatusFromCurrentPLCStateViewModel;
        private SourceStatusFromCurrentRecipeStepViewModel? sourceStatusFromCurrentRecipeStepViewModel;
    }
}
