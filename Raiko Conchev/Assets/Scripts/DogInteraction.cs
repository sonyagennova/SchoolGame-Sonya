using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DogInteraction : MonoBehaviour
{
    public float damage = 0.5f; // Amount of damage the dog causes

    public TextMeshProUGUI playerHealth;
    public PlayerLife lifeCount;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (lifeCount.lifeCnt != null)
            {
                lifeCount.DecreaseLife(0.5f);
                // playerHealth.text = lifeCount.lifeCnt.ToString();
            }
        }
    }
}
