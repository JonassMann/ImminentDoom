using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text;

public class CardDisplay : MonoBehaviour
{
    public Image cardImage;
    public TextMeshProUGUI cardTitleText;
    public TextMeshProUGUI descriptionText;

    public Card card;

    public void DisplayCard(Card cardData)
    {
        card = cardData;
        UpdateCard();
    }

    public void UpdateCard(int modLevel = 0)
    {
        cardImage.sprite = card.cardImage;
        cardTitleText.text = card.cardName;

        StringBuilder sb = new StringBuilder();
        string[] parts = card.description.Split('{');
        sb.Append(parts[0]);

        for (int i = 1; i < parts.Length; i++)
        {
            string valueString = parts[i][..1];

            if (int.TryParse(valueString, out int value))
                sb.Append(card.GetEffectValue(value, modLevel));
            else
            {
                Debug.Log($"Parse error: {card.name}");
                sb.Append("null");
            }

            sb.Append(parts[i][2..]);
        }

        descriptionText.text = sb.ToString();

        gameObject.SetActive(true);
    }
}
