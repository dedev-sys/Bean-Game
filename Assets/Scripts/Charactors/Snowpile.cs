using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Snowpile : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        var player = other.gameObject.GetComponent<Player>();
        player.Reload();
    }

}
