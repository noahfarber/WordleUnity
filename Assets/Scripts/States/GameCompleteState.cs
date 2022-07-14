using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;
using TMPro;

public class GameCompleteState : State
{
    [SerializeField] private GameObject _GameOverView;
    [SerializeField] private TextMeshProUGUI _GameOverText;
    [SerializeField] private TextMeshProUGUI _FinalAnswer;

    public override void OnStateEnter()
    {
        _GameOverView.SetActive(true);
    }

    public override State OnUpdate()
    {
        State rtn = null;
        return rtn;
    }

    public override void OnStateExit()
    {
        _GameOverView.SetActive(false);
    }

    public void SetMessage(string text)
    {
        _GameOverText.text = text;
    }
    public void SetAnswer(string answer)
    {
        _FinalAnswer.text = answer;
    }
}
