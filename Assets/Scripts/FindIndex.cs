using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FindIndex : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField findField;

    [SerializeField] private PlayController controller;
    public void ToFindIndex()
    {
        int findIndex = 0;
        bool succesParse=int.TryParse(findField.text, out findIndex);
        if (succesParse)
        {
            controller._selectedLevelId = findIndex;
        }
        else
        {
            controller._selectedLevelId = 0;
        }

    }
}
