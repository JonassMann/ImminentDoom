using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject dialogueBox;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            dialogueBox.SetActive(true);
        }
    }
}
