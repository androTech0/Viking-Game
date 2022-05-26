using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public float speed = 6f;

    CharacterController controller;
    Vector3 moveDirection = Vector3.zero;

    private float x;
    private float y;
    float Speed = 3;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }


    void Update()
    {

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;


        Vector3 translate = moveDirection.normalized * 5;

        controller.Move(transform.rotation * translate * Time.deltaTime);
        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            x += Input.GetAxis("Mouse X") * Speed;
            y -= Input.GetAxis("Mouse Y") * Speed;
        }
        

        transform.rotation = Quaternion.Euler(y, x, 0);
    }

}