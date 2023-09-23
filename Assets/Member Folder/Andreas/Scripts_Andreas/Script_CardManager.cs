using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CardManager : MonoBehaviour
{
    public List<ScriptableObject_CardData> cardDatabase = new List<ScriptableObject_CardData>();
    public List<ScriptableObject_CardData> playerHand = new List<ScriptableObject_CardData>();

    public void DrawCard()
    {
        if (cardDatabase.Count > 0)
        {
            int randomIndex = Random.Range(0, cardDatabase.Count);
            ScriptableObject_CardData drawnCard = cardDatabase[randomIndex];
            cardDatabase.RemoveAt(randomIndex);
            playerHand.Add(drawnCard);
            // Handle displaying the drawn card here (e.g., instantiate a prefab)
        }
        else
        {
            Debug.Log("No more cards in the database.");
        }
    }
}
