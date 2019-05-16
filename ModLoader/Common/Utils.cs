using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Java.IO;

namespace ModLoader.Common
{
    class Utils
    {
        public static byte[] FileToMemory(string filename)
        {
            byte[] bytes = new byte[2048];
            FileInputStream fs = new FileInputStream(filename);
            MemoryStream outStream = new MemoryStream();
            int len;
            while ((len = fs.Read(bytes, 0, bytes.Length)) > 0)
            {
                outStream.Write(bytes, 0, len);
            }

            fs.Close();
            return outStream.ToArray();
        }

        public static void StreamToFile(Stream stream, string fileName)
        {
            byte[] bytes = new byte[2048];
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            int len;
            while ((len = stream.Read(bytes, 0, bytes.Length)) > 0)
            {
                bw.Write(bytes, 0, len);
            }

            bw.Close();
            fs.Close();
        }

        public static void InvokeLooperThread(Action action)
        {
            new Thread(() =>
            {

                Looper.Prepare();
                new Handler().Post(action);
                Looper.Loop();
            }).Start();
        }

        public static void MakeToast(Context context, string message, ToastLength toastLength)
        {
            InvokeLooperThread(() => Toast.MakeText(context, message, toastLength).Show());
        }

        public static void ShowProgressDialog(Context context, int titleId, string message, Action<AlertDialog> returnCallback)
        {
            InvokeLooperThread(() =>
            {
                ProgressDialog dialog = new ProgressDialog(context);
                dialog.SetTitle(titleId);
                dialog.SetMessage(message);
                dialog.SetCancelable(false);
                dialog.SetProgressStyle(ProgressDialogStyle.Spinner);
                dialog.Show();
                returnCallback(dialog);
            });
        }

        public static void ShowConfirmDialog(Context context, int titleId, int messageId, int confirmId, int cancelId, Action onConfirm = null,
            Action onCancel = null)
        {
            InvokeLooperThread(() =>
            {
                new AlertDialog.Builder(context).SetTitle(titleId).SetMessage(messageId).SetCancelable(true)
                    .SetPositiveButton(confirmId, (sender, args) => onConfirm?.Invoke())
                    .SetNegativeButton(cancelId, (sender, args) => onCancel?.Invoke())
                    .Show();
            });
        }
    }
}
