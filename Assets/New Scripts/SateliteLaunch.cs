using UnityEngine;

public class SateliteLaunch : MonoBehaviour
{
    public GameObject LaunchPosGO;
    public GameObject LandPosGO;

    public float TravelTime;
    Vector3 point1, point2, point3;

    float TravelCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        point1 = LaunchPosGO.transform.position;
        point3 = LandPosGO.transform.position;
        point2 = point1 + (point3 - point1) / 2 + Vector3.right * Mathf.Abs(point1.x - point3.x);
    }

    // Update is called once per frame
    void Update()
    {
        point1 = LaunchPosGO.transform.position;
        point3 = LandPosGO.transform.position;
        point2 = point1 + (point3 - point1) / 2 + Vector3.right * Mathf.Abs(point1.x - point3.x);

        if (TravelCounter < TravelTime)
        {
            TravelCounter += Time.deltaTime;
            float TravelExtent = TravelCounter / TravelTime;
            Vector3 m1 = Vector3.Slerp(point1, point2, Mathf.SmoothStep(0, 1, TravelExtent));
            Vector3 m2 = Vector3.Slerp(point2, point3, Mathf.SmoothStep(0, 1, TravelExtent));
            transform.position = Vector3.Slerp(m1, m2, Mathf.SmoothStep(0, 1, TravelExtent));
        }
        else
        {
            transform.position = point3;
        }
    }
}
