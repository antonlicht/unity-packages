namespace NativeShareExtension
{
    internal class iOSShareBridge : IShareBridge
    {
        private struct SocialSharingStruct
        {
            public string text;
            public string subject;
            public string filePaths;
        }

        [System.Runtime.InteropServices.DllImport("__Internal")]
        private static extern void showSocialSharing(ref SocialSharingStruct conf);

        public void ShareText(string text, string subject = null)
        {
            Share(subject, text,string.Empty);
        }

        private void Share(string subject, string text, string filePath)
        {
            var filePaths = string.IsNullOrEmpty(filePath) ? new string[0] : new[] {filePath};
            Share(subject, text, filePaths);
        }

        private void Share(string subject, string text, string[] filePaths)
        {
            var conf = new SocialSharingStruct
            {
                subject = subject,
                text = text,
                filePaths = string.Join(";", filePaths),
            };

            showSocialSharing(ref conf);
        }


    }
}