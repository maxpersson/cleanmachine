using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class serialBlow : MonoBehaviour
{
    public SerialPort stream;

    public string port = "COM12";

    public int state = 1;

    float timeDifference;
    float start;

    public float speed;
    float count;
    bool state_check = false;
   

    public int distance;

    // Start is called before the first frame update
    void Start()
    {
        stream = new SerialPort(port, 115200);
        stream.Open();
        // declare thread, and reference sampleFunction
        Thread sampleThread = new Thread(new ThreadStart(readSerial));
        sampleThread.IsBackground = true;
        // start thread
        sampleThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //calculateSpeed();

    }

    //private void OnGUI()
    //{
    //    GUI.Label(new Rect(10, 10, 300, 100), "lort    " + state.ToString() + "     speed:    " + speed.ToString() + "    time_start:  " + start.ToString() + "     counter:     " + count.ToString() + "   byte:      " + bytVal1.ToString() + "     distance:" + distance.ToString() );

    //}
    // calculate RPM 
    //void calculateSpeed()
    //{

    //    if (count == 0)
    //    {
    //        start = Time.time;
    //    }

    //    if (state == 0)
    //    {
    //        if (!state_check)
    //        {
    //            state_check = true;
    //            count += 1;
    //        }


    //        if (count >= 5)
    //        {
    //            float end = Time.time;
    //            timeDifference = (end - start) / 1000;
    //            speed = count / timeDifference;
    //            end = 0;
    //            count = 0;
    //            state_check = false;
    //        }
    //        else
    //        {
    //            speed = 0;
    //        }
    //    }
    //    else
    //    {
    //        state_check = false;
    //    }

    //}

    void OnApplicationQuit()
    {
        if (stream != null)
            stream.Close();
    }

    public void readSerial()
    {
        int bytVal1;
        int bytVal2;
        int hej;
        while (true)
        {
            if (stream == null)
            {
                return;
            }
            if (stream.IsOpen)
            {
                try
                {
                    
                    bytVal1 = stream.ReadByte();
                    state = bytVal1;

                    bytVal2 = stream.ReadByte();
                    distance = bytVal2;
                    //hej = stream.ReadByte();
                    
                    //Debug.Log(hej);


                }
                catch (TimeoutException ex)
                {
                    print(ex);
                }
            }



           
        }
    }
}
