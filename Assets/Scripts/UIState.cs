using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent (typeof(CanvasGroup))]
public class UIState : MonoBehaviour
{
    [HideInInspector] [SerializeField] CanvasGroup CG;
    [SerializeField] GameManager.State thisState;

    private void Reset()
    {
        CG = GetComponent<CanvasGroup>();
    }
    private void Awake()
    {
        GameManager.EventChangeState += OnChange;
    }

    void Start()
    {
        OnChange();
    }
    
    void OnChange()
    {
        if (thisState == GameManager.CurrentState) Show();
        else Hide();
    }
    void Show()
    {
        CG.alpha = 1;
        CG.interactable = true;
        CG.blocksRaycasts = true;
    }
    void Hide()
    {
        CG.alpha = 0;

        CG.interactable = false;
        CG.blocksRaycasts = false;
    }
}
