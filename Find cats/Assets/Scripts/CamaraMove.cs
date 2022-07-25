using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{

    public Transform[] targets;
    int currentTarget = 0;

    public float sensitivity = 10.0f;

    Vector3 MouseDelta = Vector3.zero;
    Vector3 Amount = Vector3.zero;

    Vector3 campPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        Amount.z = 1;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1)){
            MouseDelta.Set(Input.GetAxisRaw("Mouse X"),
                        Input.GetAxisRaw("Mouse Y"),
                        Input.GetAxisRaw("Mouse ScrollWheel"));

            Amount += MouseDelta * sensitivity;
            Amount.z = Mathf.Clamp(Amount.z, 40, 50);
            Amount.y = Mathf.Clamp(Amount.y, -40, -10);

            campPos =
                    Quaternion.AngleAxis(Amount.x, Vector3.up)
                    * Quaternion.AngleAxis(Amount.y, Vector3.right)
                    * Vector3.forward;

            campPos *= Amount.z * 2f;
            campPos += targets[currentTarget].transform.position;
            transform.position = campPos;
            transform.LookAt(targets[currentTarget].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
