using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject trash1;
    public GameObject trash2;
    public GameObject trash3;
    public GameObject trash4;
    public GameObject trash5;
    public GameObject trash6;

    public GameObject[] trashArray;

    public float blowSpeed;

    bool rotationSwitch = true;
    public int trashCounter;
    public Text trashText;



    void Start()
    {
        trashArray = new GameObject[] {trash1, trash2, trash3, trash4, trash5, trash6};
        createGameObject();
        
    }

    // Update is called once per frame
    void Update()
    {

        //blowSpeed = GameObject.Find("Square").GetComponent<serialBlow>().speed;
        //int piecesOfTrash = (int)blowSpeed / 500;
        //if(blowSpeed > 0)
        //{
        //    for(int i = 0; i < piecesOfTrash; i++)
        //    {
        //        createGameObject();
        //    }

        //}
        int state = GameObject.Find("Square").GetComponent<serialBlow>().state;

        if(state == 1)
        {
            rotationSwitch = true;
        }
        else if (state == 0 && rotationSwitch)
        {
            createGameObject();
            rotationSwitch = false;
            SetCountText();
        }
        

       if (Input.GetMouseButtonDown(0)){
           createGameObject();
        }

    }

    void createGameObject(){
        trashCounter += 1;
        GameObject newObject = trashArray[Random.Range(0,5)];
        newObject.transform.position = new Vector3(-9f,4.2f,0);
        Instantiate(newObject);
    }

    void SetCountText()
    {
       trashText.text = "trash Count: " + trashCounter.ToString();

    }
}
