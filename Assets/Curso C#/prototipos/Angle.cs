using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle : MonoBehaviour
{
    private GameObject cam;
    private GameObject player;


    void Start()
    {
        cam =  Manager.instance.Camera;
        player = Manager.instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(""+ GetAngleIndex());
    }

    int GetAngleIndex()
     {
         var camPos = new Vector2(cam.transform.forward.x, cam.transform.forward.z);
         var parent = new Vector2(player.transform.forward.x, player.transform.forward.z);
         float enemyAngle = Vector2.Angle(camPos, parent);
         Vector3 cross = Vector3.Cross(camPos, parent);

         if (cross.z > 0)
             enemyAngle = 360 - enemyAngle;

         Debug.Log("Angle from the player is: " + enemyAngle);

         if (enemyAngle >= 292.5f && enemyAngle < 337.5f)
             return 8;
         else if (enemyAngle >= 22.5f && enemyAngle < 67.5f)
             return 2;
         else if (enemyAngle >= 67.5f && enemyAngle < 112.5f)
             return 3;
         else if (enemyAngle >= 112.5f && enemyAngle < 157.5f)
             return 4;
         else if (enemyAngle >= 157.5f && enemyAngle < 202.5f)
             return 5;
         else if (enemyAngle >= 202.5f && enemyAngle < 247.5f)
             return 6;
         else if (enemyAngle >= 247.5f && enemyAngle < 292.5f)
             return 7;
         else if (enemyAngle >= 337.5f || enemyAngle < 22.5f)
             return 1;
         else return 0;
     }
}
