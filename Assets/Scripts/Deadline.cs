using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadline : MonoBehaviour
{
    public AudioSource audioSource;  // 사용할 AudioSource
    public AudioClip deadlineSound;  // 나락 충돌시 사운드

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball")) { 
            DeadlineSound();
        }
    }

    void DeadlineSound()
    {
        audioSource.PlayOneShot(deadlineSound);
    }
}
