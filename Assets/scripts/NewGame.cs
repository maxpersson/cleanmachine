using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    int startButton = 1;

    SerialPort closeStream;


    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        startButton = GameObject.Find("Canvas").GetComponent<serialBlow>().button;

        if (startButton == 0)
        {
            closeStream = GameObject.Find("Canvas").GetComponent<serialBlow>().stream;
            closeStream.Close();
            SceneManager.LoadScene("MainScene");
        }

    }
}
