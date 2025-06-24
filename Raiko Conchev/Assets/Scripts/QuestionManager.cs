using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public TextMeshProUGUI questionText; // Текст за въпроса
    public Button[] answerButtons; // Масив с бутоните за отговори
    public string[] questions; // Въпроси
    public string[][] answers; // Отговори (масив от масиви)
    public int[] correctAnswers; // Индекси на правилните отговори

    private int currentQuestionIndex = 0; // Индекс на текущия въпрос

    public TopLeftImages topLeftImages;
    public ButtonChecker brClicks;

    void Start()
    {
        // ShowQuestion();
    }

    public void CheckAnswer()
    {
        Debug.Log("Правилен отговор!");
        if(brClicks.brCorrectClicks <= 1){
            topLeftImages.ShowNextImage(); 
        }
        NextQuestion();
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
    }
}
