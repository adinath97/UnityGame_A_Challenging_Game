using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePaddle : MonoBehaviour
{
    Quaternion targetAngle1 = Quaternion.Euler(0, 0, 180);
    Quaternion startingAngle1 = Quaternion.Euler(0, 0, 0);
    Quaternion targetAngle2 = Quaternion.Euler(0, 0, 180);
    Quaternion startingAngle2 = Quaternion.Euler(0, 0, 0);
    Quaternion targetAngle3 = Quaternion.Euler(0, 0, 180);
    Quaternion startingAngle3 = Quaternion.Euler(0, 0, 0);
    Quaternion targetAngle4 = Quaternion.Euler(0, 0, 180);
    Quaternion startingAngle4 = Quaternion.Euler(0, 0, 0);
    public Quaternion currentAngle1;
    public Quaternion currentAngle2;
    public Quaternion currentAngle3;
    public Quaternion currentAngle4;
    bool rotatedHalf1;
    bool rotatedHalf2;
    bool rotatedHalf3;
    bool rotatedHalf4;
    bool TshieldActivated;
    public float tShieldTimer = 5f;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    float Ypadding = 1.5f;
    float Xpadding = 1f;
    float movementSpeed = 5f;
    float deltaX;
    float deltaY;
    float newXPos;
    float newYPos;
    public GameObject paddle1;
    public GameObject paddle2;
    public GameObject paddle3;
    public GameObject paddle4;
    public GameObject tShieldObject;
    public float rotationSpeed;
    
    //Vector2 screenPosition;
    //Vector2 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        currentAngle1 = startingAngle1;
        currentAngle2 = startingAngle2;
        currentAngle3 = startingAngle3;
        currentAngle4 = startingAngle4;
        rotationSpeed = Time.deltaTime * 25f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Scene_Manager.gameOver == false && Count_Down.beginGame == true)
        {
            Swing1();
            Swing2();
            Swing3();
            Swing4();
            /* get screen width and height in world units:
            screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            */
            if (TshieldActivated == false && ScoreManager.tShields != 0)
            {
                TShieldStatus();
            }
        }
    }

    private void TShieldStatus()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TshieldActivated = true;
            float xPos = xMax / 2;
            float factor = 1.5f;
            float yPos = yMax - factor * yMax;
            GameObject tShield = Instantiate(tShieldObject, new Vector3(xPos,yPos,0), Quaternion.identity) as GameObject;
            ScoreManager.tShields--;
            Destroy(tShield, tShieldTimer);
            StartCoroutine(WaitRoutine());
        }
    }

    IEnumerator WaitRoutine()
    {
        int currentWait = 0;
        while(currentWait < 5)
        {
            yield return new WaitForSeconds(1);
            currentWait++;
            if(currentWait == 5)
            {
                TshieldActivated = false;
            }
        }
    }

    private void MoveBat()
    {
        deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(transform.position.x, newYPos);
    }

    private void Swing1()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("IN 1");
            ChangeCurrentAngle1();
            rotatedHalf1 = true;
        }
        paddle1.transform.rotation = Quaternion.Slerp(paddle1.transform.rotation, currentAngle1, rotationSpeed);
        if (paddle1.transform.rotation == currentAngle1 && rotatedHalf1 == true)
        {
            ChangeCurrentAngle1();
            rotatedHalf1 = false;
        }
    }

    private void Swing2()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Debug.Log("IN 2");
            ChangeCurrentAngle2();
            rotatedHalf2 = true;
        }
        paddle2.transform.rotation = Quaternion.Slerp(paddle2.transform.rotation, currentAngle2, rotationSpeed);
        if (paddle2.transform.rotation == currentAngle2 && rotatedHalf2 == true)
        {
            ChangeCurrentAngle2();
            rotatedHalf2 = false;
        }
    }

    private void Swing3()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("IN 3");
            ChangeCurrentAngle3();
            rotatedHalf3 = true;
        }
        paddle3.transform.rotation = Quaternion.Slerp(paddle3.transform.rotation, currentAngle3, rotationSpeed);
        if (paddle3.transform.rotation == currentAngle3 && rotatedHalf3 == true)
        {
            ChangeCurrentAngle3();
            rotatedHalf3 = false;
        }
    }

    private void Swing4()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("IN 4");
            ChangeCurrentAngle4();
            rotatedHalf4 = true;
        }
        paddle4.transform.rotation = Quaternion.Slerp(paddle4.transform.rotation, currentAngle4, rotationSpeed);
        if (paddle4.transform.rotation == currentAngle4 && rotatedHalf4 == true)
        {
            ChangeCurrentAngle4();
            rotatedHalf4 = false;
        }
    }

    private void ChangeCurrentAngle1()
    {
        if(currentAngle1.eulerAngles.z == startingAngle1.eulerAngles.z)
        {
            currentAngle1 = targetAngle1;
        }
        else
        {
            currentAngle1 = startingAngle1;
        }
    }

    private void ChangeCurrentAngle2()
    {
        if (currentAngle2.eulerAngles.z == startingAngle2.eulerAngles.z)
        {
            currentAngle2 = targetAngle2;
        }
        else
        {
            currentAngle2 = startingAngle2;
        }
    }

    private void ChangeCurrentAngle3()
    {
        if (currentAngle3.eulerAngles.z == startingAngle3.eulerAngles.z)
        {
            currentAngle3 = targetAngle3;
        }
        else
        {
            currentAngle3 = startingAngle3;
        }
    }

    private void ChangeCurrentAngle4()
    {
        if (currentAngle4.eulerAngles.z == startingAngle4.eulerAngles.z)
        {
            currentAngle4 = targetAngle4;
        }
        else
        {
            currentAngle4 = startingAngle4;
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + Xpadding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - Xpadding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + Ypadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - Ypadding;
    }

}
