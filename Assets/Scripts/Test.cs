using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private DialogBubble bb;
    // Start is called before the first frame update
    void Start()
    {
        bb = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (bb == null) {
            bb = GameObject.FindObjectOfType<DialogBubble>();
            bb.Text = "test test";
            Debug.Log("DOOOONe");
        }
        
    }
}
