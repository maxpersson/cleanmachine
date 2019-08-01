using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class serialBlow : MonoBehaviour
{
    SerialPort stream;

    float state = 1;

    float timeDifference;
    float start;

    float speed;
    float count;
    bool state_check = false;

    string infoString;

    // Start is called before the first frame update
    void Start()
    {
        stream = new SerialPort("COM11", 9600);
        stream.Open();

    }

    // Update is called once per frame
    void Update()
    {
        infoString = stream.ReadLine();

        state = float.Parse(infoString);

        calculateSpeed();

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 100), "lort    " + state.ToString() + "     speed:    " + speed.ToString() + "    time_start:  " + start.ToString() + "     counter:     " + count.ToString()) ;

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
                timeDifference = (end - start)/1000;
                speed = count / timeDifference;
                end = 0;
                count = 0;
                state_check = false;
            }
            }
        else
        {
            state_check = false;
        }

    }

    void OnApplicationQuit()
    {
        if (stream != null)
            stream.Close();
    }
}
