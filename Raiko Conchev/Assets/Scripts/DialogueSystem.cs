using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public Camera twoDCamera;          // Reference to the 2D camera
    public RectTransform dialogueUI;   // The dialogue box (Raw Image or Panel inside a Canvas)
    public Transform personTransform;  // Transform of the person talking
    public Vector2 screenOffset = new Vector2(300f, 300f); // Offset in screen space
    public TextMeshProUGUI dialogueText; // Text component inside the dialogue box

    public void StartDialogue()
    {
        // Show the dialogue UI
        dialogueUI.gameObject.SetActive(true);

        // Update position and size
        UpdateDialogueBoxPosition();
        AdjustTextToBounds();
    }

    public void StopDialogue()
    {
        // Hide the dialogue UI
        dialogueUI.gameObject.SetActive(false);
    }

    void Update()
    {
        Debug.Log("Text before click: " + dialogueText.text);
        if (dialogueUI.gameObject.activeSelf)
        {
            // Continuously update the dialogue box position
            UpdateDialogueBoxPosition();
        }Debug.Log("Text before click: " + dialogueText.text);
    }

    private void UpdateDialogueBoxPosition()
    {
        // Convert the character's position to screen space
        Vector3 screenPosition = twoDCamera.WorldToScreenPoint(personTransform.position);

        // Apply the offset in screen space
        dialogueUI.position = screenPosition + new Vector3(screenOffset.x, screenOffset.y, 0);
    }

    private void AdjustTextToBounds()
    {
        // Ensure the text resizes to fit within the bounds of the dialogue box
        dialogueText.enableAutoSizing = true; // Enable auto-sizing
        dialogueText.margin = new Vector4(50f, 50f, 50f, 50f); // Add some padding inside the box

        // Set anchors to stretch within the dialogue UI
        RectTransform textRectTransform = dialogueText.GetComponent<RectTransform>();
        textRectTransform.anchorMin = Vector2.zero;  // Anchors at bottom-left
        textRectTransform.anchorMax = Vector2.one;   // Anchors at top-right
        textRectTransform.offsetMin = Vector2.zero;  // Remove extra offset (left, bottom)
        textRectTransform.offsetMax = Vector2.zero;  // Remove extra offset (right, top)
        textRectTransform.pivot = new Vector2(0.5f, 0.5f);  // Center pivot
    }
}
