using System.Windows;

namespace BatteryIcon.Windows
{
    public partial class MainWindow : Window
    {
        //public void LoadProcesses()
        //{
        //    foreach (Process process in Process.GetProcesses())
        //    {
        //        var textBlock = CreateTextBlock(process);
        //
        //        ComboBox_Processes.Items.Add(textBlock);
        //    }
        //}
        //
        //public void SaveSelectedProcess()
        //{
        //    TextBlock? selectedName = ComboBox_Processes.SelectedItem as TextBlock;
        //    Process? selectedProcess = selectedName?.Tag as Process;
        //
        //    if (selectedProcess is null)
        //        return;
        //
        //    SettingsManager.SaveProcessInSettings(selectedProcess);
        //}
        //
        //public void SelectSavedProcess()
        //{
        //    Process? process = SettingsManager.FindSavedProcess();
        //
        //    if (process is null)
        //        return;
        //
        //    ComboBox_Processes.SelectedItem = FindTextBlockByText(process.ProcessName);
        //    SettingsManager.SelectedProcess = process;
        //}
        //
        //private TextBlock? FindTextBlockByText(string processName)
        //{
        //    var textBlocks = ComboBox_Processes.Items;
        //    TextBlock? process_TextBlock = null;
        //
        //    foreach (TextBlock textBlock in textBlocks)
        //    {
        //        if (textBlock.Text != processName)
        //            continue;
        //
        //        process_TextBlock = textBlock;
        //        break;
        //    }
        //
        //    return process_TextBlock;
        //}
        //
        //private TextBlock? CreateTextBlock(Process? process)
        //{
        //    if (process is null)
        //        return null;
        //
        //    var textBlock = new TextBlock();
        //    textBlock.Text = process.ProcessName;
        //    textBlock.Tag = process;
        //
        //    return textBlock;
        //}
    }
}
