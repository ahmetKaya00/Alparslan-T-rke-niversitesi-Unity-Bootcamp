using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TyperWriter : MonoBehaviour
{
    [SerializeField] private TMP_Text panelText;
    [SerializeField] private string[] texts;
    private int currentIndex = 0;
    [SerializeField] float delay = 0.1f;
    private Coroutine typingCoroutine;

    private void Start()
    {
        StartTyping();
    }
    public void StartTyping()
    {
        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        string fulllText = texts[currentIndex];

        for(int i = 0; i<= fulllText.Length; i++)
        {
            string currentText = fulllText.Substring(0, i);
            panelText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
    public void ChangeText()
    {
        currentIndex = (currentIndex+1)%texts.Length;
        StartTyping();
    }
}
