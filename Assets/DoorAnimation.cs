using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour {

    [SerializeField]
    private AudioClip m_open_s;

    [SerializeField]
    private AudioClip m_close_s;

    [SerializeField]
    private AudioClip m_keypad_s;

    private Animator m_anim;
    private AudioSource m_audio;
    private bool m_open;
    private bool m_active;

    // Use this for initialization
    void Start () {
        m_open = false;
        m_active = false;

        m_anim = GetComponent<Animator>();
        m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_active == false)
        {
            Debug.Log("not active");
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                m_active = true;
                if (m_open == true)
                {
                    Invoke("Open", 1);
                }
                else
                {
                    m_audio.PlayOneShot(m_keypad_s, 1);
                    Invoke("Close", 1.7f);
                }
            }
        }
        else
        {
            Debug.Log("Active");
        }
    }

    void Open()
    {
        m_open = false;
        m_anim.SetBool("open", false);
        m_audio.PlayOneShot(m_open_s, 1);
        m_active = false;
    }

    void Close()
    {
        m_open = true;
        m_anim.SetBool("open", true);
        m_audio.PlayOneShot(m_close_s, 1);
        m_active = false;
    }
}
