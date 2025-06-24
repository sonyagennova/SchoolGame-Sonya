using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class onInfoClicked : MonoBehaviour
{
    public GameObject messageBar;
    public TextMeshProUGUI message;

    private bool isMessageBarVisible = false;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("MessageButton"))
            {
                isMessageBarVisible = !isMessageBarVisible;
                messageBar.gameObject.SetActive(isMessageBarVisible);
                message.gameObject.SetActive(isMessageBarVisible);
            }
        }
    }
}
