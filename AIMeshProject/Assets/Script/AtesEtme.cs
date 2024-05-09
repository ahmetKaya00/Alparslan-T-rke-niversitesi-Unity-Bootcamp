using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesEtme : MonoBehaviour
{
    [SerializeField] private int hasarMiktari = 5;
    [SerializeField] private float hedefUzakligi, VerilenUzaklik = 15f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Mermi._cephane > 0)
        {


            RaycastHit Atis;

            if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out Atis))
            {
                hedefUzakligi = Atis.distance;
                if(hedefUzakligi < VerilenUzaklik)
                {
                    Atis.transform.SendMessage("dusman", hasarMiktari);
                }
            }
            if(Mermi._cephane == 0)
            {
                Debug.Log("Mermi yok");
            }
            else
            {
                Mermi._cephane -= 1;
            }
            
        }
    }
}
