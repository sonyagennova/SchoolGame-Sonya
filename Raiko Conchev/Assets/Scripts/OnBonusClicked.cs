using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OnBonusClicked : MonoBehaviour
{
   public GameObject bonus;
    public TextMeshProUGUI dialogue;
    public GameObject closeButton;

    public ScoreKeeper score;

    void Start()
    {
        dialogue.gameObject.SetActive(false);
        closeButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect left mouse click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Ray from the camera to mouse position
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == bonus) // Check if diamond is clicked
                {
                    ShowDialogue();
                }
            }
        }
    }

    public void ShowDialogue()
    {
        // Enable the dialogue and button
        dialogue.gameObject.SetActive(true);
        closeButton.SetActive(true);
        score.IncreaseScore();
    }

     public void HideDialogue()
    {
        dialogue.gameObject.SetActive(false);
        closeButton.SetActive(false);
    }
}
