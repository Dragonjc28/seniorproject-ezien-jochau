using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    public int Points = 0;
    public OnChangePos SinkScript;    

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.collider.gameObject);
        UpdatePoints();
    }

    private void UpdatePoints()
    {
        Points++ ;

        if(Points % 5 == 0)
        {
            StartCoroutine(SinkScript.IncreaseSize());
        }
    }
}
