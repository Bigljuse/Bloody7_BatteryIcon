using BatteryIcon.Pointers.Offsets;
using Binarysharp.MSharp;
using System;
using System.Diagnostics;

namespace BatteryIcon.Pointers
{
    internal sealed class Bloody7Reader
    {
        private readonly MemorySharp _memorySharp;

        internal Bloody7Reader(Process mouseProcess)
        {
            _memorySharp = new MemorySharp(mouseProcess);
        }

        internal void ReadPointers()
        {
            try
            {
                Read_Charging();
                Read_Connection();
                Read_Battery();
                Read_BatteryPercent();
                Read_LowBattery();
                Read_Signal();
                Read_SleepTimeOut();
                Read_Channel();
                Read_WakeUpState();
                Read_LightBrightness();
                Read_CurrentMouseID();
                Read_LastMouseID();
                Read_Flag_RFSynchronize();
                Read_Flag_ZeroFrequencyOffset();
                Read_Flag_ExclusiveChanel();
                Read_Flag_RFSignalDetector();
                Read_Flag_TransmissionBoost();
            }
            catch (Exception ex)
            { }
        }

        private void Read_Charging()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.Charging, (int)Bloody7.Offsets0.Charging);

            if (value == 1)
                Mouse.Statuses.IsCharging = true;
            else
                Mouse.Statuses.IsCharging = false;
        }

        private void Read_Connection()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.Connection);

            if (value == 1)
                Mouse.Statuses.IsConnected = true;
            else
                Mouse.Statuses.IsConnected = false;
        }

        private void Read_Battery()
        {
            ushort value = ReadPointerValue<ushort>((int)Bloody7.StaticAdresses.Battery, (int)Bloody7.Offsets0.Battery);

            Mouse.Statuses.Battery = value;
        }

        private void Read_BatteryPercent()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.BatteryPercent, (int)Bloody7.Offsets0.BatteryPercent);

            Mouse.Statuses.BatteryPercent = value;
        }

        private void Read_LowBattery()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.LowBattery, (int)Bloody7.Offsets0.LowBattery);

            Mouse.Statuses.LowBattery = value;
        }

        private void Read_Signal()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.Signal, (int)Bloody7.Offsets0.Signal);

            Mouse.Statuses.Signal = value;
        }

        private void Read_SleepTimeOut()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.SleepTimeOut);

            Mouse.Statuses.SleepTimeOut = value;
        }

        private void Read_Channel()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.Channel);

            Mouse.Statuses.Channel = value;
        }

        private void Read_WakeUpState()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.WakeUpState);

            Mouse.Statuses.WakeUpState = value;
        }

        private void Read_LightBrightness()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.LightBrightness);

            Mouse.Statuses.LightBrightness = value;
        }

        private void Read_CurrentMouseID()
        {
            uint value = ReadPointerValue<uint>((int)Bloody7.StaticAdresses.CurrentMouseID);

            Mouse.Statuses.CurrentMouseID = value;
        }

        private void Read_LastMouseID()
        {
            uint value = ReadPointerValue<uint>((int)Bloody7.StaticAdresses.LastMouseID);

            Mouse.Statuses.LastMouseID = value;
        }

        private void Read_Flag_RFSynchronize()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.Flag_RFSynchronize);

            if (value == 1)
                Mouse.Statuses.Flag_RFSynchronize = true;
            else
                Mouse.Statuses.Flag_RFSynchronize = false;
        }

        private void Read_Flag_ZeroFrequencyOffset()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.Flag_ZeroFrequencyOffset);

            if (value == 1)
                Mouse.Statuses.Flag_ZeroFrequencyOffset = true;
            else
                Mouse.Statuses.Flag_ZeroFrequencyOffset = false;
        }

        private void Read_Flag_ExclusiveChanel()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.Flag_ExclusiveChanel);

            if (value == 1)
                Mouse.Statuses.Flag_ExclusiveChanel = true;
            else
                Mouse.Statuses.Flag_ExclusiveChanel = false;
        }

        private void Read_Flag_RFSignalDetector()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.Flag_RFSignalDetector);

            if (value == 1)
                Mouse.Statuses.Flag_RFSignalDetector = true;
            else
                Mouse.Statuses.Flag_RFSignalDetector = false;
        }

        private void Read_Flag_TransmissionBoost()
        {
            byte value = ReadPointerValue<byte>((int)Bloody7.StaticAdresses.Flag_TransmissionBoost);

            if (value == 1)
                Mouse.Statuses.Flag_TransmissionBoost = true;
            else
                Mouse.Statuses.Flag_TransmissionBoost = false;
        }

        private T ReadPointerValue<T>(int offset0) where T : struct
        {
            IntPtr offset = new(offset0);
            return _memorySharp.Read<T>(offset);
        }

        private T ReadPointerValue<T>(int offset0, int offset1) where T : struct
        {
            IntPtr offset = new(offset0);
            Int32 value = _memorySharp.Read<Int32>(offset);
            IntPtr address = new(value);
            address = IntPtr.Add(address, offset1);
            return _memorySharp.Read<T>(address, false);
        }
    }
}
