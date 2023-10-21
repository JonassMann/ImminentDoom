using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<Card> cardsDeck;
    public List<Card> cardsHand;
    public List<Card> cardsPlay;
    public List<int> cardsMods;

    public Character player;
    public Character enemy;

    public GameObject handArea;
    public GameObject playArea;

    [ShowInInspector] private GameObject cardPrefab;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cardsDeck = new List<Card>(gameManager.playerDeck);
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

    public void Draw(int num = 1)
    {

    }

    public void GetCard()
    {

    }

    public void PlayCards()
    {

    }
}
