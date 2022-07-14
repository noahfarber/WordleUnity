using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Key : MonoBehaviour
{
    public Image Image;
    public TextMeshProUGUI Text;
    public Button Button;

    public void SetText(string text)
    {
        Text.text = text;
    }
    public void SetSprite(Sprite sprite)
    {
        Image.sprite = sprite;
    }
    public Sprite GetSprite()
    {
        return Image.sprite;
    }

    public void SetTextColor(Color color)
    {
        Text.color = color;
    }
}
