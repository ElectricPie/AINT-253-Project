using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private DoorAnimation animCont;

    public float sensitivity = 1;

    [SerializeField]
    private float m_speed = 0.8f;

    [SerializeField]
    private float m_jump = 5;

    private float m_interactDelay;

    private Rigidbody m_rigidbody;

    private Transform m_transform;

    private bool m_grounded;
    private bool m_holdingObj = false;

    Vector3 temp;

    // Use this for initialization
    void Start () {
        m_rigidbody = GetComponent<Rigidbody>();
        m_transform = GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update() {
        /*
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        float xMouseInput = Input.GetAxis("Mouse X") * sensitivity;

        temp = ((transform.right * xInput) + (transform.forward * zInput)) * m_speed;
        //m_transform.position += m_transform.forward * m_speed * zInput * Time.deltaTime;

        if (temp.x > 0.2)
            temp.x = 0.2f;

        if (temp.x < -0.2)
            temp.x = -0.2f;

        if (temp.z > 0.2)
            temp.z = 0.2f;

        if (temp.z < -0.2)
            temp.z = -0.2f;

        //Jumping
        if (Input.GetAxis("Jump") == 1 && m_grounded == true)
        {
            temp.y += m_jump;
            m_grounded = false;
        }
        */

        //Interacting
        if (Input.GetAxis("Interact") == 1 && m_interactDelay <= 0)
        {

            Transform cam = Camera.main.transform;
            Ray ray = new Ray(cam.position, cam.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
               

                print(hit.collider.tag);

                if (hit.collider.tag == "Door")
                {
                    try
                    {
                        animCont = hit.collider.gameObject.transform.parent.GetComponent<DoorAnimation>();
                        animCont.Transition();
                    }
                    catch
                    {
                        animCont = hit.collider.gameObject.transform.parent.parent.GetComponent<DoorAnimation>();
                        animCont.Transition();
                    }
                    m_interactDelay = 5;
                }
                else if (hit.collider.tag == "Locked Door")
                {
                    try
                    {
                        animCont = hit.collider.gameObject.transform.parent.GetComponent<DoorAnimation>();
                        animCont.Denied();
                    }
                    catch
                    {
                        animCont = hit.collider.gameObject.transform.parent.parent.GetComponent<DoorAnimation>();
                        animCont.Denied();
                    }
                    m_interactDelay = 5;
                }
            }

            
        }

        if (m_interactDelay > 0)
        {
            m_interactDelay -= Time.deltaTime * 1;
        }

        /*
        m_rigidbody.velocity += temp;
        transform.Rotate(0, xMouseInput, 0);
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        // m_grounded = true;
    }
}

