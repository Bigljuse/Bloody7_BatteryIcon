using BatteryIcon.Models;

namespace BatteryIcon.Pointers
{
    internal static class Mouse
    {
        internal static MouseStatusesModel Statuses { get; set; } = new();

        internal static void ClearStatuses()
        {
            foreach (var status in Statuses.GetType().GetProperties())
            {
                if (status.PropertyType == typeof(bool))
                    status.SetValue(Statuses, false);
                else
                    status.SetValue(Statuses, (byte)0);
            }
        }
    }
}
