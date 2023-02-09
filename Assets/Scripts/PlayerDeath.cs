using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject Player;

    public GameObject GameoverPanel;

    public ScoreScript scoreScript;

    public GameObject explosioneffect;

   public AudioSource ad;

   bool timeron=false;

   float timeleft = 0.5f;

   public GameObject scoretext;

   public GameObject highscoretext;

   public GameObject combotext;

   public GameObject explodesound;

    // Start is called before the first frame update
    void Start()
    {
        GameoverPanel.SetActive(false); // oyunun başında paneli kapatır

        ad = gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    if (timeron)                //gemi çarpıp yok olduktan 0.2 saniye zaman tutar ve o zamana ralığındageminin yok olma animasyonu çalışır
        {
                if (timeleft > 0)
            {
                timeleft -= Time.fixedDeltaTime;
            }
                else
            {
                Time.timeScale=0;
                timeleft = 0;
                timeron = false;

                
            }
        }

    }

    void OnTriggerEnter(Collider hitinfo)
    {
        if(hitinfo.gameObject.tag == "enemy") // eğer gemi çarparsa gemi yok olur ve ölüm ekranı gelir
        {
            Instantiate(explosioneffect,transform.position,transform.rotation); //gemi yok olunca patlama efekti çalışır
            explodesound.gameObject.SetActive(true);    //ölünce patlama sesini aktif eder;

            timeron = true;
        
           
            
            
            Player.GetComponent<Renderer>().enabled=false;


            GameoverPanel.SetActive(true);

            scoretext.gameObject.SetActive(false);

            highscoretext.gameObject.SetActive(false);

            combotext.gameObject.SetActive(false);
            
            scoreScript.Hscoretext.text="";
            scoreScript.Scoretext.text="";

            ad.Stop();
            

        }

    }
}
