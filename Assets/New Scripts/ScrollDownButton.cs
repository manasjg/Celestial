using UnityEngine;
using UnityEngine.UI;

public class ScrollDownButton : MonoBehaviour
{
    public ScrollRect ScrollList;
    public float ScrollSpeed=100;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ScrollDown);
    }
    
    void ScrollDown()
    {
        ScrollList.velocity = new Vector2(0, ScrollSpeed);
    }
 
}
