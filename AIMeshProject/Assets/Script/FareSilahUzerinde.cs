using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FareSilahUzerinde : MonoBehaviour
{
    public float Mesafe = PlayDokumanasyon.HedefMesafe;
    public GameObject YaziGoster;

    private void Update()
    {
        Mesafe = PlayDokumanasyon.HedefMesafe;
    }

    private void OnMouseOver()
    {
        if(Mesafe < 3)
        {
            YaziGoster.GetComponent<Text>().text = "Silahý Al";
        }

    }

    private void OnMouseExit()
    {
        YaziGoster.GetComponent<Text>().text = "";
    }
}
