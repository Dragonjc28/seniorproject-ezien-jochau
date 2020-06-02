using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    public OnChangePos SinkScript;
    private bool lvl1 = false;
    private bool lvl2 = false;
    private bool lvl3 = false;
    private bool lvl4 = false;
    private bool lvl5 = false;
    private bool lvl6 = false;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.collider.gameObject);
        UpdatePoints(collision);
    }

    private void UpdatePoints(Collision other)
    {
        if (other.gameObject.name == "tree")
            KeepScore.hiscore += 1;
        else if (other.gameObject.name == "trash")
            KeepScore.hiscore += 3;
        else if (other.gameObject.name == "bench")
            KeepScore.hiscore += 2;
        else if (other.gameObject.name == "soda")
            KeepScore.hiscore += 5;
        else if (other.gameObject.name == "taxi")
            KeepScore.hiscore += 10;
        else if (other.gameObject.name == "car")
            KeepScore.hiscore += 10;
        else if (other.gameObject.name == "bus")
            KeepScore.hiscore += 10;
        else if (other.gameObject.name == "home")
            KeepScore.hiscore += 10;
        if (KeepScore.hiscore >= 5000 && lvl5 == true && lvl6 == false)
        {
            StartCoroutine(SinkScript.IncreaseSize());
            lvl6 = true;
        }
        if (KeepScore.hiscore >= 2000 && lvl4 == true && lvl5 == false)
        {
            StartCoroutine(SinkScript.IncreaseSize());
            lvl5 = true;
        }
        else if (KeepScore.hiscore >= 700 && lvl3 == true && lvl4 == false)
        {
            StartCoroutine(SinkScript.IncreaseSize());
            lvl4 = true;
        }
        else if (KeepScore.hiscore >= 200 && lvl2 == true && lvl3 == false)
        {
            StartCoroutine(SinkScript.IncreaseSize());
            lvl3 = true;
        }
        else if (KeepScore.hiscore >= 100 && lvl1 == true && lvl2 == false)
        {
            StartCoroutine(SinkScript.IncreaseSize());
            lvl2 = true;
        }
        else if (KeepScore.hiscore >= 50 && lvl1 == false)
        {
            StartCoroutine(SinkScript.IncreaseSize());
            lvl1 = true;
        }
    }
}
