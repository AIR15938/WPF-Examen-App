namespace WPF.Services
{
    public interface IMessageDialog
    {
        MessageDialog.MessageDialogResult ShowOkCancelDialog(string text, string title);
    }
}