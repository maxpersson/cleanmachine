using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wasteShark : MonoBehaviour
{
    float moveSpeed = 6.0f;
    public float sharkDirection;

    float worldRight = 7.0f;
    float worldLeft = -7.0f;

 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        sharkDirection = GameObject.Find("Square").GetComponent<serialBlow>().distance;

        float interpolatedMovement = worldLeft + ((worldRight - worldLeft) / (40 - 0)) * (sharkDirection - 0);


        Vector3 target = new Vector3(interpolatedMovement, -4.0f, 0.0f);
        float step = moveSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        
        if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0) {
            transform.Translate(Vector3.left * (moveSpeed+4.0f) * Time.deltaTime, Space.World);
        } 
       else if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0) {
            transform.Translate((Vector3.left * (moveSpeed+4.0f) * Time.deltaTime)*-1, Space.World);           
        }
    }

    
}
