using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CameraMovement : MonoBehaviour
{
    public Vector3 CameraAnimEndPos;
    Vector3 StartPos;
    public float initAnimTime;
    float initStartTimer = 0;
    public GameObject Sun;
    float DistanceFromSun;
    bool StartMovement = false;
    bool SelectedPlanet = false;
    float YAngle = 0;
    float XAngle = 0;
    public float RotateSpeed=5f;
    float XPos = 0;
    float YPos = 0;
    public float PlanetSelectDistance;
    Vector3 SelectedPlanetEndPos;
    float SelectedPlanetAnimTime = 2f;
    float SelectedAnimTimer = 0;
    GameObject SelectedPlanetGO = null;
    bool MoveBackToStartPos = false;
    float MoveBackTimer = 0;
    float MoveBackTime=2f;
    float stopMovementTimer;
    float stopRotationTime = 2f;
    float DoubleClickTime = 0.3f;
    float DoubleClickTimer = 0;
    int numberOfClicks = 0;
    public GameObject FadePanel;
    bool PlanetReached = false;
    public GameObject MoveBackButton;
    Vector3 RechDiff;
    bool StartDragFlag=false;
    public Text DragText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=1f;
        StartPos = transform.position;
        MoveBackButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (initStartTimer < initAnimTime)
        {
            initStartTimer += Time.deltaTime;
            transform.position = Vector3.Lerp(StartPos, CameraAnimEndPos,Mathf.SmoothStep(0f,1f,initStartTimer/initAnimTime));
    
          
          
        }
        else if(!StartMovement)
        {
            Debug.Log("Setting");
            DistanceFromSun = Vector3.Distance(new Vector3(transform.position.x,0, transform.position.z), new Vector3(Sun.transform.position.x, 0, Sun.transform.position.z));
            StartMovement = true;
            YAngle = Mathf.Atan2(Sun.transform.position.z - transform.position.z, Sun.transform.position.x - transform.position.x)*Mathf.Rad2Deg;
            XAngle = Mathf.Atan2(Sun.transform.position.y - transform.position.y, Sun.transform.position.z - transform.position.z) * Mathf.Rad2Deg;

        }
        if (StartMovement)
        {
             
            if (Input.GetMouseButtonDown(0))
            {
                XPos = Input.mousePosition.x;
                YPos = Input.mousePosition.y;
                RaycastHit hit;
               
                if (!EventSystem.current.IsPointerOverGameObject())
                { 
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                    {
                        
                        SetSelectedPlanet(hit.transform.gameObject);
                    }
                   if(Input.touchCount==0)
                   StartDragFlag = true;
                }
            }
            if (Input.GetMouseButton(0))
            {

                if (StartDragFlag)
                {
                    if (!SelectedPlanet)
                    {
                        float XDiff = (Input.mousePosition.x - XPos) * 0.01f;
                        float YDiff = (Input.mousePosition.y - YPos) * 0.01f;



                        YAngle -= XDiff * Time.deltaTime * RotateSpeed;
                        float XPosition = Sun.transform.position.x - (Mathf.Cos(YAngle * Mathf.Deg2Rad) * DistanceFromSun);
                        float ZPosition = Sun.transform.position.z - (Mathf.Sin(YAngle * Mathf.Deg2Rad) * DistanceFromSun);
                        float YPosition = transform.position.y - (YDiff * RotateSpeed * 0.2f * Time.deltaTime);
                        YPosition = Mathf.Clamp(YPosition, 1, 4);

                        transform.position = new Vector3(XPosition, YPosition, ZPosition);


                    }
                }
               
            }
            if (Input.GetMouseButtonUp(0))
            {
                StartDragFlag = false;

            }
                if (Input.touchCount == 1)
            {
                Touch t = Input.GetTouch(0);
                if(t.phase == TouchPhase.Began)
                {
                    Debug.Log(EventSystem.current.IsPointerOverGameObject(t.fingerId));
                    if (!IsPointerOverUIObject())
                    {
                        RaycastHit hit;
                        if (Physics.Raycast(Camera.main.ScreenPointToRay(t.position), out hit, Mathf.Infinity))
                        {
                            SetSelectedPlanet(hit.transform.gameObject);
                        }
                        StartDragFlag = true;
                    }
                    DragText.text = IsPointerOverUIObject().ToString();
                }
                if(t.phase == TouchPhase.Moved)
                {
                    //Debug.Log(EventSystem.current.IsPointerOverGameObject(t.fingerId));
                    if (StartDragFlag)
                    {
                      

                            if (!SelectedPlanet)
                            {
                                YAngle -= t.deltaPosition.x * Time.deltaTime * RotateSpeed;


                                float XPosition = Sun.transform.position.x - Mathf.Cos(YAngle * Mathf.Deg2Rad) * DistanceFromSun;
                                float ZPosition = Sun.transform.position.z - Mathf.Sin(YAngle * Mathf.Deg2Rad) * DistanceFromSun;
                                float YPosition = transform.position.y - (t.deltaPosition.y * RotateSpeed * 0.2f * Time.deltaTime);
                                YPosition = Mathf.Clamp(YPosition, 1, 4);
                                transform.position = new Vector3(XPosition, YPosition, ZPosition);
                            }
                      
                    }
                }
                if (t.phase == TouchPhase.Ended)
                {
                    StartDragFlag = false;
                }
            }
        }



        if (!SelectedPlanet)
        {
            if (!MoveBackToStartPos)
            {
                transform.LookAt(Sun.transform.position);
            }
          
        }
        else
        {
           // transform.LookAt(SelectedPlanetGO.transform.position);
            if (SelectedAnimTimer < SelectedPlanetAnimTime)
            {
                SelectedAnimTimer += Time.deltaTime;
             
                Vector3 targetDirection = SelectedPlanetGO.transform.position - transform.position;

                // The step size is equal to speed times frame time.
                float singleStep = RotateSpeed *0.05f* Time.deltaTime;

                // Rotate the forward vector towards the target direction by one step
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

                // Draw a ray pointing at our target in
                Debug.DrawRay(transform.position, newDirection, Color.red);
               
                // Calculate a rotation a step closer to the target and applies rotation to this object
                transform.rotation = Quaternion.LookRotation(newDirection);
                transform.position = Vector3.Lerp(StartPos, SelectedPlanetEndPos, Mathf.SmoothStep(0f, 1f, SelectedAnimTimer / SelectedPlanetAnimTime));
            }
            else
            {
              
                PlanetReached = true;

                MoveBackButton.SetActive(true);

               
            }
        }


        if (MoveBackToStartPos)
        {
            if (MoveBackTimer < MoveBackTime)
            {
                MoveBackTimer += Time.deltaTime;

                if (MoveBackTimer < stopRotationTime)
                {
                    Vector3 targetDirection = Sun.transform.position - transform.position;

                    // The step size is equal to speed times frame time.
                    float singleStep = RotateSpeed * 0.05f * Time.deltaTime;

                    // Rotate the forward vector towards the target direction by one step
                    Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

                    // Draw a ray pointing at our target in
                    Debug.DrawRay(transform.position, newDirection, Color.red);

                    // Calculate a rotation a step closer to the target and applies rotation to this object
                    transform.rotation = Quaternion.LookRotation(newDirection);
                    MoveBackButton.SetActive(false);
                }
                else
                {
                    transform.LookAt(Sun.transform.position);
                    MoveBackButton.SetActive(false);
                    foreach (GameObject GO in GameObject.FindGameObjectsWithTag("CelestialBody"))
                    {
                        if (GO.GetComponent<PlanetRevolver>() != null)
                        {
                            GO.GetComponent<PlanetRevolver>().startRevolving = true;
                        }
                    }

                }
                transform.position = Vector3.Lerp(SelectedPlanetEndPos, StartPos, Mathf.SmoothStep(0f, 1f, MoveBackTimer / MoveBackTime));
            }
            else
            {
                Debug.Log("Start Movement");
                MoveBackToStartPos = false;
                DistanceFromSun = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(Sun.transform.position.x, 0, Sun.transform.position.z));
                StartMovement = true;
                YAngle = Mathf.Atan2(Sun.transform.position.z - transform.position.z, Sun.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
                XAngle = Mathf.Atan2(Sun.transform.position.y - transform.position.y, Sun.transform.position.z - transform.position.z) * Mathf.Rad2Deg;
                SelectedPlanet = false;
                PlanetReached = false;
                MoveBackButton.SetActive(false);
            }
        }



        if (SelectedPlanet && PlanetReached)
        {
           
            if (Input.GetMouseButtonDown(0))
            {
                XPos = Input.mousePosition.x;
                YPos = Input.mousePosition.y;
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                {
                    numberOfClicks++;
                    if (numberOfClicks == 1)
                    {
                        DoubleClickTimer = 0;
                    }
                    if (numberOfClicks > 1)
                    {
                        Time.timeScale = 0;
                        PlayerPrefs.SetInt("SelectedPlanet", hit.transform.gameObject.GetComponent<PlanetInfo>().ID);
                        FadePanel.GetComponent<PanelFadeScript>().SetFade();
                    }
                }
            }
            
            if (Input.touchCount == 1)
            {
                Touch t = Input.GetTouch(0);
                if (t.phase == TouchPhase.Began)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(t.position), out hit, Mathf.Infinity))
                    {

                        numberOfClicks++;
                        if (numberOfClicks == 1)
                        {
                            DoubleClickTimer = 0;
                        }
                        if (numberOfClicks > 1)
                        {
                            Time.timeScale = 0;
                            PlayerPrefs.SetInt("SelectedPlanet",hit.transform.gameObject.GetComponent<PlanetInfo>().ID);
                         
                            FadePanel.GetComponent<PanelFadeScript>().SetFade();
                        }
                    }
                }
            }
             if (numberOfClicks == 1)
            {
                if (DoubleClickTimer < DoubleClickTime)
                {
                    DoubleClickTimer += Time.deltaTime;
                }
                else
                {
                    numberOfClicks = 0;
                }
            }
        }
        
    }



    public void BackToStartPos()
    {
        if (SelectedPlanet)
        {
            MoveBackButton.SetActive(false);
            MoveBackTimer = 0;
            StartMovement = false;
            MoveBackToStartPos = true;
            PlanetReached = false;
            float Dist=(Vector3.Distance(SelectedPlanetGO.transform.position, Sun.transform.position));
            if (Dist < 1)
            {
                stopRotationTime = 1f + Dist;
            }
            else
            {
                stopRotationTime = 2f;
            }
        }
    }


    public void SetSelectedPlanet(GameObject PlanetGO)
    {
        if (!SelectedPlanet)
        {
            SelectedPlanet = true;
            SelectedAnimTimer = 0;
            SelectedPlanetGO = PlanetGO;
            StartPos = transform.position;
            Vector3 Dir = (transform.position - PlanetGO.transform.position).normalized;

            SelectedPlanetEndPos = PlanetGO.transform.position + (Dir * PlanetSelectDistance);
            foreach (GameObject GO in GameObject.FindGameObjectsWithTag("CelestialBody"))
            { 
                if (GO.GetComponent<PlanetRevolver>() != null)
                {
                    GO.GetComponent<PlanetRevolver>().startRevolving = false;
                }
            }
        }


      
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.touches[0].position.x, Input.touches[0].position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
