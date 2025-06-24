using UnityEngine;
using System.Collections;

public class DogTurnAround : MonoBehaviour
{
    public float turnSpeed = 180f; // Rotation speed in degrees per second

    void OnCollisionEnter(Collision collision)
    {
        // Check if the dog collided with any object
        Debug.Log("Collided with: " + collision.gameObject.name);

        TurnAround();
    }

    IEnumerator SmoothTurn()
{
    float duration = 1.0f; // Time taken to complete the turn
    Quaternion startRotation = transform.rotation;
    Quaternion endRotation = Quaternion.Euler(0, transform.eulerAngles.y + 180, 0);

    float elapsedTime = 0f;
    while (elapsedTime < duration)
    {
        transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
        elapsedTime += Time.deltaTime;
        yield return null;
    }

    transform.rotation = endRotation;
}

void TurnAround()
{
    StartCoroutine(SmoothTurn());
}
}
