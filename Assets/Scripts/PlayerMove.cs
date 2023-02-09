using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    Animator anim;

   

    
    private GameObject [] clonecylinder;
    
    public Button leftbutton;
    public Button rightbutton;

    private List<GameObject> activeTiles;

    

    
    

    
     
    Rigidbody rb;

    public int  playerspeed;

    public ScoreScript scorescript;

    public SimpleTouchController joystickcontroller;
    float size = 0;
    float yatay;

    private Transform playerTransform;

    private float spawnY = 0f;

    private float tileLength =144;

    private int Tilesonscreen = 3; 

    private float safeZone = 100f;

    public GameObject go;

    public float buttonx = 1;




    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); 
        //yatay = Input.GetAxis("Horizontal");  // geminin sağ ve sola gitmesini ayarlar
        activeTiles = new List<GameObject>();
        
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        for (int i = 0; i < Tilesonscreen; i++)
        {
           spawntile(); 
        }

        
        
    }


    private void spawntile(int prefabIndex = -1)  // oyunun sonsuza kadar deam etmesi için haritada tileları spawnlar
    {
         
        go = Instantiate(tilePrefabs[0]) as GameObject;

       
        


       go.SetActive(true);

        go.transform.position = Vector3.down* (-1) *spawnY;

        spawnY += tileLength;

        activeTiles.Add(go);




    }

    private void deletetile()   // oyun rame çok yüklenmesin diye arkamızda kalan tileları siler
    {

        Destroy (activeTiles[0]);
        activeTiles.RemoveAt(0);

    }


    // Update is called once per frame
    void FixedUpdate()
    {
          



        if (scorescript.score > 50)
        {
            playerspeed = playerspeed +1; //skor 10 u geçtikten sonra hız 1 er 1 er artar
        }

        
        yatay = joystickcontroller.GetTouchPosition.x;
        
        yatay = yatay*4;

        
        
            
        
       // yatay = Input.GetAxis("Horizontal");

            rb.velocity =new Vector3 ( 0,playerspeed,0)* Time.fixedDeltaTime; //geminin yukarı yönde uçmasını sağlar
           
        
        
         
                for (int i = 0; i < activeTiles.Count; i++)
                {
                  activeTiles[i].transform.Rotate(0,yatay,0);  //silindir ve çevresinin dönmesini sağlar
                   
                }
                

            if (playerTransform.position.y -safeZone > (spawnY - Tilesonscreen * tileLength )  ) // eğer tile sayısı karakterin tile kadar boyundan küçükse yeni tile yaratır
            {
                spawntile();
                deletetile();
            }
        
        

    }

    


       
}
