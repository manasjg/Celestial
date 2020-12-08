using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaStructureButton : MonoBehaviour
{

    public float MoveTime;
    float MoveTimer = 0;
    public float UpYPos=0;
    bool MoveToggle = false;
    float DownYPos;
    bool MovePanel = false;
    RectTransform RTransform;
    public GameObject GameInfoPanel;
   
    void Start()
    {
        RTransform = GetComponent<RectTransform>();
        DownYPos = RTransform.anchoredPosition.y;
    }

    void Update()
    {
        if (MovePanel)
        {
            if (MoveTimer < MoveTime)
            {
                MoveTimer += Time.deltaTime;
            }
            else
            {
                MovePanel = false;
            }
            float YPos;
            if (MoveToggle)
            {
                YPos = Mathf.Lerp(DownYPos, UpYPos, MoveTimer/MoveTime);
               
            }
            else
            {
                YPos = Mathf.Lerp(UpYPos, DownYPos, MoveTimer/MoveTime);
            }
            RTransform.anchoredPosition = new Vector2(RTransform.anchoredPosition.x, YPos);
        }
    }

    public void SetMoveToggle()
    {
        MoveToggle = !MoveToggle;
        if (MoveToggle)
        {
            GameInfoPanel.SetActive(false);
        }
        else
        {
            GameInfoPanel.SetActive(true);
        }
        MovePanel = true;
        MoveTimer = 0;
    }
}
