using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //Dokunma i�lemi ba�lad���nda
            if(touch.phase == TouchPhase.Began)
            {
                Debug.Log("Ekran�n Koordinatlar�: " + touch.position);
            }

            //Parmak s�r�klendi�inde
            if(touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Parmak s�r�kleniyor. Hareket Miktar�: " + touch.deltaPosition);
            }

            //Dokunma devam etti�i s�rece
            if(touch.phase == TouchPhase.Stationary)
            {
                Debug.Log("Dokunma Devam Ediyor.");
            }

            //Dokunma sonland���nda
            if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                Debug.Log("Dokunma sonland�");
            }

            //Ekran�n sa��na m�m solunam� dokunuyoruz

            if(touch.position.x < Screen.width / 2)
            {
                Debug.Log("Ekran�n soluna dokunuyor.");
            }
            else
            {
                Debug.Log("Ekran�n sa��na dokunuyorsun.");
            }
        }
    }
}
