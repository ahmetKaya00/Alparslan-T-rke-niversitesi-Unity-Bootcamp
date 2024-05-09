using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] Light gameLight;
    [SerializeField] float transitionDuration = 15f; // Ge�i� s�resi

    float minIntensity = 0f; // Minimum ���k �iddeti
    float maxIntensity = 2f; // Maksimum ���k �iddeti

    private void Start()
    {
        StartCoroutine(LightRoutine());
    }

    IEnumerator LightRoutine()
    {
        float t = 0f;
        while (true)
        {
            // I��k parlakl���n� art�r
            while (t < transitionDuration)
            {
                t += Time.deltaTime;
                float normalizedTime = t / transitionDuration;
                gameLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, normalizedTime);
                yield return null;
            }

            // Bekle
            yield return new WaitForSeconds(15f);

            // I��k parlakl���n� azalt
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
