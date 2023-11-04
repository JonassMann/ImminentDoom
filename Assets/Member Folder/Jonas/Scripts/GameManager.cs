using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player playerCharacter;
    public List<Card> cardLibrary;
    public List<Card> playerDeck;

    [HideInInspector]
    public Player player;
    public CardManager cardManager;
    public PlayerMovement playerMovement;

    // Items/ clues?
    // Overworld UI updates?

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        player = Instantiate(playerCharacter);

        playerDeck = new List<Card>();
        foreach (Card c in player.starterDeck)
            playerDeck.Add(Instantiate(c));
    }

    public void StartCombat(Character enemy)
    {
        // Load card scene additive
        // Run card manager start
        // See if card manager can access game manager

        StartCoroutine(IStartCombat());
    }

    public IEnumerator IStartCombat()
    {
        playerMovement.canMove = false;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        yield return null;

        cardManager = GameObject.FindGameObjectWithTag("CardManager").GetComponent<CardManager>();
        cardManager.player = player;
        cardManager.Init();
    }

    public void EndCombat()
    {
        playerMovement.canMove = true;
        SceneManager.UnloadSceneAsync(1);
    }
}
