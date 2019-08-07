using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameConstraints : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timerText;
    public Text trashCount;
    private float gameTimer;
    SerialPort closeStream;
    void Start()
    {
        gameTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        SetCountText();
         closeStream = GameObject.Find("Square").GetComponent<serialBlow>().stream;

    }
    void SetCountText()
    {
        timerText.text = "Time: " + gameTimer.ToString();
        if(gameTimer >= 30000)
        {
            closeStream.Close();
            SceneManager.LoadScene("GameOver");
        }

    }
}
