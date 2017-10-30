using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour {


    public AudioClip open_s;
    public AudioClip close_s;
    public AudioClip keypad_s;
    public AudioClip locked_s;
    public AudioClip unlocked_s;

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
        /*
        if (m_active == false)
        {
            //Debug.Log("not active");
            
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
            //Debug.Log("Active");
        }
        */
    }

    private void Close()
    {
        m_open = false;
        m_anim.SetBool("Open", false);
        m_audio.PlayOneShot(open_s, 1);
        m_active = false;
    }

    private void Open()
    {
        m_open = true;
        m_anim.SetBool("Open", true);
        
        m_audio.PlayOneShot(close_s, 1);
        m_active = false;

        Invoke("Close", 5);
    }

    public void Locked()
    {
        m_audio.PlayOneShot(locked_s, 1);
    }

    public void Transition()
    {
        if (!m_open)
        {
            m_audio.PlayOneShot(keypad_s, 1);
            Invoke("Accepted", 1.5f);
        }
        /*else
        {
            Invoke("Close", 1.7f);
        }
        */
    }

    public void Accepted()
    {
        m_audio.PlayOneShot(unlocked_s, 1);
        Invoke("Open", 0.5f);
    }

    public void Denied()
    {
        m_audio.PlayOneShot(keypad_s, 1);
        Invoke("Locked", 1.5f);
    }
}
