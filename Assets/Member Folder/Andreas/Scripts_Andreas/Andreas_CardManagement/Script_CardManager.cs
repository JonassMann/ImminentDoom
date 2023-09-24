using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Script_CardManager : MonoBehaviour
{
    public List<ScriptableObject_CardData> initialCardDatabase = new List<ScriptableObject_CardData>(); // The initial card data list.
    private List<ScriptableObject_CardData> cardDatabase = new List<ScriptableObject_CardData>(); // The current card data list.
    public List<ScriptableObject_CardData> playerHand = new List<ScriptableObject_CardData>();
    public List<ScriptableObject_CardData> discardPile = new List<ScriptableObject_CardData>(); // Discard pile for processed cards.
    public GameObject cardPrefab;
    public GameObject cardParent;
    public Script_Enemy_Entity targetEntity;




    private List<ScriptableObject_CardData> drawnCards = new List<ScriptableObject_CardData>(); // Store drawn cards.


    private void Start()
    {
        // Initializes the card database with the initial data.
        cardDatabase.AddRange(initialCardDatabase);
    }


    public void DrawCard()
    {
        if (cardDatabase.Count > 0)
        {
            int randomIndex = Random.Range(0, cardDatabase.Count);
            ScriptableObject_CardData drawnCard = cardDatabase[randomIndex];
            cardDatabase.RemoveAt(randomIndex);
            playerHand.Add(drawnCard);

            // Instantiate the drawn card as a child of the specified card parent GameObject.
            GameObject newCard = Instantiate(cardPrefab, cardParent.transform);

            // Get the CardDisplay component of the new card and display the drawn card's data.
            Script_CardDisplay cardDisplay = newCard.GetComponent<Script_CardDisplay>();
            cardDisplay.DisplayCard(drawnCard);

            // Add the drawn card to the list in the correct order.
            drawnCards.Add(drawnCard);
        }
        else
        {
            Debug.Log("No more cards in the database.");
            ReloadCardData(); // Reloads the card data when empty.
        }
    }

    public void ProcessNextCard()
    {
        if (drawnCards.Count > 0)
        {
            ScriptableObject_CardData nextCard = drawnCards[0]; // Get the first card in the list.
            drawnCards.RemoveAt(0); // Remove the processed card from the list.
            ApplyCardEffect(nextCard); // Apply the card effect.

            // Check if the card's parent is the "CardDropArea" before processing it.
            if (nextCard.transform.parent == cardParent.transform)
            {
                ApplyCardEffect(nextCard);
                discardPile.Add(nextCard);
            }
            else
            {
                Debug.Log("Card is not in the CardDropArea and will not be processed.");
            }





        }
        else
        {
            Debug.Log("No more cards to process.");
        }
    }


    private void ReloadCardData()
    {
        if (playerHand.Count < 3) // Check if the hand has fewer than 3 cards.
        {
            cardDatabase.AddRange(initialCardDatabase); // Reload the card data.
        }
    }



    public void ApplyCardEffect(ScriptableObject_CardData cardData)
    {
        // Apply card stats to the target entity (enemy or player).
        targetEntity.TakeDamage(cardData.damage);
        targetEntity.Heal(cardData.healing);
        // Add any other card effects here.
    }

    public void ReloadCardDataButton()
    {
        ReloadCardData();
    }

}
