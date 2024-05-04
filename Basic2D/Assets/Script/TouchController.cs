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

            //Dokunma iþlemi baþladýðýnda
            if(touch.phase == TouchPhase.Began)
            {
                Debug.Log("Ekranýn Koordinatlarý: " + touch.position);
            }

            //Parmak sürüklendiðinde
            if(touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Parmak sürükleniyor. Hareket Miktarý: " + touch.deltaPosition);
            }

            //Dokunma devam ettiði sürece
            if(touch.phase == TouchPhase.Stationary)
            {
                Debug.Log("Dokunma Devam Ediyor.");
            }

            //Dokunma sonlandýðýnda
            if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                Debug.Log("Dokunma sonlandý");
            }

            //Ekranýn saðýna mým solunamý dokunuyoruz

            if(touch.position.x < Screen.width / 2)
            {
                Debug.Log("Ekranýn soluna dokunuyor.");
            }
            else
            {
                Debug.Log("Ekranýn saðýna dokunuyorsun.");
            }
        }
    }
}
