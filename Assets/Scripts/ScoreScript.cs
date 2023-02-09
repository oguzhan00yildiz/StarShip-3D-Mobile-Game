using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreScript : MonoBehaviour
{
    public Text Scoretext;
    public Text Scoretextpanel;

    public Text Hscoretext;
    public Text Hscoretextpanel;

    public GameObject StartPanel;

    public GameObject MenuPanel;

    public float score=0;
    public float highscore=0;

    public GameObject Joystick;

    public AudioSource ad;

    public Text combotext;

    

    

    // Start is called before the first frame update
    void Start()
    {
      highscore = PlayerPrefs.GetFloat("highscore");  //en yüksek skoru kaydeder

      Time.timeScale=0;  // oyunu dondurur
    ad = gameObject.GetComponent<AudioSource>();    
      ad.Stop();
    }

    void ScoreStart()
    {
        
        Scoretext.text= "SKOR : " +  score.ToString("0.#"); //skoru ekranda gösterir

        if (score > highscore)
        {
            highscore = score;  //skoru en yüksek skora atar
            
        }

        

        Hscoretext.text = "EN YÜKSEK SKOR  " + ((int)highscore).ToString(); //en yüksek skoru ekranda gösterir

        PlayerPrefs.SetFloat("highscore",highscore); //enyüksek skoru kaydeder
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score = score + (0.1f); //skorun zaman geçtikçe artmasını sağlar

        ScoreStart();
        Hscoretextpanel.text = "EN YÜKSEK SKOR "+ ((int)highscore).ToString();
        Scoretextpanel.text = Scoretext.text;
        //PlayerPrefs.SetFloat("highscore",0); // gerektiğinde skoru sıfırlar
        
        if (score > 10)
        {
            combotext.text = "1.1X";            //eğer skor 10 dan büyükse skor 1.1x olarak artmaya başlar
            score = score + 0.01f;

        }

        if (score > 30)
        {
            combotext.text = "1.2X";
            score = score + 0.01f;
        }

        if (score > 50)
        {
            combotext.text = "1.3X";
            score = score + 0.01f;
        }

        if (score > 70)
        {
            combotext.text = "1.4X";
            score = score + 0.01f;
        }

        if (score > 90)
        {
            combotext.text = "1.5X";
            score = score + 0.01f;
        }

        if (score > 120)
        {
            combotext.text = "1.6X";
            score = score + 0.01f;
        }

        if (score > 150)
        {
            combotext.text = "1.7X";
            score = score + 0.01f;
        }

        if (score > 250)
        {
            combotext.text = "1.8X";
            score = score + 0.01f;
        }

        if (score > 400)
        {
            combotext.text = "1.9X";
            score = score + 0.01f;
        }

        if (score > 1000)
        {
            combotext.text = "2X";
            score = score + 0.01f;
        }

        if (score > 5000)
        {
            combotext.text = "2.1X";
            score = score + 0.01f;
        }

        if (score > 8000)
        {
            combotext.text = "2.2X";
            score = score + 0.01f;
        }


        

    }

    public void StartGame()
    {
        StartPanel.SetActive(false); //oyuna başlayınca giriş panelini gizler
        Time.timeScale = 1;

        Joystick.SetActive(true); // oyun başlayınca joystiği aktif eder
        ad.Play();          //oyun başlayınca müzik çalmaya başlar
        
    }

    public void RestartGame()       
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // oyunu yeniden başlatır
        MenuPanel.SetActive(false);
        ad.Play();
        
    }

    public void CloseMenu()
    {
        MenuPanel.SetActive(false); // Menüyü kapatır

    }

    public void ExitGame()  // oyundan çıkar
    {

        Application.Quit();
    }

}
