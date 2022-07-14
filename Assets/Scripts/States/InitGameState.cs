using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;
using System.IO;

public class InitGameState : State
{
    public PlayingState _PlayingState;
    public List<string> WordList;
    public GameObject _GameOverView;

    public override void OnStateEnter()
    {
        if (WordList == null || WordList.Count == 0)
        {
            string[] AllWords = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "words.txt"));
            WordList = new List<string>(AllWords);
        }
        
        _GameOverView.SetActive(false);
        _PlayingState.CorrectAnswer = WordList[Random.Range(0, WordList.Count)].ToUpper();
        Debugger.Instance.Log("New Game: " + _PlayingState.CorrectAnswer);
    }

    public override State OnUpdate()
    {
        State rtn = _PlayingState;

        return rtn;
    }

    public override void OnStateExit()
    {

    }
}
