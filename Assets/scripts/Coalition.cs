using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;

public class Coalition : MonoBehaviour
{
    // Start is called before the first frame update

    public int pickCount;
    public Text countText;
    SerialPort sendStream;


    void Start()
    {
        pickCount = 0;
        SetCountText();
        

    }

    // Update is called once per frame
    void Update()
    {
        sendStream = GameObject.Find("Square").GetComponent<serialBlow>().stream;
        

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "pickUp")
        {
            Debug.Log("fucckckkckskkkckcksdkckssdck");
            Destroy(collision.gameObject);
            pickCount = pickCount + 1;
            SetCountText();
            sendStream.Write("g");

        }
        
    }

   

    void SetCountText()
    {
        countText.text = "Count: " + pickCount.ToString();

    }
}
