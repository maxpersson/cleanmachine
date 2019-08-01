using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = new GameObject("New Sprite");
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        print(Resources.Load("Assets 1", typeof(Sprite)));
        renderer.sprite = Resources.Load("Assets 1", typeof(Sprite)) as Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
