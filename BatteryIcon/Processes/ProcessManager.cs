using System.Diagnostics;
using Settings = BatteryIcon.Properties.Settings;

namespace BatteryIcon.Processes
{
    internal static class ProcessManager
    {
        private static Process? s_Process = null;

        internal static Process? GetProcessByName(string processName)
        {
            var isProcessNull = s_Process is null;

            if (isProcessNull == true)
                return FindProcessByName(processName);

            if (s_Process.HasExited == true)
                return FindProcessByName(processName);

            if (s_Process.ProcessName == processName)
                return s_Process;

            return FindProcessByName(processName);
        }

        private static Process? FindProcessByName(string processName)
        {
            Process[] processesArray = Process.GetProcesses();

            foreach (Process process in processesArray)
            {
                if (process.ProcessName != processName)
                    continue;

                s_Process = process;

                return process;
            }

            return null;
        }
    }
}
