using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadline : MonoBehaviour
{
    public AudioSource audioSource;  // ����� AudioSource
    public AudioClip deadlineSound;  // ���� �浹�� ����

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
