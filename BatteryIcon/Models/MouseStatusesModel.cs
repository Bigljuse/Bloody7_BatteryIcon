using System;

namespace BatteryIcon.Models
{
    public class MouseStatusesModel
    {
        public uint CurrentMouseID { get; set; } = 0;
        public uint LastMouseID { get; set; } = 0;

        public bool IsConnected { get; set; } = false;
        public bool IsCharging { get; set; } = false;

        public ushort Battery { get; set; } = 0;
        public byte BatteryPercent { get; set; } = 0;
        public byte LowBattery { get; set; } = 0;

        public byte Signal { get; set; } = 0;

        public byte SleepTimeOut { get; set; } = 0;
        public byte Channel { get; set; } = 0;
        public byte WakeUpState { get; set; } = 0;
        public byte LightBrightness { get; set; } = 0;

        public bool Flag_RFSynchronize { get; set; } = false;
        public bool Flag_ZeroFrequencyOffset { get; set; } = false;
        public bool Flag_ExclusiveChanel { get; set; } = false;
        public bool Flag_RFSignalDetector { get; set; } = false;
        public bool Flag_TransmissionBoost { get; set; } = false;
    }
}
