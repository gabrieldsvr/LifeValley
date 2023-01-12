using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    
    const float secondsInDay = 86400f;
    const float phaseLength = 120f; // 15 minutes chunk of time
    const float phasesInDay = 96f; //secondsInDay divided by phaseLength
    
    
    [SerializeField] float timeScale = 60f;
    [SerializeField] float startAtTime = 28800f; // in seconds.
    [SerializeField] float morningTime = 28800f;
    public int days;

    private List<TimeAgent> agents;
    public float time;
    private void Awake()
    {

        time = startAtTime;
        agents = new List<TimeAgent>();
    }

    private void Update()
    {
        time += Time.deltaTime * timeScale;
        
        
        if (time > secondsInDay)
        {
            NextDay();
        }
        
        TimeAgents();
        
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            SkipTime(hours: 4);
        }
        
    }

    
    
    public void Subscribe(TimeAgent timeAgent)
    {
        agents.Add(timeAgent);
    }

    public void Unsubscribe(TimeAgent timeAgent)
    {
        agents.Remove(timeAgent);
    }

    float Hours 
    {
        get { return time / 3600f; }
    }

    float Minutes
    {
        get { return time % 3600f / 60f; }
    }
    
    int oldPhase = 0;
    private void TimeAgents()
    {
        

        int currentPhase = CalculatePhase();

        if (oldPhase != currentPhase) 
        {
            oldPhase = currentPhase;
            for (int i = 0; i < agents.Count; i++)
            {
                agents[i].Invoke();
            }
        }
    }
    private int CalculatePhase()
    {
        return (int)(time / phaseLength) + (int)(days * phasesInDay);
    }
    private void NextDay()
    {
        time -= secondsInDay;
        days += 1;
    }

    public void SkipTime(float seconds = 0, float minute = 0, float hours = 0) 
    {
        float timeToSkip = seconds;
        timeToSkip += minute * 60f;
        timeToSkip += hours * 3600f;

        time += timeToSkip;
    }
    public void SkipToMorning()
    {
        float secondsToSkip = 0f;

        if (time > morningTime)
        {
            secondsToSkip += secondsInDay - time + morningTime;
        }
        else {
            secondsToSkip += morningTime - time;
        }

        SkipTime(secondsToSkip);
    }
    
    public void TimeValueCalculation()
    {
        int hh = (int)Hours;
        int mm = (int)Minutes;
        Debug.Log( hh.ToString("00") + ":" + mm.ToString("00"));
    }
    
 
}
