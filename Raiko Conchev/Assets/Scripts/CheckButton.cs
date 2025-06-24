using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonChecker : MonoBehaviour
{
    public Button correctButton;
    public Button wrongButton1;
    public Button wrongButton2;
    public Button wrongButton3;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI dialogue;
    public bool isCorrectClicked = false;

    public int brCorrectClicks = 0;

    public string innerText;

    void Start()
    {
        resultText.gameObject.SetActive(false);
        resultText.text = "";
        correctButton.onClick.AddListener(() => CheckButton(true));
        wrongButton1.onClick.AddListener(() => CheckButton(false));
        wrongButton2.onClick.AddListener(() => CheckButton(false));
        wrongButton3.onClick.AddListener(() => CheckButton(false));
    }

    // Функция за проверка на натиснатия бутон
    public void CheckButton(bool isCorrect)
    {
        dialogue.gameObject.SetActive(false);
        resultText.gameObject.SetActive(true);
        if (isCorrect)
        {
            brCorrectClicks ++;
            isCorrectClicked = true;
            resultText.text = innerText;
            resultText.color = new Color(0f, 0.5f, 0f);
        }
        else
        {
            isCorrectClicked = false;
            resultText.text = "Грешно!";
            resultText.color = Color.red;
        }
    }
}
