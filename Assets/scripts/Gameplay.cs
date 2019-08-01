using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        trashArray = new GameObject[] {trash1, trash2, trash3, trash4, trash5, trash6};
        createGameObject();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createGameObject(){
        GameObject newObject = trashArray[Random.Range(0,5)];
        newObject.transform.position = new Vector3(-9f,4.2f,0);
        Instantiate(newObject);
    }
}
