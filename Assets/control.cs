using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{

    public int sharkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        sharkSpeed = gameObject.GetComponent<serialBlow>().distance;
        Vector3 moving = new Vector3(sharkSpeed, 0, 0);
        if (sharkSpeed <= 25)
        {
            transform.Translate(Vector3.left);
        }
        if(sharkSpeed > 25)
        {
            transform.Translate(Vector3.right);
        }
        
    }
}
