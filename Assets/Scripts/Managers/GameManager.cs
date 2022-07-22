using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public event Action<GameState> OnBeforeStateChanged;
    public event Action<GameState> OnAfterStateChanged;

    public GameState State { get; private set; }

    private void Start()
    {
        ChangeState(GameState.Starting);
    }

    public void ChangeState(GameState newState)
    {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState)
        {
            case GameState.Starting:
                break;
            case GameState.Playing:
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
        }

        OnAfterStateChanged?.Invoke(newState);
    }
}

[Serializable]
public enum GameState
{
    Starting,
    Playing,
    Win,
    Lose
}
