using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasteShark : MonoBehaviour
{
    float moveSpeed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0) {
            transform.Translate(Vector3.left * (moveSpeed+4.0f) * Time.deltaTime, Space.World);
        } 
        else if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0) {
            transform.Translate((Vector3.left * (moveSpeed+4.0f) * Time.deltaTime)*-1, Space.World);           
        }
    }
}
