using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlaping : MonoBehaviour
{
    private float timeAfterBorn;
    private bool iAmOldHere;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(timeAfterBorn < 0.02f)
        Destroy(gameObject);
    }
    
    private void Update()
    {
        timeAfterBorn += Time.deltaTime;
        if (timeAfterBorn >= 0.02f && !iAmOldHere)
        {
            TranslatePosition();
            iAmOldHere = true;
        }
    }

    private void TranslatePosition()
    {
        Creator.instance.correctPos.Add(this.transform.position);
    }
}
