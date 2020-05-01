using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoCamara : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 _cameraOffset;

    [Range (0.01f, 1.0f)]
    public float sensitivity = 1f;

    public bool RotateAroundPlayer = true;
    public bool LookAtPlayer = true;
    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void Update(){
        if(Time.deltaTime != 0){
            if(RotateAroundPlayer){
                Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensitivity, Vector3.up);
                _cameraOffset = camTurnAngle * _cameraOffset;
            }

            Vector3 newPos = PlayerTransform.position + _cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, sensitivity) ;
            if(RotateAroundPlayer || LookAtPlayer){
                transform.LookAt(PlayerTransform);
            }
        }
    }
}
