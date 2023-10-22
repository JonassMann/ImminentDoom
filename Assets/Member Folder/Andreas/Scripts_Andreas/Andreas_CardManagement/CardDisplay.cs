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

    public void DisplayCard(Card cardData)
    {
        cardImage.sprite = cardData.cardImage;
        cardTitleText.text = cardData.cardName;

        StringBuilder sb = new StringBuilder();
        string[] parts = cardData.description.Split('{');
        sb.Append(parts[0]);

        for (int i = 1; i < parts.Length; i++)
        {
            string valueString = parts[i][..1];

            if (int.TryParse(valueString, out int value))
                sb.Append(cardData.GetEffectValue(value));
            else
            {
                Debug.Log($"Parse error: {cardData.name}");
                sb.Append("null");
            }

            sb.Append(parts[i][2..]);
        }

        descriptionText.text = sb.ToString();

        gameObject.SetActive(true);
    }
}
