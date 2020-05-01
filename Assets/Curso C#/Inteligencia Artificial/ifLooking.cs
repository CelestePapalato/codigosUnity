using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifLooking : MonoBehaviour
{
    public MoveGoalV2 player;
    public float range;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3 (0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(rayOrigin, cam.transform.forward, out hit, range)){
            if(hit.collider.tag == "goal"){
                player.goal = hit.collider.transform;
                player.enabled = true;
            }
            else player.enabled = false;
        }
    }
}
