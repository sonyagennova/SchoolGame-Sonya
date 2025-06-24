using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad; // Set the name of the scene to load in the Inspector.

    public void OnMouseDown()
    {
        // Load the specified scene when the sprite is clicked.
        SceneManager.LoadScene(sceneToLoad);
    }
}
