using UnityEngine;
using TMPro;

public class BBChangeText : MonoBehaviour
{
    public GameObject targetObject; // Reference to the GameObject whose TextMeshPro text will be changed
    public string newText; // The new text to set

    public void ChangeTextMeshProText()
    {
        if (targetObject == null)
        {
            Debug.LogWarning("Target GameObject is not assigned.");
            return;
        }

        TextMeshProUGUI textMeshPro = targetObject.GetComponent<TextMeshProUGUI>();

        if (textMeshPro == null)
        {
            Debug.LogWarning("Target GameObject does not have a TextMeshPro component.");
            return;
        }

        textMeshPro.text = newText;
    }
}

