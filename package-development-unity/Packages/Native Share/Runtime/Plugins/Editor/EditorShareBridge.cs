using System.IO;
using System.Web;
using UnityEditor;
using UnityEngine;

namespace NativeShareExtension
{
    internal class EditorShareBridge : IShareBridge
    {
        private const int CharacterLimit = 500;

        public void ShareText(string text, string subject = null)
        {
            if (text.Length > CharacterLimit)
            {
                var path = EditorUtility.SaveFilePanel("Save as File", string.Empty, subject, "txt");
                if (string.IsNullOrEmpty(path)) return;
                File.WriteAllText(path, text);
                EditorUtility.RevealInFinder(path);
            }
            else
            {
                Application.OpenURL($"mailto:?subject={subject}&body={HttpUtility.UrlEncode(text)}");
            }
        }
    }
}