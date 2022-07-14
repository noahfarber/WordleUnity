using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputBox : MonoBehaviour
{
    public LetterBox    [] Letters;
    [SerializeField] private Sprite WhiteIcon;
    [SerializeField] private Sprite GreenIcon;
    [SerializeField] private Sprite YellowIcon;
    [SerializeField] private Sprite GreyIcon;

    private int _InputIndex = 0;

    private void Start()
    {
        ClearBox();
    }

    public void LetterPressed(string letter)
    {
        if(_InputIndex < Letters.Length)
        {
            Letters[_InputIndex].SetText(letter);
            _InputIndex++;
        }
    }

    public void FlashColor(Color color, float duration = .2f)
    {
        for (int i = 0; i < Letters.Length; i++)
        {
            Letters[i].Icon.DOKill();
            Letters[i].Icon.color = color;
            Letters[i].Icon.DOColor(Color.white, duration);
        }
    }

    public void Backspace()
    {
        if (_InputIndex > 0)
        {
            Letters[_InputIndex - 1].SetText("");
            _InputIndex--;
        }
    }

    public void SetLetter(int index, string color)
    {
        switch(color)
        {
            case "GREEN":
                Letters[index].SetSprite(GreenIcon);
                break;
            case "YELLOW":
                Letters[index].SetSprite(YellowIcon);
                break;
            case "":
                Letters[index].SetSprite(GreyIcon);
                break;
        }

        Letters[index].SetTextColor(Color.white);
    }

    public string CurrentEntry()
    {
        string rtn = "";

        for (int i = 0; i < Letters.Length; i++)
        {
            rtn += Letters[i].GetText();
        }

        return rtn;
    }
    public bool IsSolved(int index)
    {
        return Letters[index].GetSprite() == GreenIcon;
    }

    public void ClearBox()
    {
        _InputIndex = 0;

        for (int i = 0; i < Letters.Length; i++)
        {
            Letters[i].ClearText();
            Letters[i].SetSprite(WhiteIcon);
            Letters[i].SetTextColor(Color.black);
        }
    }
}
