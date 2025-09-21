using System.Collections;

namespace SapphireXR_App.Models
{
    public static partial class PLCService
    {
        private static void ReadValveStateFromPLC()
        {
            uint aReadValveStatePLC = (uint)Ads.ReadAny(hReadValveStatePLC, typeof(uint)); // Convert to Array

            baReadValveStatePLC = new BitArray([(int)aReadValveStatePLC]);
        }

        private static void ReadInitialStateValueFromPLC()
        {
            ReadValveStateFromPLC();
            ReadCurrentValueFromPLC();
        }

        private static void ReadCurrentValueFromPLC()
        {
            aDeviceCurrentValues = Ads.ReadAny<float[]>(hDeviceCurrentValuePLC, [NumControllers]);
            aDeviceControlValues = Ads.ReadAny<float[]>(hDeviceControlValuePLC, [NumControllers]);
            ReadValveStateFromPLC();
        }

        public static float ReadCurrentValue(string controllerID)
        {
            if (aDeviceCurrentValues != null)
            {
                return aDeviceCurrentValues[dIndexController[controllerID]];
            }
            else
            {
                throw new InvalidOperationException("DeviceCurrenValues array in PLCServce have not been initialized.");
            }
        }

        public static float ReadControlValue(string controllerID)
        {
            if (aDeviceControlValues != null)
            {
                return aDeviceControlValues[dIndexController[controllerID]];
            }
            else
            {
                throw new InvalidOperationException("DeviceControlValues array in PLCServce have not been initialized.");
            }
        }


        public static short ReadUserState()
        {
            int length = userStateBuffer.Length;
            Ads.Read(hUserState, userStateBuffer);
            return BitConverter.ToInt16(userStateBuffer.Span);
        }

        public static bool ReadBit(int bitField, int bit)
        {
            int bitMask = 1 << bit;
            return ((bitField & bitMask) != 0) ? true : false;
        }

        public static float ReadMFCControllerTargetValue(string controllerID)
        {
            return Ads.ReadAny<RampGeneratorInput>(hMFCControllerInput[dIndexController[controllerID]]).targetValue / GetTargetValueMappingFactor(controllerID);
        }

        public static float ReadFurnaceTempTargetValue(string controllerID)
        {
            return Ads.ReadAny<RampGeneratorInput>(hMFCControllerInput[dIndexController[controllerID] - NumMFCControllers]).targetValue;
        }

        public static short ReadCurrentStep()
        {
            return Ads.ReadAny<short>(hRcpStepN);
        }
    }
}
