using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] Light gameLight;
    [SerializeField] float transitionDuration = 15f; // Geçiþ süresi

    float minIntensity = 0f; // Minimum ýþýk þiddeti
    float maxIntensity = 2f; // Maksimum ýþýk þiddeti

    private void Start()
    {
        StartCoroutine(LightRoutine());
    }

    IEnumerator LightRoutine()
    {
        float t = 0f;
        while (true)
        {
            // Iþýk parlaklýðýný artýr
            while (t < transitionDuration)
            {
                t += Time.deltaTime;
                float normalizedTime = t / transitionDuration;
                gameLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, normalizedTime);
                yield return null;
            }

            // Bekle
            yield return new WaitForSeconds(15f);

            // Iþýk parlaklýðýný azalt
            t = 0f;
            while (t < transitionDuration)
            {
                t += Time.deltaTime;
                float normalizedTime = t / transitionDuration;
                gameLight.intensity = Mathf.Lerp(maxIntensity, minIntensity, normalizedTime);
                yield return null;
            }

            // Bekle
            yield return new WaitForSeconds(15f);
        }
    }
}
