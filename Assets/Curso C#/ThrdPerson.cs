using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrdPerson : MonoBehaviour
{
    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    public float camDistanceXToPlayer;
    public float camDistanceYToPlayer;
    public float camDistanceZToPlayer;
    private float mouseX;
    private float mouseY;
    public float smooth;
    private float rotY = 0.0f;
    private float rotX = 0.0f;

    // Start is called before the first frame update
    void Start(){
        Vector3 rot= transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //seteamos la rotación para mouse
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotY += mouseX * inputSensitivity * Time.deltaTime;
        rotX -= mouseY * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

    }

    void LateUpdate(){
        CameraUpdater();

    }

    void CameraUpdater(){
        //seteamos el objetivo a seguir
        Transform target = CameraFollowObj.transform;

        //nos movemos hacia el objetivo, el jugador
        float step = CameraMoveSpeed * Time.deltaTime * smooth;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
