using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class URL : MonoBehaviour, IPointerClickHandler
{
    public string Url;
    void Start()
    {
        GetComponent<Text>().color = Color.cyan;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL(Url);
    }
}
