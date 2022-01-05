using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_6 : MonoBehaviour
{
    private Rigidbody playerRb; 
    private Animator playerAnim; 
    private AudioSource playerAudio;

    [SerializeField] private float jumpForce; //регул€тор силы прыжка (чем больше число, тем сильнее прыжок персонажа)
    [SerializeField] private float gravityModifier; //регул€тор силы прит€жени€ (чем больше число, тем сильнее сила прит€жени€ по оси у) 
    [SerializeField] private bool isOnGround=true; //проверка, стоит персонаж на земле или нет (true - стоит на земле, false - не стоит на земле)
    public bool gameOver;
    [SerializeField] private ParticleSystem explosionParticle; //переменна€ дл€ манипул€ции анимационным эффектом дыма 
    [SerializeField] private ParticleSystem dirtParticle; //переменна€ дл€ манипул€ции анимационным эффектом гр€зи 
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound; 
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); 
        Physics.gravity *= gravityModifier; 
        playerAnim = GetComponent<Animator>(); 
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig"); 
            dirtParticle.Stop(); 
            playerAudio.PlayOneShot(jumpSound, 1.0f); 

        }

    }

    private void OnCollisionEnter(Collision collision) 
    {

        if (collision.gameObject.CompareTag("Ground")) 
        {
            isOnGround = true; 
            dirtParticle.Play(); 
        }
        else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Debug.Log("Game over!"); 
            gameOver = true; 

            playerAnim.SetBool("Death_b",true); 
            playerAnim.SetInteger("DeathType_int", 1); 

            explosionParticle.Play(); 
            dirtParticle.Stop(); 
            playerAudio.PlayOneShot(crashSound, 1.0f); 
        }
    }
}
