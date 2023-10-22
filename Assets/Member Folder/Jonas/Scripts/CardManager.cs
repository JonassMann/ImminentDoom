using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public int maxHandSize = 10;

    public List<Card> cardsDeck;
    public List<Card> cardsHand;
    public List<Card> cardsPlay;
    public List<int> cardsMods;

    public Character player;
    public Character enemy;

    public GameObject handArea;
    public GameObject playArea;
    public GameObject cardHolder;

    public GameObject cardPrefab;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cardsDeck = new List<Card>(gameManager.playerDeck);

        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(cardPrefab, cardHolder.transform);
            temp.SetActive(false);
        }
    }

    private void OnEnable()
    {
        Init();
        // UI setup, hp and such
    }

    public void Init()
    {

        Draw(5);
    }

    public GameObject GetCardObject()
    {
        if(cardHolder.transform.childCount <= 0)
            for (int i = 0; i < 10; i++)
            {
                GameObject temp = Instantiate(cardPrefab, cardHolder.transform);
                temp.SetActive(false);
            }

        return cardHolder.transform.GetChild(0).gameObject;
    }

    public void Draw(int num = 1)
    {
        for (int i = 0; i < num; i++)
        {
            if(cardsHand.Count >= maxHandSize)
            {
                Debug.Log("Hand full");
                return;
            }

            Card tempCard = GetCard();
            cardsDeck.Remove(tempCard);
            cardsHand.Add(tempCard);

            GameObject cardObject = GetCardObject();
            cardObject.transform.SetParent(handArea.transform);
            cardObject.GetComponent<CardDisplay>().DisplayCard(tempCard);
        }
    }

    public Card GetCard(int id = -1)
    {
        Card selectedCard = null;
        if(id < 0)
        {
            selectedCard = cardsDeck[Random.Range(0, cardsDeck.Count)];
        }
        return selectedCard;
    }

    public void PlayCards()
    {

    }
}
