using UnityEngine;

public class PlanetHexagonClick : MonoBehaviour
{
    GameObject FadePanel;
    // Start is called before the first frame update
    void Start()
    {
        FadePanel = GameObject.Find("FadePanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        Debug.Log("Clicked on " + this.gameObject.name);
        FadePanel.GetComponent<PanelFadeScript>().SetFade();
    }
}
