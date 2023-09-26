using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Script_CardDisplay : MonoBehaviour
{
    public ScriptableObject_CardData[] cardDataArray; // Create an array of cardData to store the data of the cards
    public Image cardImage;
    public TextMeshProUGUI cardTitleText;
    public TextMeshProUGUI descriptionText;

    public void DisplayCard(ScriptableObject_CardData cardData)
    {
        cardImage.sprite = cardData.cardImage;
        cardTitleText.text = cardData.cardName;
        descriptionText.text = cardData.description;
        gameObject.SetActive(true);
    }

    public void HideCard()
    {
        gameObject.SetActive(false);
    }

    /*
    private void Start()
    {
        DisplayCard(cardDataArray[0]);
    }
    */

}
