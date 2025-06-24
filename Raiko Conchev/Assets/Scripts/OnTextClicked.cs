using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OnTextClicked : MonoBehaviour
{
    public TextMeshProUGUI dialogue; // Reference to the 2D TextMeshPro object
    public GameObject diamond;       // The clickable diamond object
    public GameObject closeButton;
    public GameObject answer1;
    public GameObject answer2;
    public GameObject answer3;
    public GameObject answer4;
    public TextMeshProUGUI answer;

    public RawImage board;

    public QuestionManager questionManager;
    public ButtonChecker isCorrect;

    public ScoreKeeper score;

    void Start()
    {
        // Hide the dialogue and button at the start
        dialogue.gameObject.SetActive(false);
        board.gameObject.SetActive(false);
        closeButton.SetActive(false);
        answer1.SetActive(false);
        answer2.SetActive(false);
        answer3.SetActive(false);
        answer4.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect left mouse click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Ray from the camera to mouse position
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == diamond) // Check if diamond is clicked
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
        board.gameObject.SetActive(true);
        closeButton.SetActive(true);
        answer1.SetActive(true);
        answer2.SetActive(true);
        answer3.SetActive(true);
        answer4.SetActive(true);
    }

    public void HideDialogue()
    {
        // Hide the dialogue and button
        dialogue.gameObject.SetActive(false);
        answer.gameObject.SetActive(false);
        board.gameObject.SetActive(false);
        closeButton.SetActive(false);
        answer1.SetActive(false);
        answer2.SetActive(false);
        answer3.SetActive(false);
        answer4.SetActive(false);
        Debug.Log(isCorrect.isCorrectClicked);
        if(isCorrect.isCorrectClicked == true){
            questionManager.CheckAnswer();
            score.IncreaseScore();
        }
    }
}
