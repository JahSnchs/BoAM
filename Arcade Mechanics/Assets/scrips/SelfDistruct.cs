using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDistruct : MonoBehaviour
{
    private float timer;
    private GameObject poof;
    private bool poofed;
    
    void Start()
    {
        poofed = true;
        poof = GameObject.Find("poof");

    }
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= 4.5 && poofed)
        {
            Instantiate(poof, transform.GetChild(0).GetChild(0).position , new Quaternion(0,0,0,0));
            poofed = false;
        }
        if (timer >= 5)
        {
            Destroy(gameObject);
        }
    }
}
