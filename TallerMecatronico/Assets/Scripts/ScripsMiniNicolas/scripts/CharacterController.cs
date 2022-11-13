using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public bool gameOver = false;
    public bool start = false;
    public bool objetivos = false;
    public bool HUD = false;
    public GameObject menuInicio;
    public GameObject menuGameOver;
    public GameObject menuobjetivos;
    public GameObject mHUD;
    public GameObject balaprefab;
    public float velocidad;
    public float fuerzaSalto;
    public float saltosMaximos;
    public LayerMask capaSuelo;
    public AudioManager audioManager;
    
    public int Health = 5;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha = true;
    private float saltosRestantes;
    private Animator animator;
    private float LastShoot;
    
    [SerializeField] private barravida Barravida;
    [SerializeField] AudioSource audiogameover;


    bool isLeft = false;
    bool isRight = false;
    bool isdispara = false;
    bool isJump = false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;
        animator = GetComponent<Animator>();
        Barravida.Inicializarbarradevida(Health);
    }

    // Update is called once per frame
    void Update()
    {       
        semurio();
        if (start == false)
        {
            if(Input.GetKeyDown(KeyCode.E) || isJump)
            {
                start=true;
            }
            
        }        
        if (start == true && gameOver == true)
            {             
           
                menuGameOver.SetActive(true);
                mHUD.SetActive(false);
                menuobjetivos.SetActive(false);      
                if(Input.GetKeyDown(KeyCode.E) || isJump)
                {  
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);                    
                } 
                
            }
        if(start == true && gameOver == false)
        { 
            objetivos = true;
            HUD = true;
            mHUD.SetActive(true);
            menuobjetivos.SetActive(true); 
            menuInicio.SetActive(false); 
              
            ProcesarMovimiento();
            ProcesarSalto();
            Dispara();  
            Botones();      
    
        }
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    void ProcesarSalto()
    {
        if(EstaEnSuelo())
        {
            saltosRestantes = saltosMaximos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes--;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            //audioManager.ReproducirSonido(sonidoSalto);
        }
    }
    void ProcesarSaltob()
    {
        if(EstaEnSuelo() )
        {
            saltosRestantes = saltosMaximos;
        }  
        if (saltosRestantes > 0) 
        {    
            saltosRestantes--;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            //audioManager.ReproducirSonido(sonidoSalto);
        }        
    }

    void ProcesarMovimiento()
    {
        // Lógica de movimiento
        float inputMovimiento = Input.GetAxis("Horizontal");

        if(inputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y);
        GestionarOrientacion(inputMovimiento);   
        
    }

    void GestionarOrientacion(float inputMovimiento)
    {
        // Si se cumple condición
        if( (mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0) )
        {
            // Ejecutar código de volteado
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
    
    public void clickLeft()
    {
        isLeft = true;
    }

    public void releaseLeft()
    {
        isLeft = false;
    }

    public void clickRight()
    {
        isRight = true;
    }

    public void releaseRight()
    {
        isRight = false;        
    }

    public void clickdispara()
    {
        dispara();
        isdispara = true;
    }

    public void releasedispara()
    {
        isdispara = false;        
    }

    public void clickJump()
    {
        isJump = true;
    }
    public void releaseJump()
    {
        isJump = false;
    }


    private void Botones()
    {
        if ( isLeft)
        {
            rigidBody.velocity = new Vector2(-velocidad, rigidBody.velocity.y);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); 
            if(velocidad != 0f)
            {
            animator.SetBool("isRunning", true);
            }
            else
            {
            animator.SetBool("isRunning", false);
            }
         
        }
        if ( isRight)
        {
            rigidBody.velocity = new Vector2(velocidad, rigidBody.velocity.y);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            if(velocidad != 0f)
            {
            animator.SetBool("isRunning", true);
            }
            else
            {
            animator.SetBool("isRunning", false);
            }
        }
        if ( isJump)
        {
            ProcesarSaltob();
        }
    }


    void Dispara()
    {
    if(Input.GetKeyDown(KeyCode.X) && Time.time > LastShoot + 0.25f)
        {
            dispara();
            LastShoot = Time.time;
        }     
    }
    private void dispara()
    {   
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject Bala = Instantiate(balaprefab, transform.position + direction * 1.0f, Quaternion.identity);
        Bala.GetComponent<bala2>().SetDirection(direction);
    }
    public void Hit()
    {
        Health -= 1;
        Barravida.Cambiarvidaactual(Health);
        semurio();
                   
    }
    public void semurio()
    {
        if (Health <= 0 && gameOver == false)
        {            
            audiogameover.Play();      
            gameOver = true;                                                     
        }         
    }
    public void Hitfull()
    {
        Health -= 5;
        semurio();
    }
}