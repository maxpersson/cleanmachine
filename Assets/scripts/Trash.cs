using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private float fallSpeed = 0.4f;
    private float wiggleSpeed = 1.0f;
    public int count;
    private float moveVelocity = Random.Range(0,7);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        if( count%2 == 0){
            wiggleLeft();
        }
        else{wiggleRight();}
        shootOut();
    }

    void wiggleLeft(){
        transform.Translate(Vector3.left * fallSpeed * Time.deltaTime, Space.World);
    }
    
    void wiggleRight(){
        transform.Translate(Vector3.right * fallSpeed * Time.deltaTime, Space.World);
    }

    void shootOut(){
        if(transform.position.y > 1.9){
            transform.Translate(Vector3.right * moveVelocity * Time.deltaTime, Space.World);
        }
    }
}
