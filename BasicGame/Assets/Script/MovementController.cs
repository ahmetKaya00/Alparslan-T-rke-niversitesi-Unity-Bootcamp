using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 hareketYonu = new Vector3(horizontal, 0f, vertical).normalized;

        transform.Translate(hareketYonu * _speed * Time.deltaTime);
    }
}
