namespace BatteryIcon.Pointers.Offsets.V2022_0408
{
    internal static class Bloody7
    {
        // Bloody7 Version 2022.0408

        /// <summary>
        /// Ready to read, relative to bloody7.exe main module base address
        /// </summary>
        internal enum StaticAddresses
        {
            Connection = 0x00F96110,
            SleepTimeOut = 0x00F9732E,
            Channel = 0x00F97328,
            WakeUpState = 0x00F9732C,
            LightBrightness = 0x00F97358,
            CurrentMouseID = 0x00F96118,
            LastMouseID = 0x00F96188,

            Flag_RFSynchronize = 0x00F97324,
            Flag_ZeroFrequencyOffset = 0x00F97325,
            Flag_ExclusiveChanel = 0x00F97326,
            Flag_RFSignalDetector = 0x00F9732A,
            Flag_TransmissionBoost = 0x00F9732B,

            Signal = 0x00A1E87C,
            Charging = 0x00F97C08,

            Battery = 0x00DE5024,
            BatteryPercent = 0x00F97C08,
            LowBattery = 0x00F97C08,
        }

        /// <summary>
        /// Offsets relative to static addresses
        /// </summary>
        internal enum Offsets0
        {
            Signal = 0x00000F7E,
            Charging = 0x0000043C,

            Battery = 0x0000859C,
            BatteryPercent = 0x00000528,
            LowBattery = 0x00000524,
        }
    }
}
