using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    [SerializeField] private Key[] Keys;
    [SerializeField] private Sprite WhiteIcon;
    [SerializeField] private Sprite GreenIcon;
    [SerializeField] private Sprite YellowIcon;
    [SerializeField] private Sprite GreyIcon;

    private KeyCode[] KeyOrder = new KeyCode[26]
    { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M};

    // Start is called before the first frame update
    void Start()
    {
        if(KeyOrder != null && KeyOrder.Length != 0)
        {
            for (int i = 0; i < KeyOrder.Length; i++)
            {
                int x = i;

                for (int j = 0; j < InputManager.Instance.AllowedLetters.Length; j++)
                {
                    if (InputManager.Instance.AllowedLetters[j] == KeyOrder[i])
                    {
                        x = j;
                        break;
                    }
                }

                Keys[i].Button.onClick.AddListener(delegate { Clicked(x); });
                Keys[i].Image.sprite = WhiteIcon;
                Keys[i].Text.text = KeyOrder[i].ToString().ToUpper();
                Keys[i].Text.color = Color.black;
            }
        }

        gameObject.SetActive(false);
    }

    public void Clear()
    {
        if (Keys != null && Keys.Length != 0)
        {
            for (int i = 0; i < Keys.Length; i++)
            {
                Keys[i].Image.sprite = WhiteIcon;
                Keys[i].Text.text = KeyOrder[i].ToString().ToUpper();
                Keys[i].Text.color = Color.black;
            }
        }
    }

    public void SetLetter(string letter, string color)
    {
        Key key = null;
        for (int i = 0; i < Keys.Length; i++)
        {
            if (Keys[i].Text.text.ToUpper() == letter.ToUpper())
            {
                key = Keys[i];
            }
        }

        if(key != null)
        {
            switch (color)
            {
                case "GREEN":
                    key.SetSprite(GreenIcon);
                    break;
                case "YELLOW":
                    key.SetSprite(YellowIcon);
                    break;
                case "":
                    key.SetSprite(GreyIcon);
                    break;
            }

            key.SetTextColor(Color.white);
        }
    }

    private void Clicked(int i)
    {
        InputManager.Instance.ForceInput(InputManager.Instance.AllowedLetters[i]);
    }

    private int GetKeyboardIndex(KeyCode code)
    {
        int rtn = -1;

        for (int i = 0; i < KeyOrder.Length; i++)
        {
            if (KeyOrder[i] == code)
            {
                rtn = i;
            }
        }

        return rtn;
    }
}
