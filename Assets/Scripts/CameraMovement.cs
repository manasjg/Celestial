using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CameraMovement : MonoBehaviour
{
    public Vector3 cameraAnimEndPos;
    private Vector3 startPos;
    public float initAnimTime;
    private float initStartTimer = 0;
    public GameObject sun;
    private float distanceFromSun;
    private bool startMovement = false;
    private bool selectedPlanet = false;
    private float yAngle = 0;
    private float xAngle = 0;
    public float rotateSpeed = 2f;
    private float xPos = 0;
    private float yPos = 0;
    public float planetSelectDistance=1f;
    private Vector3 selectedPlanetEndPos;
    private float selectedPlanetAnimTime = 2f;
    private float selectedAnimTimer = 0;
    private GameObject selectedPlanetGO = null;
    private bool moveBackToStartPos = false;
    private float moveBackTimer = 0;
    private float moveBackTime = 2f;
    private float stopMovementTimer;
    private float stopRotationTime = 2f;
    private float doubleClickTime = 0.3f;
    private float doubleClickTimer = 0;
    private int numberOfClicks = 0;
    public GameObject fadePanel;
    private bool planetReached = false;
    public GameObject moveBackButton;
    private Vector3 rechDiff;
    bool startDragFlag = false;
    
    [SerializeField]
    PlayerSaveBehavior playerSaveBehavior;

    void Start()
    {
        Time.timeScale = 1f;
        startPos = transform.position;
        moveBackButton.SetActive(false);
    }

    void Update()
    {
        CameraMovementHandler();
    }

    void CameraMovementHandler()
    {
        if (initStartTimer < initAnimTime)
        {
            initStartTimer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, cameraAnimEndPos, Mathf.SmoothStep(0f, 1f, initStartTimer / initAnimTime));
        }
        else if (!startMovement)
        {
            distanceFromSun = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(sun.transform.position.x, 0, sun.transform.position.z));
            startMovement = true;
            yAngle = Mathf.Atan2(sun.transform.position.z - transform.position.z, sun.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            xAngle = Mathf.Atan2(sun.transform.position.y - transform.position.y, sun.transform.position.z - transform.position.z) * Mathf.Rad2Deg;
        }
        if (startMovement)
        {
            if (Input.GetMouseButtonDown(0))
            {
                xPos = Input.mousePosition.x;
                yPos = Input.mousePosition.y;
                RaycastHit hit;

                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                    {
                        SetSelectedPlanet(hit.transform.gameObject);
                    }
                    if (Input.touchCount == 0)
                        startDragFlag = true;
                }
            }
            if (Input.GetMouseButton(0))
            {
                if (startDragFlag)
                {
                    if (!selectedPlanet)
                    {
                        float XDiff = (Input.mousePosition.x - xPos) * 0.01f;
                        float YDiff = (Input.mousePosition.y - yPos) * 0.01f;
                        yAngle -= XDiff * Time.deltaTime * rotateSpeed;
                        float xPosition = sun.transform.position.x - (Mathf.Cos(yAngle * Mathf.Deg2Rad) * distanceFromSun);
                        float ZPosition = sun.transform.position.z - (Mathf.Sin(yAngle * Mathf.Deg2Rad) * distanceFromSun);
                        float yPosition = transform.position.y - (YDiff * rotateSpeed * 0.2f * Time.deltaTime);
                        yPosition = Mathf.Clamp(yPosition, 1, 4);
                        transform.position = new Vector3(xPosition, yPosition, ZPosition);
                    }
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                startDragFlag = false;
            }
            if (Input.touchCount == 1)
            {
                Touch t = Input.GetTouch(0);
                if (t.phase == TouchPhase.Began)
                {
                    if (!IsPointerOverUIObject())
                    {
                        RaycastHit hit;
                        if (Physics.Raycast(Camera.main.ScreenPointToRay(t.position), out hit, Mathf.Infinity))
                        {
                            SetSelectedPlanet(hit.transform.gameObject);
                        }
                        startDragFlag = true;
                    }
                }
                if (t.phase == TouchPhase.Moved)
                {
                    if (startDragFlag)
                    {
                        if (!selectedPlanet)
                        {
                            yAngle -= t.deltaPosition.x * Time.deltaTime * rotateSpeed;
                            float xPosition = sun.transform.position.x - Mathf.Cos(yAngle * Mathf.Deg2Rad) * distanceFromSun;
                            float ZPosition = sun.transform.position.z - Mathf.Sin(yAngle * Mathf.Deg2Rad) * distanceFromSun;
                            float yPosition = transform.position.y - (t.deltaPosition.y * rotateSpeed * 0.2f * Time.deltaTime);
                            yPosition = Mathf.Clamp(yPosition, 1, 4);
                            transform.position = new Vector3(xPosition, yPosition, ZPosition);
                        }

                    }
                }
                if (t.phase == TouchPhase.Ended)
                {
                    startDragFlag = false;
                }
            }
        }
  
        if (!selectedPlanet)
        {
            if (!moveBackToStartPos)
            {
                transform.LookAt(sun.transform.position);
            }
        }
        else
        {
            // transform.LookAt(SelectedPlanetGO.transform.position);
            if (selectedAnimTimer < selectedPlanetAnimTime)
            {
                selectedAnimTimer += Time.deltaTime;

                Vector3 targetDirection = selectedPlanetGO.transform.position - transform.position;

                // The step size is equal to speed times frame time.
                float singleStep = rotateSpeed * 0.05f * Time.deltaTime;

                // Rotate the forward vector towards the target direction by one step
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

                // Draw a ray pointing at our target in
                Debug.DrawRay(transform.position, newDirection, Color.red);

                // Calculate a rotation a step closer to the target and applies rotation to this object
                transform.rotation = Quaternion.LookRotation(newDirection);
                transform.position = Vector3.Lerp(startPos, selectedPlanetEndPos, Mathf.SmoothStep(0f, 1f, selectedAnimTimer / selectedPlanetAnimTime));
            }
            else
            {
                planetReached = true;
                moveBackButton.SetActive(true);
            }
        }

        if (moveBackToStartPos)
        {
            if (moveBackTimer < moveBackTime)
            {
                moveBackTimer += Time.deltaTime;

                if (moveBackTimer < stopRotationTime)
                {
                    Vector3 targetDirection = sun.transform.position - transform.position;

                    // The step size is equal to speed times frame time.
                    float singleStep = rotateSpeed * 0.05f * Time.deltaTime;

                    // Rotate the forward vector towards the target direction by one step
                    Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

                    // Draw a ray pointing at our target in
                    Debug.DrawRay(transform.position, newDirection, Color.red);

                    // Calculate a rotation a step closer to the target and applies rotation to this object
                    transform.rotation = Quaternion.LookRotation(newDirection);
                    moveBackButton.SetActive(false);
                }
                else
                {
                    transform.LookAt(sun.transform.position);
                    moveBackButton.SetActive(false);
                    foreach (GameObject GO in GameObject.FindGameObjectsWithTag("CelestialBody"))
                    {
                        if (GO.GetComponent<PlanetRevolver>() != null)
                        {
                            GO.GetComponent<PlanetRevolver>().startRevolving = true;
                        }
                    }

                }
                transform.position = Vector3.Lerp(selectedPlanetEndPos, startPos, Mathf.SmoothStep(0f, 1f, moveBackTimer / moveBackTime));
            }
            else
            {
                moveBackToStartPos = false;
                distanceFromSun = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(sun.transform.position.x, 0, sun.transform.position.z));
                startMovement = true;
                yAngle = Mathf.Atan2(sun.transform.position.z - transform.position.z, sun.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
                xAngle = Mathf.Atan2(sun.transform.position.y - transform.position.y, sun.transform.position.z - transform.position.z) * Mathf.Rad2Deg;
                selectedPlanet = false;
                planetReached = false;
                moveBackButton.SetActive(false);
            }
        }

        if (selectedPlanet && planetReached)
        {

            if (Input.GetMouseButtonDown(0))
            {
                xPos = Input.mousePosition.x;
                yPos = Input.mousePosition.y;
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                {
                    numberOfClicks++;
                    if (numberOfClicks == 1)
                    {
                        doubleClickTimer = 0;
                    }
                    if (numberOfClicks > 1)
                    {
                        PlayerData pData = playerSaveBehavior.GetPlayerData();
                        for (int i = 0; i < pData.planets.Count; i++)
                        {
                            if (pData.planets[i].planetInfo.planetName == hit.transform.gameObject.name)
                            {
                                Time.timeScale = 0;
                                PlayerPrefs.SetInt("SelectedPlanet", hit.transform.gameObject.GetComponent<PlanetInfo>().ID);
                                fadePanel.GetComponent<PanelFadeScript>().SetFade();
                            }
                        }
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
                            doubleClickTimer = 0;
                        }
                        if (numberOfClicks > 1)
                        {
                            PlayerData pData = playerSaveBehavior.GetPlayerData();
                            for (int i = 0; i < pData.planets.Count; i++)
                            {
                                if (pData.planets[i].planetInfo.planetName == hit.transform.gameObject.name)
                                {
                                    Time.timeScale = 0;
                                    PlayerPrefs.SetInt("SelectedPlanet", hit.transform.gameObject.GetComponent<PlanetInfo>().ID);
                                    fadePanel.GetComponent<PanelFadeScript>().SetFade();
                                }
                            }

                        }
                    }
                }
            }
            if (numberOfClicks == 1)
            {
                if (doubleClickTimer < doubleClickTime)
                {
                    doubleClickTimer += Time.deltaTime;
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
        if (selectedPlanet)
        {
            moveBackButton.SetActive(false);
            moveBackTimer = 0;
            startMovement = false;
            moveBackToStartPos = true;
            planetReached = false;
            float dist = (Vector3.Distance(selectedPlanetGO.transform.position, sun.transform.position));
            if (dist < 1)
            {
                stopRotationTime = 1f + dist;
            }
            else
            {
                stopRotationTime = 2f;
            }
        }
    }

    public void SetSelectedPlanet(GameObject PlanetGO)
    {
        if (!selectedPlanet)
        {
            selectedPlanet = true;
            selectedAnimTimer = 0;
            selectedPlanetGO = PlanetGO;
            startPos = transform.position;
            Vector3 dir = (transform.position - PlanetGO.transform.position).normalized;

            selectedPlanetEndPos = PlanetGO.transform.position + (dir * planetSelectDistance);
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
