using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{
    [SerializeField] private TMP_InputField text;
    public RectTransform rect;
    public int indexInList = 0;
    public void Ini(int currentIndex,Vector2 pos)
    {
        rect.anchoredPosition=new Vector2(pos.x,pos.y);
        indexInList = currentIndex;
        text.text = currentIndex.ToString();
    }
}
