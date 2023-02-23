namespace BatteryIcon.Pointers.Offsets.V2022_1129
{
    internal static class Bloody7
    {
        // Bloody7 Version 2022.0408

        /// <summary>
        /// Ready to read, relative to bloody7.exe main module base address
        /// </summary>
        internal enum StaticAddresses
        {
            Connection = 0x0103D8AC, // Checked
            SleepTimeOut = 0x0103EACA, // Checked
            Channel = 0x0103EAC4, // Checked
            WakeUpState = 0x0103EAC8, // Checked
            LightBrightness = 0x0103EAF4, // Checked
            CurrentMouseID = 0x0103D8B4, // Checked
            LastMouseID = 0x0103D924, // Checked

            Flag_RFSynchronize = 0x0103EAC0, // Checked
            Flag_ZeroFrequencyOffset = 0x0103EAC1, // Checked
            Flag_ExclusiveChanel = 0x0103EAC2, // Checked
            Flag_RFSignalDetector = 0x0103EAC6, // Checked
            Flag_TransmissionBoost = 0x0103EAC7, // Checked

            Signal = 0x00611068, // Checked
            Charging = 0x00103F3A0, // Checked

            Battery = 0x00611068, // Checked
            BatteryPercent = 0x00611068, // Checked
            LowBattery = 0x0103EACE, // Checked
        }

        /// <summary>
        /// Offsets relative to static addresses
        /// </summary>
        internal enum Offsets0
        {
            Signal = 0x00000CD4, // Checked
            Charging = 0x0000043C, // Checked

            Battery = 0x00000BFC, // Checked
            BatteryPercent = 0x00000BFD, // Checked
            LowBattery = 0x00000000, // Checked
        }
    }
}
