using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterBox : MonoBehaviour
{
    public Image Icon;
    public TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        ClearText();
    }
    public string GetText()
    {
        return Text.text;
    }

    public void ClearText()
    {
        Text.text = "";
    }

    public void SetText(string text)
    {
        Text.text = text;
    }
    public void SetSprite(Sprite sprite)
    {
        Icon.sprite = sprite;
    }
    public Sprite GetSprite()
    {
        return Icon.sprite;
    }

    public void SetTextColor(Color color)
    {
        Text.color = color;
    }
}
