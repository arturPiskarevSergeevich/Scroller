using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RefreshIndex : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField findField;

    private PlayController controller;

    private void Awake()
    {
        controller = this.transform.root.GetComponent<UIManager>().controller;
    }
    public void Refresh()
    {
        int findIndex = 0;
        bool succesParse = int.TryParse(findField.text, out findIndex);
        if (succesParse)
        {

            Element tempElement = controller.allElements[findIndex];
            Element currentElement = this.GetComponent<Element>();

            int currentIndex = currentElement.indexInList;
            Vector2 currentPos = currentElement.rect.anchoredPosition;
            
            controller.allElements[findIndex] = currentElement;
            controller.allElements[findIndex].Ini(tempElement.indexInList, tempElement.rect.anchoredPosition);
            

            controller.allElements[currentIndex] = tempElement;
            controller.allElements[currentIndex].Ini(currentIndex,currentPos);
           
        }
        else
        {
           
        }

    }
}
