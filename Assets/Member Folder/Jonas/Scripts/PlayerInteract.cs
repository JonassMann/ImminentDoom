using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject dialogueBox;
    public Enemy testEnemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            dialogueBox.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gm.StartCombat(testEnemy);
        }
    }
}
