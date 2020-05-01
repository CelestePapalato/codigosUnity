using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sigueGoal : MonoBehaviour
{
    public bool LookAtPlayer = true;
    public Transform PlayerTransform;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(LookAtPlayer){
            transform.LookAt(PlayerTransform);
        }
    }
}
