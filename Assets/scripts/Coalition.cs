using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;

public class Coalition : MonoBehaviour
{
    // Start is called before the first frame update

    private int count;
    public Text countText;
    SerialPort sendStream;

    void Start()
    {
        count = 0;
        SetCountText();
        sendStream = GameObject.Find("Square").GetComponent<serialBlow>().stream;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "pickUp")
        {
            Debug.Log("fucckckkckskkkckcksdkckssdck");
            Destroy(collision.gameObject);
            count = count + 1;
            SetCountText();
            sendStream.Write("1");
        }
        
    }

   

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

    }
}
