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
    private float pauseTimer = 20;
    SerialPort closeStream;

    float collectCount;
    float trashCount;
    float winningCoeficient;
    float trashDifference;

    int startButton = 1;

    void Start()
    {
        gameTimer = 30;
        closeStream = GameObject.Find("Square").GetComponent<serialBlow>().stream;
        
    }

    // Update is called once per frame
    void Update()
    {
        startButton = GameObject.Find("Square").GetComponent<serialBlow>().button;
        collectCount = GameObject.Find("Skraldedrone").GetComponent<Coalition>().pickCount;
        trashCount = GameObject.Find("Pipe").GetComponent<Gameplay>().trashCounter;
        trashDifference = trashCount - collectCount;
        gameTimer -= Time.deltaTime;
        winningCoeficient = trashDifference / trashCount;
        gameStop();
         

    }
    void gameStop()
    {
        
        timerText.text = "Tid: " + (int)gameTimer;
        if(gameTimer <= 0)
        {
            
            timerText.text = "";
            pauseTimer -= Time.deltaTime;
            countDownText.text = ""+(int)pauseTimer;
            if (winningCoeficient > 0.6)
            {
                winText.text = "Tillykke du har svinet havet til \nVenligst ikke fortsæt dette i den virkelige verden, men prøv i stedet for at fjerne plastik fra naturen, så vi kan bevare natur og dyrliv til fremtidige generationer. \n Har du en eller flere gode ideer til hvordan vi kan håndtere plastik i havene, så kan du putte dem i postkassen til venstre.";
            }
            else
            {
                winText.text = "Tillykke du reddet hav  miljøet \nFortsæt det gode arbejde i den virkelige verden, så vi kan bevare natur og dyreliv til fremtidige generationer. \n Har du en eller flere gode ideer til hvordan vi kan håndtere plastik i havene, så kan du putte dem i postkassen til venstre.  ";
            }
            if (pauseTimer <= 0 || startButton == 0)
            {
                closeStream.Close();
                SceneManager.LoadScene("GameOver");
            }
        }

    }
}
