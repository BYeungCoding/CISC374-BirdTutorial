using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D player;
    public float jumpForce = 10;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource jumpSound;
    public AudioSource thud;
    public bool thudPlayed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        jumpSound = audioSources[0];
        thud = audioSources[1];
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Object.FindFirstObjectByType<LogicScript>().gameStarted)
            return;

        if(Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            Jump();
        }

        if(transform.position.y > 18 || transform.position.y < -18){
            deadBird();
        }
    }

    void Jump()
    {
        player.linearVelocity = Vector2.up * jumpForce;
        jumpSound.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        deadBird();
        thud.Play();
    }

    private void deadBird(){
        birdIsAlive = false;
        logic.gameOver();
        if (!thudPlayed)
        {
            thud.Play();
            thudPlayed = true; // Set flag so it doesn't play again
        }
    }
}
