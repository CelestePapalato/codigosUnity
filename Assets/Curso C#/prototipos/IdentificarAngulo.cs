using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentificarAngulo : MonoBehaviour
{

    private float cos;
    private Transform Camera;
    private Transform Direction;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        Camera =  Manager.instance.Camera.transform;
        Direction = Manager.instance.PlayerDirection.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 V1 = new Vector3 (Camera.position.x, 0, Camera.position.z);
        Vector3 V2 = new Vector3 (Direction.position.x, 0, Direction.position.z);
        Vector3 aux = new Vector3 (this.transform.position.x, 0, this.transform.position.z);
        V1 -= aux;
        V2 -= aux;
        angle = calculateCos(V1, V2);
        Loging(angle, V1, V2);
    }

    private float calculateCos(Vector3 V1, Vector3 V2){
        float cos, Lcos, aux1, aux2;
        float Angle; //grados
        cos = (V1.x * V2.x) + (V1.z * V2.z);

        aux1 = Mathf.Pow(V1.x, 2) + Mathf.Pow(V1.z, 2);
        aux2 = Mathf.Pow(V2.x, 2) + Mathf.Pow(V2.z, 2);
        Lcos = Mathf.Sqrt(aux1 * aux2);
        cos = cos/Lcos;
        Angle = Mathf.Acos(cos);
        Angle = Angle * (180/Mathf.PI);
        return Angle;
    }

    private void Loging(float angle, Vector3 Camera, Vector3 Player){
        if(Camera.x < 0 || Player.x < 0) angle *= (-1);
        Debug.Log(string.Format("angle = {0}", angle));
        if(angle >= (-45) && angle <= 45) Debug.Log("Front");
        if(angle > 45 && angle <= 135) Debug.Log("Right");
        if(angle < (-45) && angle >= (-135)) Debug.Log("Left");
        if((angle > 135 && angle <= 180) || (angle < (-135) && angle >= -180))
            Debug.Log("Back");
    }
}
