using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : MonoBehaviour
{
    public float difference;
    private int trashCounter;
    private int trashCatched;

    public Sprite[] seal1;
    
    // Start is called before the first frame update
    void Start()
    {
        seal1 = Resources.LoadAll<Sprite>("Seals");
        this.GetComponent<SpriteRenderer>().sprite = seal1[0];
    }

    // Update is called once per frame
    void Update()
    {
        difference =  GameObject.Find("Square").GetComponent<GameConstraints>().winningCoeficient;
        if(difference >= 0 && difference < 0.2f){
            this.GetComponent<SpriteRenderer>().sprite = seal1[0];
        }
        else if(difference > 0.2f && difference < 0.4f){
            this.GetComponent<SpriteRenderer>().sprite = seal1[1];
        }
        else if(difference > 0.4f && difference < 0.6f){
            this.GetComponent<SpriteRenderer>().sprite = seal1[2];
        }
        else if(difference > 0.6f && difference < 0.8f){
            this.GetComponent<SpriteRenderer>().sprite = seal1[3];
        }
        else if(difference > 0.8f && difference < 1.1f){
            this.GetComponent<SpriteRenderer>().sprite = seal1[4];
        }

    }
}
