using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CardManager : MonoBehaviour
{
    public List<ScriptableObject_CardData> cardDatabase = new List<ScriptableObject_CardData>();
    public List<ScriptableObject_CardData> playerHand = new List<ScriptableObject_CardData>();
    public Transform cardSpawnPoint; // Assign the transform where cards should be instantiated.

    public GameObject cardPrefab; // Assign the card prefab in the Inspector.
    public GameObject cardParent; // Assign the card parent GameObject in the Inspector.


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
        }
        else
        {
            Debug.Log("No more cards in the database.");
        }
    }





}
