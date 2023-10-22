using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Card> cardLibrary;
    public List<Card> playerDeck;
    public List<Card> starterDeck;

    // Items/ clues?
    // Overworld UI updates?

    private void Awake()
    {
        starterDeck = new List<Card>();
        foreach (Card c in playerDeck)
            starterDeck.Add(Instantiate(c));
    }

}
