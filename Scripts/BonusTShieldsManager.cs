using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTShieldsManager : MonoBehaviour
{
    float timeBtwnCounter;
    float minTimeBetweenInstantiation = 30f;
    float maxTimeBetweenInstantiation = 60f;
    bool countDownBegun;
    public GameObject bonusTShieldObject;
    static float yPos;
    static float xPos;
    public float xMax;
    public float xMin;
    public float yMin;
    public float yMax;
    float Ypadding = 1.5f;
    float Xpadding = 1f;

    private void Start()
    {
        SetUpMoveBoundaries();
        countDownBegun = false;
        timeBtwnCounter = Random.Range(minTimeBetweenInstantiation, maxTimeBetweenInstantiation);
    }
    // Update is called once per frame
    void Update()
    {
        if(countDownBegun == false && Count_Down.beginGame == true)
        {
            timeBtwnCounter = Random.Range(minTimeBetweenInstantiation, maxTimeBetweenInstantiation);
            countDownBegun = true;
            StartCoroutine(InstantiateBonusTShieldRoutine());
        }
    }

    IEnumerator InstantiateBonusTShieldRoutine()
    {
        //Debug.Log("IN COROUTINE");
        //Debug.Log(timeBtwnCounter);
        yield return new WaitForSeconds(timeBtwnCounter);
        CountDownAndInstantiateBonusTShields();
        countDownBegun = false;
        //Debug.Log("DONE INSTANTIATING");
    }

    private void CountDownAndInstantiateBonusTShields()
    {
        //Debug.Log("INSTANTIATING");
        yPos = yMax;
        xPos = Random.Range(xMin, xMax);
        GameObject bonusTShield = Instantiate(bonusTShieldObject, new Vector3(xPos, yPos, 0), Quaternion.identity) as GameObject;
        bonusTShield.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
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
