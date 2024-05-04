using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource audioTarget;
    public AudioClip sesDosyasi;
    private Transform kamera;

    private void Start()
    {
        audioTarget = GetComponent<AudioSource>();
        audioTarget.clip = sesDosyasi;
        audioTarget.Play();
        kamera = Camera.main.transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, kamera.position);

        float maxDistance = 10f;
        float normalizedDistance = Mathf.Clamp01(distance / maxDistance);

        audioTarget.volume = 1f - normalizedDistance;
    }
}
