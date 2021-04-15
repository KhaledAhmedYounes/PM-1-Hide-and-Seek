using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private Camera viewCamera;
    private Vector3 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetMoveDir();
        LookAtMousePointer();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * Time.deltaTime);
    }

    private void GetMoveDir()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(h, 0, v).normalized * speed;
    }

    private void LookAtMousePointer()
    {
        Vector3 mousePosition = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        transform.LookAt(mousePosition + Vector3.up * transform.position.y);
    }
}
