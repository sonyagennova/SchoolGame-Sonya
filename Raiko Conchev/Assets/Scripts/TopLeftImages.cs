using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TopLeftImages : MonoBehaviour
{
    public GameObject[] images;
    public GameObject Next;
    public TextMeshProUGUI congratulations;
    private int currentIndex = 0;

    void Start(){
        congratulations.gameObject.SetActive(false);
        Next.SetActive(false);
    }

    // Показване на следващото изображение
    public void ShowNextImage()
    {
        if (currentIndex < images.Length)
        {
            images[currentIndex].SetActive(true);
            if(currentIndex == images.Length - 1){
                congratulations.gameObject.SetActive(true);
                Next.SetActive(true);
            }
            currentIndex++;
        }
    }

    public void Hide(){
        congratulations.gameObject.SetActive(false);
        Next.SetActive(false);
    }
}
