using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonScript : MonoBehaviour
{

    public Transform firepoint;
    public GameObject cannonBall;
    float timeBetween;
    public float startTimeBetween;

    // Start is called before the first frame update
    void Start()
    {
        timeBetween = startTimeBetween;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetween <= 0)
        {
            Instantiate(cannonBall, firepoint.position, firepoint.rotation);
            timeBetween = startTimeBetween;
        }
        else
        {
            timeBetween -= Time.deltaTime;
        }
    }
}
