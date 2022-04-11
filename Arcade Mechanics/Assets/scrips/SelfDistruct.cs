using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDistruct : MonoBehaviour
{
    private float timer;
    public GameObject poof;
    private bool poofed;
    
    void Start()
    {
    }
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= 4&&poofed)
        {
            Instantiate(poof);
            poofed = false;
        }
        if (timer >= 5)
        {
            Destroy(gameObject);
        }
    }
}
