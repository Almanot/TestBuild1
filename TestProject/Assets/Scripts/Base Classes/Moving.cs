using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    float vertical;
    float horizontal;
    [SerializeField]
    private float speed = 1;
    Rigidbody rig;
    int layerMask;

    private void Start()
    {
        rig = new Rigidbody();
        layerMask = LayerMask.GetMask("OnMovable");
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        MovingForward(vertical);
        MovingHorizontal(horizontal);
        RotateByMouse();

    }

    void MovingForward(float value)
    {
        if (value != 0)
        {
            transform.Translate(new Vector3(0, 0, value) * Time.deltaTime * speed);
        }
    }

    void MovingHorizontal(float value)
    {
        if (value != 0)
        {
            transform.Translate(new Vector3(value, 0, 0) * Time.deltaTime * speed);
        }
    }

    void Rotation(Vector3 fowardDirection)
    {
        Quaternion newRotation = Quaternion.LookRotation(fowardDirection);
        transform.rotation = newRotation;
    }

    void RotateByMouse()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit, layerMask))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.yellow);
            Rotation(hit.point);
        }
    }
}
