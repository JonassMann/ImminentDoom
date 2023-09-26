using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Card/RhetoricalCard")] // Create a new card in the menu bar under Card
public class ScriptableObject_CardData : ScriptableObject // ScriptableObjects are used to store data in a way that is easy to read and edit in the inspector (like a prefab) but without the overhead of a gameobject (no transform, no gameobject, no components) 
{

    // Create variables to store the data of the card
    public string cardName;
    public string description;
    public Sprite cardImage;
    public Transform transform; // Reference to the card's GameObject in the scene.

    public int cost;

    public enum Type // Create an enum to store the type of card
    {
        Etos,
        Patos,
        Logos,
        Kairos
    }

    public enum Effects
    {
        Damage,
        Healing,
        Block,

    }




    

    
    







}
