using UnityEngine;

public class SateliteUIInfoHolder : MonoBehaviour
{
    public Sprite[] planetImages;
    public string[] planetNames;

    public static SateliteUIInfoHolder instance;

    void Start()
    {
        instance = this;
    }
}
