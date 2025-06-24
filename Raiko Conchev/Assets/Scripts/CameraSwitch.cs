using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;         // Reference to the main 3D camera
    public Camera twoDCamera;         // Reference to the 2D camera
    public GameObject dialogueUI;     // Dialogue UI (3D Raw Image)
    private bool isTalking = false;

    void Start()
    {
        // Ensure the 2D camera and dialogue UI are off initially
        twoDCamera.gameObject.SetActive(false);
        dialogueUI.SetActive(false);
    }

    void OnMouseDown()
    {
        if (!isTalking)
        {
            StartTalking();
        }
        else
        {
            StopTalking();
        }
    }

    void StartTalking()
    {
        isTalking = true;

        // Enable the 2D camera and dialogue UI
        mainCamera.gameObject.SetActive(false);
        twoDCamera.gameObject.SetActive(true);
        dialogueUI.SetActive(true);

        Time.timeScale = 1; // Ensure animations continue
    }

    void StopTalking()
    {
        isTalking = false;

        // Disable the 2D camera and dialogue UI
        twoDCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        dialogueUI.SetActive(false);
    }
}
