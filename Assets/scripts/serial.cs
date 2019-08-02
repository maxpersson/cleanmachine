using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class serial : MonoBehaviour
{
    public SerialController serialController;

    float state = 1;

    float timeDifference;
    float start;

    public float speed;
    float count;
    bool state_check = false;


    // Start is called before the first frame update
    void Start()
    {

        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    // Update is called once per frame
    void Update()
    {

        string message1 = serialController.ReadSerialMessage();



        if (message1 == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message1, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message1, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Message arrived: " + message1 );

        state = int.Parse(message1);
        calculateSpeed();


    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 100), "lort    " + state.ToString() + "     speed:    " + speed.ToString() + "    time_start:  " + timeDifference.ToString()) ;

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
