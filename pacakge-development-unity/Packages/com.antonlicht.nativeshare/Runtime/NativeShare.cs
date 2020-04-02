namespace NativeShareExtension
{
    public static class NativeShare
    {
        private static IShareBridge _shareBridge;

        private static IShareBridge ShareBridge
        {
            get
            {
                if (_shareBridge == null)
                {
#if UNITY_EDITOR
                    _shareBridge = new EditorShareBridge();
#elif UNITY_ANDROID
                    _shareBridge = new AndroidShareBridge();
#elif UNITY_IOS
                    _shareBridge = new iOSShareBridge();
#endif
                }
                return _shareBridge;
            }
        }

        public static void ShareText(string text, string subject = null) => ShareBridge.ShareText(text, subject);
    }
}