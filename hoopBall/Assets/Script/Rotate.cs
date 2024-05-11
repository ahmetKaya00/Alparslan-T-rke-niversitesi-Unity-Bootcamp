using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float donmeHizi = 100f;

    private void Update()
    {
        transform.Rotate(0f, 0f, donmeHizi * Time.deltaTime);
    }
}
