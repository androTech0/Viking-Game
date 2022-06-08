using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public float speed = 6f;

    CharacterController controller;
    Vector3 moveDirection = Vector3.zero;

    private float x;
    private float y;
    void Start()
    {
        controller = GetComponent<CharacterController>();

        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }


    void Update()
    {

        Vector3 translate = moveDirection.normalized * speed;

        controller.Move(transform.rotation * translate * Time.deltaTime);
        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            x += Input.GetAxis("Mouse X") * 3;
            y -= Input.GetAxis("Mouse Y") * 3;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = 14f;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = 6f;
        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection *= 6f;

        transform.rotation = Quaternion.Euler(y, x, 0);
    }

}