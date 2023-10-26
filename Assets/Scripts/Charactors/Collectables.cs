using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Collectables : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        Player.ScoreInc();
    }

    public void RespawnToast()
    {
        //Instantiate(toast, new Vector3(0, .5f, 45), Quaternion.identity);
    }
}
