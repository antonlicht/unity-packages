using NativeShareExtension;
using UnityEngine;
using UnityEngine.UI;

public class NativeShareTestBehaviour : MonoBehaviour
{
    public Button ShareTextButton;
    public Button ShareMessageButton;
    void Start()
    {
        ShareTextButton.onClick.AddListener(OnShareText);
        ShareMessageButton.onClick.AddListener(OnShareMessage);
    }

    private void OnShareText()
    {
        NativeShare.ShareText("Test text");
    }

    private void OnShareMessage()
    {
        NativeShare.ShareText("Test message", "Testing");
    }
}
