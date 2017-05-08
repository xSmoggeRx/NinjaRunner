using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    private static bool extasisVelocidad;
    private bool corriendo = false;
    public static float velocidad=9.8f;
    private bool dobleSalto = true;
    private bool enSuelo=false;
    public float fuerzaSalto =100f;
    public float fuerzaDash = 100f;
    public GameObject distanciadorX;
    public GameObject distanciadorY;
    private Animator anim;
    private static int acumulatedDashes;
    private static int acumulatedRunStones;

    AudioSource audioPlayer;
    public AudioClip jump;
    public AudioClip dashClip;
    private int contJump = 0;

    void Awake()
    {
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("MainCamera");
        if (tmp.Length>1)
        {
            Destroy(tmp[0]);
        }
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start () {
        velocidad = 9.8f;
        extasisVelocidad = false;
        corriendo = true;
        enSuelo = true;
        acumulatedDashes =0;
        acumulatedRunStones = 0;
        
	}
	

	// Update is called once per frame
	void Update () {
       
        Debug.Log(velocidad);
        GameController.SumarDistance(Time.deltaTime);

        
        /*if (Input.GetMouseButtonDown(0))
        {
            if (enSuelo|| contJump<2)
            {
               
                enSuelo = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));

                contJump++;
                anim.SetBool("isJumping", true);
                anim.SetBool("isDashing", false);
                anim.SetBool("isGrounded", false);


            }
           


        }*/

        /*if (Input.GetMouseButtonDown((1)))
        {
            if (!(acumulatedDashes < 1))
            {

                anim.SetBool("isJumping", false);
                anim.SetBool("isDashing", true);
                anim.SetBool("isGrounded", false);


                GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaDash, 0));
                acumulatedDashes--;
                contJump--;
                Invoke("CambioTemporal",0.3f);
            }
           
        }*/

        /*
        if (Input.GetMouseButtonDown(2))
        {
            if (!extasisVelocidad && acumulatedRunStones>0)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isDashing", false);
                anim.SetBool("isRunStone", true);
                anim.SetBool("isGrounded", false);

                acumulatedRunStones--;
                StartCoroutine(SubirVelocidad());
                
            }
        }*/

       /* if (GetComponent<Rigidbody2D>().velocity.y < -0.1)
        {
            enSuelo = false;
            anim.SetBool("isJumping", true);
            anim.SetBool("isDashing", false);
            anim.SetBool("isGrounded", false);

        }*/
        if (distanciadorX.transform.position.x>transform.position.x||distanciadorY.transform.position.y > transform.position.y )
        {
            SceneManager.LoadScene("GameOver");
        }
        PlayerPrefs.SetInt("dash",acumulatedDashes);
        PlayerPrefs.SetInt("run", acumulatedRunStones);

    }

    void FixedUpdate()
    {
        
        if (corriendo)
        {
            GetComponent<Rigidbody2D>().velocity= new Vector2(velocidad,GetComponent<Rigidbody2D>().velocity.y);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        
       
        if (collision.gameObject.tag.Equals("Ground")) {
            Debug.Log("ground");
            enSuelo = true;
            contJump = 0;
            anim.SetBool("isJumping", false);
            anim.SetBool("isDashing", false);
            anim.SetBool("isGrounded", true);
            dobleSalto = true; 
        }
    }

    IEnumerator SubirVelocidad()
    {
        if (!extasisVelocidad)
        {
            
            Player.CambioVelocidad(12);
            extasisVelocidad=true;
            yield return new WaitForSeconds(5);
            anim.SetBool("isJumping", false);
            anim.SetBool("isDashing", false);
            anim.SetBool("isRunStone", false);
            anim.SetBool("isGrounded", true);
            Player.CambioVelocidad(9.8f);
            extasisVelocidad=false;
           

        }

    }

    public void CollisionHorizontal()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -250));
  
    }


   /** void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Debug.Log("aire");
            enSuelo = false;
            anim.SetBool("isJumping", true);

        }
    }**/

    public static void SumarDash()
    {
        acumulatedDashes++;
    }

    public static void SumarRunStone()
    {
        acumulatedRunStones++;
    }

    public static void CambioVelocidad(float f)
    {
        velocidad = f;
    }

    void CambioTemporal()
    {
        if (GetComponent<Rigidbody2D>().velocity.y < -0.1 || GetComponent<Rigidbody2D>().velocity.y > -0.1)
        {
            enSuelo = false;
            anim.SetBool("isJumping", true);
            anim.SetBool("isDashing", false);
            anim.SetBool("isGrounded", false);
        }else
        {
            enSuelo = true;
            anim.SetBool("isJumping", false);
            anim.SetBool("isDashing", false);
            anim.SetBool("isGrounded", true);
        }
    }

    public static void SetExtasis(bool boolean)
    {
        extasisVelocidad = boolean;
    }

    public static bool GetExtasis()
    {
        return extasisVelocidad;
    }

    public void Saltar()
    {

        if (enSuelo || contJump < 2)
        {
            audioPlayer.PlayOneShot(jump, 0.7F);
            enSuelo = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));

            contJump++;
            anim.SetBool("isJumping", true);
            anim.SetBool("isDashing", false);
            anim.SetBool("isGrounded", false);


        }
    }

    public void Dashear()
    {

        if (!(acumulatedDashes < 1))
        {

            anim.SetBool("isJumping", false);
            anim.SetBool("isDashing", true);
            anim.SetBool("isGrounded", false);
            audioPlayer.PlayOneShot(dashClip, 0.7F);

            GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaDash, 0));
            acumulatedDashes--;
            contJump--;
            Invoke("CambioTemporal", 0.3f);
        }
    }

    public void RunUp()
    {
        if (!extasisVelocidad && acumulatedRunStones > 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isDashing", false);
            anim.SetBool("isRunStone", true);
            anim.SetBool("isGrounded", false);
            audioPlayer.PlayOneShot(dashClip, 0.7F);
            acumulatedRunStones--;
            StartCoroutine(SubirVelocidad());

        }
    }

    
}
