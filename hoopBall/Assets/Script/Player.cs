using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float ziplama = 10f;
    private Rigidbody2D rb;

    private SpriteRenderer sr;
    public string CurrentColor;
    public Color ColorCam, ColorSari, ColorPembe, ColorMor;

    public Text score, PScore, PHScore;
    public int deger, number;

    public GameObject bir, iki, uc, dort, Panel;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        rb.bodyType = RigidbodyType2D.Static;
        RandomColor();
        Panel.SetActive(false);
        PHScore.text = PlayerPrefs.GetInt("HinghScore", 0).ToString();
    }

    private void Update()
    {
        score.text = deger.ToString("f0");
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {   
            rb.velocity = Vector2.up * ziplama;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ColorChanger")
        {
            RandomColor();
            collision.gameObject.transform.position = transform.position + new Vector3(0f, 27f, 0f);
            bir.gameObject.transform.position = transform.position + new Vector3(0f, 24f, 0f);
            deger++;
            number++;
            PScore.text = number.ToString();
            if(number > PlayerPrefs.GetInt("HinghScore", 0))
            {
                PlayerPrefs.SetInt("HinghScore", number);
                PHScore.text = number.ToString();
            }
            return;
        }
        if(collision.tag == "Two")
        {
            RandomColor();
            collision.gameObject.transform.position = transform.position + new Vector3(0f, 27f, 0f);
            iki.gameObject.transform.position = transform.position + new Vector3(0f, 24f, 0f);
            uc.gameObject.transform.position = transform.position + new Vector3(0f, 24f, 0f);
            deger++;
            number++;
            PScore.text = number.ToString();
            if (number > PlayerPrefs.GetInt("HinghScore", 0))
            {
                PlayerPrefs.SetInt("HinghScore", number);
                PHScore.text = number.ToString();
            }
            return;
        }if(collision.tag == "Three")
        {
            RandomColor();
            collision.gameObject.transform.position = transform.position + new Vector3(0f, 27f, 0f);
            dort.gameObject.transform.position = transform.position + new Vector3(0f, 24f, 0f);
            deger++;
            number++;
            PScore.text = number.ToString();
            if (number > PlayerPrefs.GetInt("HinghScore", 0))
            {
                PlayerPrefs.SetInt("HinghScore", number);
                PHScore.text = number.ToString();
            }
            return;
        }
        if(collision.tag != CurrentColor)
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void RandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                CurrentColor = "Cam";
                sr.color = ColorCam;
                break;
            case 1:
                CurrentColor = "Sarý";
                sr.color = ColorSari;
                break;
            case 2:
                CurrentColor = "Pembe";
                sr.color = ColorPembe;
                break;
            case 3:
                CurrentColor = "Mor";
                sr.color = ColorMor;
                break;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Replay()
    {
        this.transform.position = transform.position + new Vector3(0f, 1.5f, 0f);
        Panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }

}
