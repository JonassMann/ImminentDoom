using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/PlayerCard")]
public class Card : ScriptableObject
{
    public string cardName;
    public CardType cardType;
    public CardRarity cardRarity;
    public CardTarget cardTarget;
    [TextArea(3,10)] public string description;
    public Sprite cardImage;
    public int level = 0;

    public List<CardModifier> modifiers;
    public List<CardEffect> cardEffects;

    // OnDraw
    // OnPlay
    // OnDiscard

    public int GetEffectValue(int pos)
    {
        return (int)(cardEffects[pos].value + (cardEffects[pos].scaling*level));
    }
}

[System.Serializable]
public class CardEffect
{
    public CardEffectType effectType;
    public float value;
    public float scaling;
}

[System.Serializable]
public class CardModifier
{
    public int position;
    public CardType cardType;
    public int modValue;
}

public enum CardType // Create an enum to store the type of card
{
    None,
    Etos,
    Patos,
    Logos,
    Kairos
}
public enum CardEffectType
{
    None,
    Damage,
    Healing,
    Block,
    //EffectSelf,
    //EffectTarget
    //  Other/ Unique
}
public enum CardRarity
{
    Basic,
    Common,
    Uncommon,
    Rare
}

public enum CardTarget
{
    None,
    Self,
    Enemy,
    All
}

public enum Buffs
{

}