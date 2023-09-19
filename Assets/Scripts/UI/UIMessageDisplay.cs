using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMessageDisplay : MonoBehaviour
{
    public void Message(TextMeshProUGUI messageText, string message)
    {
        StartCoroutine(DisplayMessage(messageText, message, 2));
    }

    private IEnumerator DisplayMessage(TextMeshProUGUI messageText, string message, float delay)
    {
        messageText.gameObject.SetActive(true);
        messageText.text = message;

        yield return new WaitForSeconds(delay);

        messageText.text = "";
        messageText.gameObject.SetActive(false);
    }
}
