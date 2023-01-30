using BatteryIcon.MouseIcon.Manager;
using BatteryIcon.Pointers;
using BatteryIcon.Processes;
using BatteryIcon.Properties;
using System.Timers;
using System.Windows;

namespace BatteryIcon
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NotificationIconManager _notificationIconManager = new();
        private Bloody7Reader? _pointerReader;
        private static readonly object _timer_locker = new();
        private readonly Timer timer = new()
        {
            AutoReset = true,
            Interval = 5000
        };

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Current.Exit += Application_Exit;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            _notificationIconManager.ShowIcon();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Settings.Default.Save();
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            lock (_timer_locker)
            {
                var process = ProcessManager.GetProcessByName("Bloody7");

                if (process is null)
                {
                    Mouse.ClearStatuses();
                    _pointerReader = null;
                    _notificationIconManager.UpdateIconInfo();
                    return;
                }

                if (_pointerReader is null)
                {
                    Mouse.ClearStatuses();
                    _pointerReader = new Bloody7Reader(process);
                }

                _pointerReader.ReadPointers();
                _notificationIconManager.UpdateIconInfo();
            }
        }
    }
}
