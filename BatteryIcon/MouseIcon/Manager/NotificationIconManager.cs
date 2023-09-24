using BatteryIcon.MouseIcon.Drawer;
using BatteryIcon.Pointers;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Settings = BatteryIcon.Properties.Settings;

namespace BatteryIcon.MouseIcon.Manager
{
    internal class NotificationIconManager
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        public NotifyIcon NotificationIcon = new();
        public static IntPtr s_lastIconHandle = IntPtr.Zero;

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
            NotificationIcon.Icon = newIcon;

            ushort mouseBattery = Mouse.Statuses.Battery;
            byte mouseBatteryPercent = Mouse.Statuses.BatteryPercent;
            string text = String.Format("{0}% ({1}) charge in mouse.", mouseBatteryPercent, mouseBattery);
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
            if(s_lastIconHandle != IntPtr.Zero)
                DestroyIcon(s_lastIconHandle);

            Color batteryIconColor = Settings.Default.BatteryIconColor;

            BatteryDrawer batteryDrawer = new(Drawer.Enums.BatterySize.Bitmap_16x16);
            Bitmap bitmap = batteryDrawer.GetBitmap(Mouse.Statuses.BatteryPercent, batteryIconColor);
            IntPtr iconPointer = bitmap.GetHicon();
            Icon newIcon = Icon.FromHandle(iconPointer);
            s_lastIconHandle = iconPointer;

            return newIcon;
        }

        private ContextMenuStrip CreateContextMenuStrip()
        {
            ContextMenuStrip contextMenuStrip = new();
            MenuStrip menuStrip = new MenuStrip();

            ToolStripDropDownButton toolStripDropDownButton = new ToolStripDropDownButton();
            toolStripDropDownButton.Text = "Theme";
            toolStripDropDownButton.DropDownItems.Add(new ToolStripButton("Light",null, NotifyIcon_SetLightThemeClick));
            toolStripDropDownButton.DropDownItems.Add(new ToolStripButton("Dark",null, NotifyIcon_SetDarkThemeClick));            

            contextMenuStrip.Items.Add(toolStripDropDownButton);
          //contextMenuStrip.Items.Add("Clear values", null, NotifyIcon_ClearPointersClick);
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            contextMenuStrip.Items.Add("Exit", null, NotifyIcon_ExitClick);

            return contextMenuStrip;
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                NotificationIcon.ShowBalloonTip(10);
        }

        private void NotifyIcon_SetLightThemeClick(object sender, EventArgs e)
        {
            Settings.Default.BatteryIconColor = Color.Black;
            Settings.Default.Save();
            UpdateIconInfo();
        }

        private void NotifyIcon_SetDarkThemeClick(object sender, EventArgs e)
        {
            Settings.Default.BatteryIconColor = Color.White;
            Settings.Default.Save();
            UpdateIconInfo();
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
