using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    public static event Action EventChangeState;

    public enum State
    {
        Menu,
        Play
    }

    private static State _currentState;

    public static State CurrentState
    {
        get => _currentState;
        set
        {
            _currentState = value;
            if (EventChangeState != null) EventChangeState();
            Debug.Log("State changed " + _currentState + "=>" + value);
        }
    }

    #endregion

    private void Awake()
    {
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            DestroyImmediate(this);
            Debug.Log("<color: red> ДВА СКРИПТА ГЕЙМ МЕНЕДЖЕР!!! </color>");
        }


    }
}
