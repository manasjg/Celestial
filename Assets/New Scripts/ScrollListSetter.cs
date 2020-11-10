using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollListSetter : MonoBehaviour
{

    public GameObject ScrollList;
   public void SetScrollListToggle()
    {
        if (ScrollList.activeSelf)
        {
            ScrollList.SetActive(false);
        }
        else
        {
            ScrollList.SetActive(true);
        }
    }

    public void CloseScrollList()
    {
        ScrollList.SetActive(false);
    }
}
