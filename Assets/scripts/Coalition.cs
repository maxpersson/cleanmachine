using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coalition : MonoBehaviour
{
    // Start is called before the first frame update

    private int count;
    public Text countText;

    void Start()
    {
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       
            Debug.Log("fucckckkckskkkckcksdkckssdck");
            Destroy(collision.gameObject);
            count = count + 1;
            SetCountText();

        
    }

   

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

    }
}
