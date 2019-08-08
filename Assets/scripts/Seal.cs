using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : MonoBehaviour
{
    public int difference;
    private int trashCounter;
    private int trashCatched;
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        trashCounter = GameObject.Find("Pipe").GetComponent<Gameplay>().trashCounter;
        trashCatched = GameObject.Find("Skraldedrone").GetComponent<Coalition>().pickCount;
        difference = trashCounter-trashCatched;
    }
}
