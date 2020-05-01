using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    //Esto es para que se pueda ver en el inspector
    [SerializeField]
    private float _MovementSpeed;
    [SerializeField]
    private float _RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime es para que no se mueva por frames, sino por segundos
        //Esto es igual a     new Vector3(1,0,0) * _speed * tiempo real
        //transform.Translate(Vector3.right * _speed * Time.deltaTime );

        //Esto es usando los axis de Unity (Edit -> Project Settings -> Input)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, verticalInput) * _MovementSpeed * Time.deltaTime );
        transform.Rotate(new Vector3(0, horizontalInput, 0) * _RotationSpeed * Time.deltaTime );
    }
}
