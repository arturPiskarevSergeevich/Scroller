using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class DeleteIndex : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField findField;

    [SerializeField] private PlayController controller;
    public void Delete()
    {
        int findIndex = 0;
        bool succesParse = int.TryParse(findField.text, out findIndex);
        if (succesParse)
        {
            Destroy(controller.allElements[findIndex].gameObject);
            controller.allElements.RemoveAt(findIndex);
            controller.RefreshAfterDelete(findIndex);
        }
        else
        {
            Destroy(controller.allElements[0].gameObject);
            controller.allElements.RemoveAt(0);
            controller.RefreshAfterDelete(0);
        }

    }
}
