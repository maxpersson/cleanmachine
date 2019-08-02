using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class serial : MonoBehaviour
{
    Thread ChildThread = null;
    EventWaitHandle ChildThreadWait = new EventWaitHandle(true, EventResetMode.ManualReset);
    EventWaitHandle MainThreadWait = new EventWaitHandle(true, EventResetMode.ManualReset);

    SerialPort stream;

    int state = 1;

    float timeDifference;

    float speed;

    string infoString;

    private void Awake()
    {
        ChildThread = new Thread(calculateSpeed);
        ChildThread.Start();
    }
    // Start is called before the first frame update
    void Start()
    {
        stream = new SerialPort("COM11", 9600);
        stream.Open();
        
    }

    // Update is called once per frame
    void Update()
    {
        MainThreadWait.Reset();
        WaitHandle.SignalAndWait(ChildThreadWait, MainThreadWait);

        infoString = stream.ReadLine();
        
        state = int.Parse(infoString);
        

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 100), "lort    " + state.ToString() + "     speed:    " + speed.ToString() + "    time_start:  " + timeDifference.ToString()) ;

    }

    void OnApplicationQuit()
    {
        if (stream != null)
            stream.Close();
    }

    void calculateSpeed()
    {
        ChildThreadWait.Reset();
        ChildThreadWait.WaitOne();

        float start = Time.time;
        float count = 0;
        bool state_check = false;

        while (true)
        {
            ChildThreadWait.Reset();
            if (state == 0)
            {
                if (!state_check)
                {
                    state_check = true;
                    count += 1;
                }
                else
                {
                    state_check = false;
                }
                if (count >= 10)
                {
                    break;
                }
            }
            WaitHandle.SignalAndWait(MainThreadWait, ChildThreadWait);
        }

        float end = Time.time;
        timeDifference = end - start;
        speed = count / timeDifference;
    }
}
