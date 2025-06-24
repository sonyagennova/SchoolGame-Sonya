using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animation animationComponent;

    void Start()
    {
        // Get the Animation component on the object
        animationComponent = GetComponent<Animation>();
    }

    void Update()
    {
       animationComponent.Play("AnimalArmature|Eating");
    }
}
