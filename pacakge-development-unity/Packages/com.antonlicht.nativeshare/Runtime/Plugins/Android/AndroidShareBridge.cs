namespace NativeShareExtension
{
    internal class AndroidShareBridge : IShareBridge
    {
        public void ShareText(string text, string subject)
        {
            AndroidExtensions.CreateSendIntent()
                .PutExtra("EXTRA_TEXT", text)
                .PutExtra("EXTRA_SUBJECT", subject)
                .SetMimeType()
                .ShowChooser();
        }
    }
}