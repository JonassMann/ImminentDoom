using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public int maxHandSize = 10;

    public List<Card> cardsDeck;
    public Dictionary<CardType, List<int>> cardsMods;

    [HideInInspector]
    public Character player;
    [HideInInspector]
    public Character enemy;

    public GameObject handArea;
    public GameObject playArea;
    public GameObject cardHolder;

    public GameObject cardPrefab;
    private GameManager gameManager;

    private int[] refList = new int[10];

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cardsMods = new Dictionary<CardType, List<int>>();
        ResetModList();

        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(cardPrefab, cardHolder.transform);
            temp.SetActive(false);
        }
    }

    public void Init()
    {
        player.effects = new Dictionary<Effect, int>();
        cardsDeck = new List<Card>(gameManager.playerDeck);
        NewTurn();
        // UI setup, hp and such
    }

    public void NewTurn()
    {
        int drawCount = 5;
        if (player.effects.ContainsKey(Effect.DrawCount)) drawCount += player.effects[Effect.DrawCount];
        Draw(drawCount);
    }

    public void ResetModList()
    {
        cardsMods[CardType.Etos] = new List<int>(refList);
        cardsMods[CardType.Patos] = new List<int>(refList);
        cardsMods[CardType.Logos] = new List<int>(refList);
        cardsMods[CardType.Kairos] = new List<int>(refList);
    }

    public GameObject GetCardObject()
    {
        if (cardHolder.transform.childCount <= 0)
            for (int i = 0; i < 10; i++)
            {
                GameObject temp = Instantiate(cardPrefab, cardHolder.transform);
                temp.SetActive(false);
            }

        return cardHolder.transform.GetChild(0).gameObject;
    }

    [Button]
    public void Draw(int num = 1)
    {
        for (int i = 0; i < num; i++)
        {
            if (handArea.transform.childCount >= maxHandSize)
            {
                Debug.Log("Hand full");
                return;
            }

            Card tempCard = GetCard();

            if (tempCard == null)
            {
                Debug.Log($"Deck empty - {num - i} draw skipped");
                return;
            }

            cardsDeck.Remove(tempCard);

            GameObject cardObject = GetCardObject();
            cardObject.transform.SetParent(handArea.transform);
            cardObject.GetComponent<CardDisplay>().DisplayCard(tempCard);
        }
    }

    public Card GetCard(int id = -1)
    {
        if (cardsDeck.Count == 0) return null;

        Card selectedCard = null;
        if (id < 0)
        {
            selectedCard = cardsDeck[Random.Range(0, cardsDeck.Count)];
        }
        return selectedCard;
    }

    public void UpdatePlay()
    {
        ResetModList();
        CardDisplay tempCardDisplay;

        int counter = 0;
        for (int i = 0; i < playArea.transform.childCount; i++)
        {
            tempCardDisplay = playArea.transform.GetChild(counter).GetComponent<CardDisplay>();
            if (tempCardDisplay == null)
            {
                counter++;
                continue;
            }

            foreach (CardModifier c in tempCardDisplay.card.modifiers)
            {
                int modPos = counter + c.position;
                if (modPos < 0 || modPos >= 10) continue;

                cardsMods[c.cardType][modPos] += c.modValue;
            }
            counter++;
        }
        Debug.Log(counter);

        counter = 0;
        for (int i = 0; i < playArea.transform.childCount; i++)
        {
            tempCardDisplay = playArea.transform.GetChild(counter).GetComponent<CardDisplay>();
            if (tempCardDisplay == null)
            {
                counter++;
                continue;
            }

            tempCardDisplay.UpdateCard(cardsMods[tempCardDisplay.card.cardType][counter]);
            counter++;
        }

        Debug.Log(counter);
        // Debug.Log("Play Area Updated");
    }

    public void PlayCards()
    {
        foreach (Transform t in handArea.transform)
        {

        }

        // Remove cards from play area, put cards back in deck
    }

    [Button]
    public void TestStuff()
    {
        string s = "";
        foreach (int i in cardsMods[CardType.Logos])
            s += $"{i}, ";

        Debug.Log(s);
    }
}
