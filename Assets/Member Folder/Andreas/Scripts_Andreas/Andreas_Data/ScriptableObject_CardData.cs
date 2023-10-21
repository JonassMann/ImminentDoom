using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Card/RhetoricalCard")] // Create a new card in the menu bar under Card
public class ScriptableObject_CardData : ScriptableObject // ScriptableObjects are used to store data in a way that is easy to read and edit in the inspector (like a prefab) but without the overhead of a gameobject (no transform, no gameobject, no components) 
{
    public string cardName;
    public CardType cardType;
    public CardRarity cardRarity;
    public string description;
    public Sprite cardImage;
    public int level = 1;

    public List<int> modifiers;
    public List<CardEffect> cardEffects;

    // OnDrawEffect
    // OnPlayEffect
    // OnDiscardEffect
}

//[System.Serializable]
//public class CardEffect
//{
//    public CardEffectType effectType;
//    public float value; // The value associated with the effect (e.g., damage amount, healing amount, etc.).
//    public float scaling; // The amount the value scales with (e.g., damage amount, healing amount, etc.).
//}

//public class CardModifier
//{

//}