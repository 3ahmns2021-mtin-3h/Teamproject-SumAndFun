using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float gameTime { get; private set; }
    public delegate void TimeIsOut();
    public static event TimeIsOut OnTimeOut;
    
    public float startTime;

    private void Start()
    {
        //Difficulties
        gameTime = startTime;
    }

    private void Update()
    {
        gameTime -= Time.deltaTime;
    }
}
