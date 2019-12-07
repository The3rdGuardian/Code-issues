using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    public float startingTime;

    private Text textTime;
    void Start()
    {
        textTime = GetComponent<Text>();
    }
    void Update()
    {
        startingTime -= Time.deltaTime;

        if(startingTime < 0)
        {
            startingTime = 0;
        }
        textTime.text = "Time Remaining:" + Mathf.Round(startingTime);
    }
}
