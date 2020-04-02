namespace NativeShareExtension
{
    internal interface IShareBridge
    {
        void ShareText(string text, string subject = null);
    }
}