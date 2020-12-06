using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject BallObject;
    static float yPos;
    static float xPos;
    public float xMin1;
    public float xMax1;
    public float yMin1;
    public float yMax1;
    float Ypadding = 1.5f;
    float Xpadding = 1f;
    public static float ballSpeed = 5f;
    public float timeBtwnCounter;
    public float minTimeBetweenInstantiation = .3f;
    public float maxTimeBetweenInstantiation = 3f;
    public static bool currentBallDestroyed;
    float ballSpeedIncrTimer = 30f;
    bool ballSpeedIncreased;

    // Start is called before the first frame update
    void Start()
    {
        ballSpeed = 5f;
        currentBallDestroyed = true;
        timeBtwnCounter = Random.Range(minTimeBetweenInstantiation, maxTimeBetweenInstantiation);
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        if(Scene_Manager.gameOver == false && Count_Down.beginGame == true)
        {
            if (ballSpeedIncreased == false)
            {
                ballSpeedIncreased = true;
                StartCoroutine(IncreaseSpeedRoutine());
            }
            InstantiateAndRelease();
        }
    }

    IEnumerator IncreaseSpeedRoutine()
    {
        yield return new WaitForSeconds(ballSpeedIncrTimer);
        ballSpeed++;
        ballSpeedIncreased = false;
    }

    private void InstantiateAndRelease()
    {
        timeBtwnCounter -= Time.deltaTime;
        if(timeBtwnCounter <= 0 && currentBallDestroyed == true)
        {
            currentBallDestroyed = false;
            yPos = yMax1;
            xPos = Random.Range(xMin1,xMax1);
            GameObject ball = Instantiate(BallObject, new Vector3(xPos, yPos, 0), Quaternion.identity) as GameObject;
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ballSpeed);
            timeBtwnCounter = Random.Range(minTimeBetweenInstantiation, maxTimeBetweenInstantiation);
        }
        
    }

    private void SetUpMoveBoundaries()
    {
        /*
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + Xpadding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - Xpadding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + Ypadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - Ypadding;
        */

        xMin1 = -2.2f;
        xMax1 = 3.5f;

        yMin1 = 5.2f;
        yMax1 = 5.2f;

    }
}
