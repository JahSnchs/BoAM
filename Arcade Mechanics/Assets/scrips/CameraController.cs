using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public Transform target;

    public Vector3 offset;

    public float rotateSpeed;

    public bool useOffsetValues;

    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = target.eulerAngles.x;

        float horizantal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizantal, 0);
        /*if (target.rotation.x > 0.08715578)
        {
            desiredXAngle = 10f;
            print("move");

        }
        if (target.rotation.x < -0.1305262)
        {
            desiredXAngle = -15f;
            print("move");
        }
        */
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.Rotate(-vertical, 0, 0);
        /*if (target.rotation.y > 0.2588191)
        {
            desiredYAngle = 30;
            print("move");
        }
        if (target.rotation.y < -0.2588191)
        {
            desiredYAngle = -30;
            print("move");
        }
        */
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        target.position = new Vector3(player.position.x, player.position.y / 5, player.position.z / 2);

        transform.LookAt(player);
    }
}
