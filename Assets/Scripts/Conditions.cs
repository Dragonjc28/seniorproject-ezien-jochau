using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    public int Points = 0;
    public OnChangePos SinkScript;
    private bool lvl1 = false;
    private bool lvl2 = false;
    private bool lvl3 = false;
    private bool lvl4 = false;
    private bool lvl5 = false;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.collider.gameObject);
        UpdatePoints(collision);
    }

    private void UpdatePoints(Collision other)
    {
        if (other.gameObject.name == "tree")
            Points += 1;
        else if (other.gameObject.name == "trash")
            Points += 3;
        else if (other.gameObject.name == "bench")
            Points += 2;
        else if (other.gameObject.name == "soda")
            Points += 5;
        else if (other.gameObject.name == "home")
            Points += 10;
        
        if(Points >= 900 && lvl4 == true && lvl5 == false)
        {
            StartCoroutine(SinkScript.IncreaseSize());
            lvl5 = true;
        }
        else if (Points >= 250 && lvl3 == true && lvl4 == false)
        {
            StartCoroutine(SinkScript.IncreaseSize());
            lvl4 = true;
        }
        else if (Points >= 100 && lvl2 == true && lvl3 == false)
        {
            StartCoroutine(SinkScript.IncreaseSize());
            lvl3 = true;
        }
        else if (Points >= 40 && lvl1 == true && lvl2 == false)
        {
            StartCoroutine(SinkScript.IncreaseSize());
            lvl2 = true;
        }
        else if (Points >= 20 && lvl1 == false)
        {
            StartCoroutine(SinkScript.IncreaseSize());
            lvl1 = true;
        }
    }
}
