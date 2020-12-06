using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TShield : MonoBehaviour
{
    Quaternion targetAngle = Quaternion.Euler(0, 0, 180);
    Quaternion startingAngle = Quaternion.Euler(0, 0, 0);
    Quaternion currentAngle;

    private void Start()
    {
        StartCoroutine(ContinuousRotation());
    }

    IEnumerator ContinuousRotation()
    {
        while (true)
        {
            transform.Rotate(Vector3.forward, 10);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "paddle")
        {
            Destroy(gameObject);
            ScoreManager.tShields++;
        }
    }
}
