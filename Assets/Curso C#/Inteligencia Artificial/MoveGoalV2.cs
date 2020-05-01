using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGoalV2 : MonoBehaviour
{
    public float speed = 2.0f;
    public float accuaracy = 0.2f;
    public Transform goal;
    void Start()
    {

    }
    void LateUpdate()
    {
        this.transform.LookAt(goal.position);
        Vector3 direction = goal.position - this.transform.position;
        if(direction.magnitude > accuaracy){
            this.transform.position = Vector3.MoveTowards(transform.position, goal.transform.position, speed * Time.deltaTime);
        }
    }
}
