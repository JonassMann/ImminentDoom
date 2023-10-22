using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class Script_CardManager : MonoBehaviour
{
    public List<ScriptableObject_CardData> cardDatabase = new List<ScriptableObject_CardData>(); // The current card data list.
    public List<ScriptableObject_CardData> playerHand = new List<ScriptableObject_CardData>();
    public List<ScriptableObject_CardData> discardPile = new List<ScriptableObject_CardData>(); // Discard pile for processed cards.
    public GameObject cardPrefab;
    public GameObject cardParentHand;
    public GameObject cardParentPlayArea;
    public Script_Enemy_Entity targetEntity;
    public Script_Player_Entity targetPlayer;





    private List<ScriptableObject_CardData> drawnCards = new List<ScriptableObject_CardData>(); // Store drawn cards.


    private void Start()
    {

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
            GameObject newCard = Instantiate(cardPrefab, cardParentHand.transform);

            // Get the CardDisplay component of the new card and display the drawn card's data.
            CardDisplay cardDisplay = newCard.GetComponent<CardDisplay>();
            // cardDisplay.DisplayCard(drawnCard);

            // Add the drawn card to the list in the correct order.
            drawnCards.Add(drawnCard);
        }
    }

    public void ProcessNextCard()
    {
        foreach (Transform t in cardParentPlayArea.transform)
        {
            //ApplyCardEffect(t.GetComponent<CardDisplay>().cardData);
        }
    }

    public void ApplyCardEffect(ScriptableObject_CardData cardData)
    {
        foreach (var effect in cardData.cardEffects)
        {
            switch (effect.effectType)
            {
                case CardEffectType.Damage:
                    targetEntity.TakeDamage(effect.value);
                    break;
                case CardEffectType.Healing:
                    targetEntity.Heal(effect.value);
                    break;
                case CardEffectType.Block:
                    targetPlayer.Block(effect.value);
                    break;
                default:
                    Debug.Log("No effect type selected.");
                    break;
            }
        }
    }
}
