using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EablePriest : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    public RawImage quest;
    public GameObject continueButon;
    public GameObject player;
    // Start is called before the first frame update
    public void Start()
    {

        quest.enabled = false;
        continueButon.SetActive(false);
        player.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "PT_Medieval_Priest_StPatrick")
                {
                    dialogue.enabled = true;
                    quest.enabled = true;
                    continueButon.SetActive(true);
                    player.SetActive(true);
                }
            }
        }
    }
}
