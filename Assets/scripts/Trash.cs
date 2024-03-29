﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private float fallSpeed = 0.4f;
    private float wiggleSpeed = 1.0f;
    private int count;
    public int trashDestroyed;
    private float moveVelocity;
    // Start is called before the first frame update
    void Start()
    {
        moveVelocity = Random.Range(0.1f,3.2f);

    }

    // Update is called once per frame
    void Update()
    {

        count++;
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        if( count%2 == 0){
            wiggleLeft();
        }
        else{
            wiggleRight();
        }
        shootOut();
        if(transform.position.y < -4.5){
            trashDestroyed += 1;
            GameConstraints go = GameObject.Find("Square").GetComponent<GameConstraints>();
            go.trashDestroyed = go.trashDestroyed + 1;
            Destroy(gameObject);
        }
        //detectIfCollidedWithShark();
    }
    
    void wiggleLeft(){
        transform.Translate(Vector3.left * (fallSpeed+1.0f) * Time.deltaTime, Space.World);
    }
    
    void wiggleRight(){
        transform.Translate(Vector3.right * (fallSpeed+1.0f) * Time.deltaTime, Space.World);
    }
 
    void shootOut(){
        if(transform.position.y > 1.9){
            transform.Translate(Vector3.right * moveVelocity * Time.deltaTime, Space.World);
        }
    }

    //void detectIfCollidedWithShark(){
    //    if(Shark.transform.position.y -0.5f < transform.position.y && Shark.transform.position.y +0.5f > transform.position.y ){
    //        if(Shark.transform.position.x -4 < transform.position.x && Shark.transform.position.x +4 > transform.position.x){
    //            print("COLISSION!!!");
    //        }
    //    }
    //}
}
