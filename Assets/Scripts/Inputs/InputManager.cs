using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public System.Action<string> OnKeyboardPressed;
    public KeyCode[] AllowedLetters = new KeyCode[26]
    { KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z  };

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }    
    }

    void Start()
    {
        OnKeyboardPressed += KeyPress;
    }
    void OnDestroy()
    {
        OnKeyboardPressed -= KeyPress;
    }

    void KeyPress(string key)
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckKeyboardInput();
    }

    void CheckKeyboardInput()
    {
        for (int i = 0; i < AllowedLetters.Length; i++)
        {
            if (Input.GetKeyDown(AllowedLetters[i]))
            {
                OnKeyboardPressed?.Invoke(AllowedLetters[i].ToString());
            }
        }
    }

    public void ForceInput(KeyCode key)
    {
        OnKeyboardPressed?.Invoke(key.ToString());
    }
}
