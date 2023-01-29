using BatteryIcon.MouseIcon.Drawer;
using BatteryIcon.Pointers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BatteryIcon.MouseIcon.Manager
{
    internal class NotificationIconManager
    {
        public NotifyIcon NotificationIcon = new();

        public NotificationIconManager()
        {
            CreateNotificationIcon();
        }

        public void ShowIcon()
        {
            NotificationIcon.Visible = true;
        }

        public void HideIcon()
        {
            NotificationIcon.Visible = false;
        }

        public void UpdateIconInfo()
        {
            var newIcon = GetNewIcon();

            NotificationIcon.Icon?.Dispose();
            NotificationIcon.Icon = newIcon;

            var mouseBattery = Mouse.Statuses.Battery;
            var mouseBatteryPercent = Mouse.Statuses.BatteryPercent;
            string text = String.Format("{0}% ({1}) charge in mouse", mouseBatteryPercent, mouseBattery);
            NotificationIcon.Text = text;
        }

        private void CreateNotificationIcon()
        {
            NotificationIcon = new NotifyIcon();
            UpdateIconInfo();
            NotificationIcon.ContextMenuStrip = CreateContextMenuStrip();
        }

        private Icon GetNewIcon()
        {
            BatteryDrawer batteryDrawer = new(Drawer.Enums.BatterySize.Bitmap_16x16);
            Bitmap bitmap = batteryDrawer.GetBitmap(Mouse.Statuses.BatteryPercent);
            IntPtr iconPointer = bitmap.GetHicon();
            Icon newIcon = Icon.FromHandle(iconPointer);

            return newIcon;
        }

        private ContextMenuStrip CreateContextMenuStrip()
        {
            ContextMenuStrip contextMenuStrip = new();

            contextMenuStrip.Items.Add("Clear values", null, NotifyIcon_ClearPointersClick);
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            contextMenuStrip.Items.Add("Exit", null, NotifyIcon_ExitClick);

            return contextMenuStrip;
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                NotificationIcon.ShowBalloonTip(10);
                return;
            }
        }

        private void NotifyIcon_ExitClick(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void NotifyIcon_ClearPointersClick(object sender, EventArgs e)
        {
            Mouse.ClearStatuses();
        }
    }
}
