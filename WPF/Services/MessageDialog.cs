using System.Windows;

namespace WPF.Services
{
    public class MessageDialog : IMessageDialog
    {
        public MessageDialogResult ShowOkCancelDialog(string text, string title)
        {
            var result = MessageBox.Show(text, title, MessageBoxButton.OKCancel);
            return result == MessageBoxResult.OK
                ? MessageDialogResult.OK
                : MessageDialogResult.Cancel;
        }

        public enum MessageDialogResult
        {
            OK,
            Cancel
        }
    }
}
