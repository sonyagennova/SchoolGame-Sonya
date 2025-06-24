using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;

public class DogAdoption : MonoBehaviour
{
    public Button adoptButton;      // UI Button for adoption
    public Button unadoptButton;    // UI Button for unadoption
    public Transform player;        // Reference to the player
    private NavMeshAgent agent;     // NavMeshAgent for the dog
    private bool isAdopted = false; // Track adoption state

    private Coroutine buttonCoroutine; // Store the coroutine for button visibility
    private bool isMouseOverDog = false; // Track if the mouse is over the dog
    private bool isMouseOverButton = false; // Track if the mouse is over the button

    void Start()
    {
        // Initialize NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // Hide both buttons initially
        adoptButton.gameObject.SetActive(false);
        unadoptButton.gameObject.SetActive(false);

        // Assign button actions
        adoptButton.onClick.AddListener(AdoptDog);
        unadoptButton.onClick.AddListener(UnadoptDog);
    }

    void Update()
    {
        // If adopted, follow the player
        if (isAdopted && player != null)
        {
            agent.SetDestination(player.position);
        }

        Debug.Log(isAdopted);

        // If mouse is not over the dog and the button, hide the button after the delay
        if (!isMouseOverDog && !isMouseOverButton && buttonCoroutine != null)
        {
            StopCoroutine(buttonCoroutine); // Stop any previous coroutines
            buttonCoroutine = StartCoroutine(HideButtonAfterTime(0)); // Hide immediately
        }
    }

    void OnMouseEnter()
    {
        isMouseOverDog = true;

        // Show the appropriate button based on adoption status
        if (!isAdopted)
        {
            adoptButton.gameObject.SetActive(true);
            PositionButton(adoptButton);
        }
        else
        {
            unadoptButton.gameObject.SetActive(true);
            PositionButton(unadoptButton);
        }

        // Start the coroutine to hide the button after 3 seconds, but only if the mouse is over the dog
        if (buttonCoroutine != null)
        {
            StopCoroutine(buttonCoroutine); // Stop any previous coroutines
        }
        buttonCoroutine = StartCoroutine(HideButtonAfterTime(3f)); // Show for 3 seconds
    }

    void OnMouseExit()
    {
        isMouseOverDog = false;

        // If the mouse leaves the dog, start a coroutine to hide the button after 3 seconds if it's not hovered on the button
        if (!isMouseOverButton)
        {
            buttonCoroutine = StartCoroutine(HideButtonAfterTime(3f)); // Start countdown to hide the button after 3 seconds
        }
    }

    public void OnButtonMouseEnter()
    {
        isMouseOverButton = true; // Mouse is over the button
        // Keep the button visible while the mouse is over the button
        if (buttonCoroutine != null)
        {
            StopCoroutine(buttonCoroutine); // Stop hiding the button if hovering over the button
        }
    }

    public void OnButtonMouseExit()
    {
        isMouseOverButton = false; // Mouse is no longer over the button

        // If the mouse leaves the button, hide the button after the delay if the mouse is not on the dog
        if (!isMouseOverDog)
        {
            buttonCoroutine = StartCoroutine(HideButtonAfterTime(3f)); // Hide after 3 seconds if not hovered on dog
        }
    }

    public void AdoptDog()
    {
        isAdopted = true;
        adoptButton.gameObject.SetActive(false); // Hide the adopt button
        Debug.Log("Dog adopted!"); // Optional: feedback
    }

    public void UnadoptDog()
    {
        isAdopted = false;
        unadoptButton.gameObject.SetActive(false); // Hide the unadopt button
        Debug.Log("Dog unadopted!"); // Optional: feedback
    }

    void PositionButton(Button button)
    {
        // Position the button above the dog
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);
        button.transform.position = screenPosition;
    }

    // Coroutine to hide the button after a set time
    IEnumerator HideButtonAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        adoptButton.gameObject.SetActive(false);
        unadoptButton.gameObject.SetActive(false);
    }
}
