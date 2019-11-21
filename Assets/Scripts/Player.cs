using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Fisicas
    private Rigidbody2D rgbPlayer;
    [Range(100,200)]
    public float jumpForce;
    //Puntos e interface de puntos
    private int points;
    public Text scoreText;
    public Text scoreMaxText;
    //interface gameover
    public GameObject menuGameOver;
    bool isDead;
    //Musica
    public AudioClip jumpSound;
    public AudioClip gameOverJump;
    public AudioClip morePoints;
    private AudioSource emittingSound;
    //Colisiones
    private Collider2D colliderPlayer;
    private void Start()
    {
        rgbPlayer = GetComponent<Rigidbody2D>();
        //PlayerPrefs.SetInt("ScoreMax",0 );
        scoreMaxText.text ="MaxScore: " + PlayerPrefs.GetInt("ScoreMax").ToString();
        isDead = false;
        emittingSound = GetComponent<AudioSource>();
        colliderPlayer = GetComponent<Collider2D>();
        colliderPlayer.enabled = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDead == false)
        {
            rgbPlayer.AddForce(new Vector2(0f, jumpForce));
            emittingSound.PlayOneShot(jumpSound);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Points")
        {
            points++;
            scoreText.text = "Score: " + points.ToString();
            if (PlayerPrefs.GetInt("ScoreMax") <points)
            {
                PlayerPrefs.SetInt("ScoreMax", points);
                scoreMaxText.text = "MaxScore: " + PlayerPrefs.GetInt("ScoreMax").ToString();
            }
            emittingSound.PlayOneShot(morePoints);
        }
        else if (other.tag == "Obstacle")
        {
            isDead = true;
            menuGameOver.SetActive(true);
            emittingSound.PlayOneShot(gameOverJump);
            colliderPlayer.enabled = false;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //SceneManager.LoadScene("MainMenu");
        }
    }
}
