using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModalBase : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI titleText;

    [SerializeField]
    private TextMeshProUGUI messageText;

    [SerializeField]
    private Button YesButton;

    [SerializeField]
    private Button NoButton;

    public delegate void ModalEventDelegate(); //委託

    public void SetTwoButtonModal(string title, string message,
       ModalEventDelegate yesEvent, ModalEventDelegate noEvent)
    {
        this.gameObject.SetActive(true);
        titleText.text = title;
        messageText.text = message;
        YesButton.onClick.AddListener(() => yesEvent());
        NoButton.onClick.AddListener(() => noEvent());
    }
}
