using System;
using System.Windows.Forms;
using DevExpress.Utils.Animation;
using DevExpress.XtraEditors;

namespace CallQueue.AppLocal
{
    public static class Utils
    {
        public static void SetCrossThread<T>(this T control, Action<T> action)
            where T : Control
        {
            if (control.InvokeRequired)
            {
                MethodInvoker methodInvoker = delegate
                {
                    action(control);
                };
                control.Invoke(methodInvoker);
            }
            else
            {
                action(control);
            }
        }

        public static void OpenFormAsync<T>(this TransitionManager transitionManager, Control parentControl, Control containerControl, Func<T> funcForm, Action callback)
            where T : Form
        {
            if (funcForm != null)
            {
                parentControl.Enabled = false;
                transitionManager.StartTransition(containerControl);
                var asyncResult = funcForm.BeginInvoke((IAsyncResult result) =>
                {
                    parentControl.SetCrossThread(x => x.Enabled = true);
                }, funcForm.Invoke());
                transitionManager.EndTransition();
                (asyncResult.AsyncState as T).ShowDialog();
                callback?.Invoke();
            }
        }

        public static void ShowErrorMessageBox(this Exception exception, string header = "Lỗi")
        {
            XtraMessageBox.Show(exception.ToString(), header, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowErrorMessageBox(this string message, string header = "Lỗi")
        {
            XtraMessageBox.Show(message, header, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowExclamation(string message, string header = "Cảnh báo")
        {
            XtraMessageBox.Show(message, header, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInformation(string message, string header = "Thông báo")
        {
            XtraMessageBox.Show(message, header, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ShowDeleteQuestion(string message = "Bạn có muốn xóa hàng này không ?")
        {
            return XtraMessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static bool ShowQuestion(string message = "?")
        {
            return XtraMessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
