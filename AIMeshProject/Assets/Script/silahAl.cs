using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silahAl : MonoBehaviour
{
    public float Mesafe = PlayDokumanasyon.HedefMesafe;
    public GameObject Yazý, anaSilah, yedekSilah, cephane;
    public AudioSource almaSesi;

    void Start()
    {
        Yazý.SetActive(false);
        anaSilah.SetActive(false);
        cephane.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("silahAl"))
        {
            if(Mesafe <= 2)
            {
                silahAlindi();
            }
        }
    }

    void silahAlindi()
    {
        almaSesi.Play();
        transform.position = new Vector3(0, -50, 0);
        yedekSilah.SetActive(true);
        anaSilah.SetActive(true);
        cephane.SetActive(true);
        Yazý.SetActive(true);
    }
}
