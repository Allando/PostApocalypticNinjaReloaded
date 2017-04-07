using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class stopWatchScript : MonoBehaviour
{
    public Stopwatch aTimer;
    public bool GoalReached;
    public Text TimerText;

    // Use this for initialization
    void Start ()
    {
        aTimer = new Stopwatch();

        aTimer.Start();
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentTime();
    }

    void currentTime()
    {
        GameObject.FindGameObjectWithTag("text").GetComponent<Text>().text = Time.time.ToString("0.0"); // (^^)/ Se om man kan få millisekunder (for suspense) 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "endTag")
        {
            Debug.Log("endTag is met");
            stopTime();
        }
    }

    /// <summary>
    /// A method which stops the time time and gives the elapsedTime
    /// I keep this method for itself for future purposes...
    /// </summary>
    private void stopTime()
    {
        if (GoalReached)
        {
            Debug.Log("Goal reached");
            TimeSpan ts = aTimer.Elapsed;
            aTimer.Stop();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
            ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        }
    }
}
