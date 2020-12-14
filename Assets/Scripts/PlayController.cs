using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayController : MonoBehaviour
{
    
    [SerializeField] private RectTransform contentElements;
    [SerializeField] private List<Element> elementPrefabs;
    [SerializeField] private TMP_InputField countElementsText;
    public List<Element> allElements;
    int countElements=100;

    private float delay;
    public Vector3 CurrentPos { get; private set; }
    RectTransform LevelsCenter;
    public int _selectedLevelId = 0;
    private int fingerID = -1;
    private int oldIndex=0;
    public void StartGame()
    {
       
        bool parseSucess= int.TryParse(countElementsText.text,out countElements);
        if (parseSucess)
        {

            Instantiate();
            GameManager.CurrentState = GameManager.State.Play;
        }
        else
        {
            countElements = 100;
            Instantiate();
            GameManager.CurrentState = GameManager.State.Play;
        }
    }

    void Awake()
    {
#if !UNITY_EDITOR
     fingerID = 0; 
#endif
    }
    private void Instantiate()
    {
        int tempIndexPrefabs = 0;
        allElements = new List<Element>();
        for (int i = 0; i < countElements; i++)
        {
            Element tempElement;
            tempElement = Instantiate(elementPrefabs[tempIndexPrefabs], contentElements);
            tempElement.Ini(i, new Vector2(0, 900+( -200* i)));
            allElements.Add(tempElement);
            tempIndexPrefabs++;
            if (tempIndexPrefabs >= elementPrefabs.Count)
            {
                tempIndexPrefabs = 0;
            }
        }

        LevelsCenter = contentElements;
    }

    void Update()
    {
       
        if (GameManager.CurrentState == GameManager.State.Play)
        {
            if (allElements.Count > 0)
            {
                if (Input.GetMouseButtonDown(0))// первый клик
                {
                    CurrentPos = Input.mousePosition - LevelsCenter.transform.position;
                    delay = 0;

                }
                else
                if (Input.GetMouseButton(0))// когда зажато
                {
                    if (Mathf.Abs(CurrentPos.y - Input.mousePosition.y) > Screen.height * 0.1f)
                        delay += Time.deltaTime;
                    LevelsCenter.transform.position = Vector3.Lerp(LevelsCenter.transform.position, new Vector3(LevelsCenter.transform.position.x, -CurrentPos.y + Input.mousePosition.y, 0), Time.deltaTime * 10);

                }
                else
                if (Input.GetMouseButtonUp(0)) // когда отпустило
                {
                    if (EventSystem.current.IsPointerOverGameObject(fingerID)) // is the touch on the GUI
                    {
                        return;
                    }
                    if (delay > 0.1f)
                    {
                        CurrentPos = Input.mousePosition;
                        delay = 0;
                        float min = 100000;
                        for (int i = 0; i < allElements.Count; i++)
                        {
                            float dist = Vector2.Distance(allElements[i].rect.position, new Vector2( allElements[i].rect.position.x, Screen.height / 2));
                            if (dist < min)
                            {
                                min = dist;
                                _selectedLevelId = i;
                                
                            }
                        }
                    }

                }
                else
                {
                    if (_selectedLevelId < allElements.Count)
                    {
                        LevelsCenter.localPosition = Vector3.Lerp(LevelsCenter.localPosition,
                            new Vector2(0, -350 + (200 * _selectedLevelId)), Time.deltaTime*Vector2.Distance(LevelsCenter.localPosition, new Vector2(0, -350 + (200 * _selectedLevelId)))/500f+0.01f);
                        oldIndex++;
                       

                    }
                    else
                    {
                        Debug.Log("Index not found");
                    }
                }
            }
        }
    }

    public void RefreshAfterDelete(int index)
    {
        for (int i = index; i < allElements.Count; i++)
        {
            allElements[i].Ini(i, new Vector2(0, 900 + (-200 * i)));
        }
    }
}
