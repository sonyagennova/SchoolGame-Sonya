using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 offset = new Vector3(player.transform.position.x ,player.transform.position.y + 0.5f, player.transform.position.z);
        transform.position = offset;
        transform.rotation = player.transform.rotation;
        
    }
}
