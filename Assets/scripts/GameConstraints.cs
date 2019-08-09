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
    public int trashDestroyed = 0;
    float collectCount;
    float trashCount;
    public float winningCoeficient;
    float trashDifference;

    int startButton = 1;

    void Start()
    {
        gameTimer = 90;
        closeStream = GameObject.Find("Square").GetComponent<serialBlow>().stream;
        

    }

    // Update is called once per frame
    void Update()
    {
        startButton = GameObject.Find("Square").GetComponent<serialBlow>().button;
        collectCount = GameObject.Find("Skraldedrone").GetComponent<Coalition>().pickCount;
        trashCount = GameObject.Find("Pipe").GetComponent<Gameplay>().trashCounter;
        

        trashDifference = trashDestroyed - collectCount;

        gameTimer -= Time.deltaTime;
        print(trashDestroyed);
        winningCoeficient = trashDifference / trashCount;
        print(winningCoeficient);

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
                winText.text = "Spillet er slut\n Vent eller tryk på start for at spille igen\n For meget plastik er endt i havet \nVenligst ikke fortsæt dette i den virkelige verden, men prøv i stedet for at fjerne plastik fra naturen, så vi kan bevare natur og dyrliv til fremtidige generationer. \n Har du en eller flere gode ideer til hvordan vi kan håndtere plastik i havene, så kan du putte dem i postkassen til venstre.";
            }
            else
            {
                winText.text = "Spillet er slut \n Vent eller tryk på start for at spille igen \n Du har renset havet for plastik \n Fortsæt det gode arbejde i den virkelige verden, så vi kan bevare natur og dyreliv til fremtidige generationer. \n Har du en eller flere gode ideer til hvordan vi kan håndtere plastik i havene, så kan du smide dem i postkassen til venstre.  ";
            }
            if (pauseTimer <= 0 || startButton == 0)
            {
                closeStream.Close();
                SceneManager.LoadScene("GameOver");
            }
        }

    }
}
