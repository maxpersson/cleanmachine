using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aditySerial : MonoBehaviour
{
    float state = 1;

    float timeDifference;
    float start;

    public float speed;
    float count;
    bool state_check = false;

    void OnMessageArrived(string msg)
    {
        state = int.Parse(msg);
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {

    }


// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calculateSpeed();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 100), "lort    " + state.ToString() + "     speed:    " + speed.ToString() + "    time_start:  " + timeDifference.ToString());

    }

    void calculateSpeed()
    {

        if (count == 0)
        {
            start = Time.time;
        }

        if (state == 0)
        {
            if (!state_check)
            {
                state_check = true;
                count += 1;
            }


            if (count >= 5)
            {
                float end = Time.time;
                timeDifference = (end - start) / 1000;
                speed = count / timeDifference;
                end = 0;
                count = 0;
                state_check = false;
            }
            else
            {
                speed = 0;
            }
        }
        else
        {
            state_check = false;
        }

    }
}
