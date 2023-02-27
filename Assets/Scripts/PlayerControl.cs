using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    public float horizontalSpeed = 10f;
    public float verticalSpeed;
    private Rigidbody playerRb;
    //private Animator playerAnim;

    private bool isGrounded;

    public float jumpForce = 10f;

    /*
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    */






    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerAnim = GetComponent<Animator>();

        
    }

    void FixedUpdate() 
    {
        transform.Translate(Vector3.forward * verticalSpeed * Time.deltaTime);
    }
    void Update()
    {
        
        //playerRb.AddForce(Vector3.forward * verticalSpeed * Time.deltaTime);
       
       
       MovePlayer();
       /*
        if (transform.position.x > -5 && transform.position.x < 5 )
        {
            MovePlayer();
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }      
        */
        
        
        
        
        
        // space'e basildiginda karakter yerde ise ziplat
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerJump();
        }

    }


    // playeeri hareket ettiren metod.
    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * horizontalSpeed * horizontalInput );
        
    }
    
    // ziplama fonksiyonu
    void playerJump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    
    
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle !");
            
            SceneManager.LoadScene("LoseScreen");

        }

        /*
        if (other.gameObject.CompareTag("Star"))
        {
            Debug.Log("Star !");
        }
        */

        
    }
    
    
    
    /*
    void AnimationJump()
    {
        if (isGrounded == false)
        {
            playerAnim.SetBool("animJump", true);
        }
        else
        {
            playerAnim.SetBool("animRun", true);
        }
    }
    */

}
