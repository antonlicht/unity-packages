using UnityEngine;

namespace NativeShareExtension
{
    internal static class AndroidExtensions
    {
        private const string IntentClassName = "android.content.Intent";
        private static readonly AndroidJavaClass intentClass = new AndroidJavaClass(IntentClassName);

        internal static AndroidJavaObject CreateSendIntent()
        {
            return new AndroidJavaObject(IntentClassName)
                .Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        }

        internal static AndroidJavaObject PutExtra(this AndroidJavaObject intent, string fieldName, string value)
        {
            if (!string.IsNullOrEmpty(value))
                intent.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>(fieldName), value);
            return intent;
        }

        internal static AndroidJavaObject SetMimeType(this AndroidJavaObject intent, string mimeType = "text/plain")
        {
            return intent.Call<AndroidJavaObject>("setType", mimeType);
        }

        internal static void ShowChooser(this AndroidJavaObject sendIntent)
        {
            StartActivity(intentClass.CallStatic<AndroidJavaObject>("createChooser", sendIntent, null));
        }

        private static void StartActivity(AndroidJavaObject intent)
        {
            GetCurrentActivity().Call("startActivity", intent);
        }

        private static AndroidJavaObject GetCurrentActivity()
        {
            var unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            return unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }
}