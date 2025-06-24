using UnityEngine;

public class SyncChildPosition : MonoBehaviour
{
    public Transform child;
    public Vector3 localPositionOffset;

    void Start()
    {
        if (child != null)
        {
            child.localPosition = localPositionOffset;
        }
    }
}