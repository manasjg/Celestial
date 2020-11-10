using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFadeScript : MonoBehaviour
{

    public float FadeTime;
    public SceneMan SM;
    Image Curr;
    bool StartFade = false;
    float FadeTimer = 0;
    public int SceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        Curr = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartFade)
        {
            if (FadeTimer < FadeTime)
            {
                FadeTimer += Time.unscaledDeltaTime;
                float Alpha = (FadeTimer / FadeTime);
                Curr.color = new Color(0, 0, 0, Alpha);
            }
            else
            {
                StartFade = false;
                SM.LoadScene(SceneToLoad);
            }
        }
    }

    public void SetFade()
    {
        StartFade = true;
    }
}
