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
    public Text winText;
    public Text countDownText;
    private float gameTimer;
    private float pauseTimer = 5;
    SerialPort closeStream;

    float collectCount;
    float trashCount;
    float winningCoeficient;
    void Start()
    {
        gameTimer = 0;
        closeStream = GameObject.Find("Square").GetComponent<serialBlow>().stream;
        
    }

    // Update is called once per frame
    void Update()
    {
        collectCount = GameObject.Find("Skraldedrone").GetComponent<Coalition>().count;
        trashCount = GameObject.Find("Pipe").GetComponent<Gameplay>().trashCounter;
        Debug.Log(trashCount);
        gameTimer += Time.deltaTime;
        winningCoeficient = trashCount / collectCount;
        gameStop();

         

    }
    void gameStop()
    {
        
        timerText.text = "Time: " + gameTimer.ToString();
        if(gameTimer >= 30)
        {
            closeStream.Close();
            timerText.text = "";
            pauseTimer -= Time.deltaTime;
            countDownText.text = pauseTimer.ToString();
            if (winningCoeficient > 3)
            {
                winText.text = "Tillykke du har svinet havet til \nVenligst ikke fortsæt dette i den virkelige verden, men i stedet at fjerne plastik fra naturen, så vi kan bevare natur og dyrliv til fremtidige generationer.";
            }
            else
            {
                winText.text = "Tillykke du reddet sælen \nfortsæt det gode arbejde i den virkelige verden, så vi kan bevare natur og dyreliv til fremtidige generationer. \n har du en eller flere gode ideer til hvordan vi kan håndtere plastik i havene, så venligst put dem i postkassen.  ";
            }
            if (pauseTimer <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

    }
}
