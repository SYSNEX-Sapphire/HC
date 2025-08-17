using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SapphireXR_App.Models;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace SapphireXR_App.ViewModels
{
    internal partial class TriggeredWarningAlarmViewModel: ObservableObject
    {
        internal TriggeredWarningAlarmViewModel(PLCService.TriggerType type)
        {
            IconSource = (type == PLCService.TriggerType.Alarm) ? "/Resources/icons/icon=alert_red.png" : "/Resources/icons/icon=alert_yellow.png";
            TitleColor = (type == PLCService.TriggerType.Alarm) ? new SolidColorBrush(Color.FromRgb(0xEC, 0x3D, 0x3F)) : new SolidColorBrush(Color.FromRgb(0xFF, 0x8D, 0x60));
            Title = type.ToString();
            Message = "Please check the " + Title.ToLower() + " events";

            resetToPLC = (type == PLCService.TriggerType.Alarm) ? PLCService.WriteAlarmReset : PLCService.WriteWarningReset;
            refreshOnListFunc = (type == PLCService.TriggerType.Alarm) ? refreshAlarmList : refreshWarningList;
            OnList = refreshOnListFunc(type);

            onListUpdater = new DispatcherTimer();
            onListUpdater.Interval = new TimeSpan(TimeSpan.TicksPerMillisecond * 500);
            onListUpdater.Tick += (sender, args) =>
            {
                OnList = refreshOnListFunc(type);
            };
            onListUpdater.Start();
        }

        private static string? GetAnalogDeviceNotificationName(uint index)
        {
            string key;
            switch (index)
            {
                case 0:
                    key = "M01";
                    break;

                case 1:
                    key = "M02";
                    break;

                case 2:
                    key = "M03";
                    break;

                case 3:
                    key = "M04";
                    break;

                case 4:
                    key = "M05";
                    break;

                case 5:
                    key = "M06";
                    break;

                case 6:
                    key = "M07";
                    break;

                case 7:
                    key = "M08";
                    break;

                case 8:
                    key = "M09";
                    break;

                case 9:
                    key = "M10";
                    break;

                case 10:
                    key = "M11";
                    break;

                case 11:
                    key = "M12";
                    break;

                case 12:
                    key = "F01";
                    break;

                case 13:
                    key = "F02";
                    break;

                case 14:
                    key = "F03";
                    break;

                case 15:
                    key = "F04";
                    break;

                case 16:
                    key = "F05";
                    break;

                case 17:
                    key = "F06";
                    break;

                default:
                    return null;
            }

            AnalogDeviceIO? analogDeviceIO = null;
            if(SettingViewModel.dAnalogDeviceIO.TryGetValue(key, out analogDeviceIO) == true)
            {
                return analogDeviceIO.Name;
            }
            else
            {
                return null;
            }
        }


        private List<string> refreshAlarmList(PLCService.TriggerType triggerType)
        {
            return new List<string>();
           //return refreshOnList(PLCService.ReadDigitalDeviceAlarms, PLCService.ReadAnalogDeviceAlarms, triggerType, KeysAlarmEventLogged);
        }

        private List<string> refreshWarningList(PLCService.TriggerType triggerType)
        {
            return new List<string>();
            //return refreshOnList(PLCService.ReadDigitalDeviceWarnings, PLCService.ReadAnalogDeviceWarnings, triggerType, KeysWarningEventLogged);
        }

        private List<string> refreshOnList(Func<int> plcServiceReadAnalogState, PLCService.TriggerType triggerType, HashSet<string> keysEventLogged)
        {
            List<string> onList = new List<string>();

            int analogDeviceAlarms = plcServiceReadAnalogState();
            for(uint analogDevice = 0; analogDevice < PLCService.NumAnalogDevice; ++analogDevice)
            {
                string? notificationName = GetAnalogDeviceNotificationName(analogDevice);
                if (notificationName != null)
                {
                    if (PLCService.ReadBit(analogDeviceAlarms, (int)analogDevice) == true)
                    {
                        string message = notificationName + " Deviation!";
                        onList.Add(message);
                        if (keysEventLogged.Contains(notificationName) == false)
                        {
                            EventLogs.Instance.EventLogList.Add(new EventLog()
                            {
                                Date = DateTime.Now,
                                Message = message,
                                Name = (triggerType == PLCService.TriggerType.Alarm) ? "Analog Alarm" : "Analog Warning",
                                Type = (triggerType == PLCService.TriggerType.Alarm) ? EventLog.LogType.Alarm : EventLog.LogType.Warning
                            });
                            keysEventLogged.Add(notificationName);
                        }
                    }
                    else
                    {
                        keysEventLogged.Remove(notificationName);
                    }
                }
            }

            return onList;
        }


        [RelayCommand]
        private void Close(Window window)
        {
            resetToPLC();
            onListUpdater.Stop();
            window.Close();
        }

        [RelayCommand]
        private void Reset()
        {
            resetToPLC();
        }

        public string IconSource { get; set; }
        public string Title { get; set; }
        public Brush TitleColor { get; set; }
        public string Message { get; set; }

        [ObservableProperty]
        private List<string> _onList;

        private Action resetToPLC;
        private Func<PLCService.TriggerType, List<string>> refreshOnListFunc;
        private static HashSet<string> KeysAlarmEventLogged = new HashSet<string>();
        private static HashSet<string> KeysWarningEventLogged = new HashSet<string>();

        private DispatcherTimer onListUpdater;
    }
}
