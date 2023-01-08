using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  // DEFAULT VALUES
  /* makes it private to other classes, but can be accessed via inspector panel */
  [SerializeField]
  private float moveForce = 10f;

  [SerializeField]
  private float jumpForce = 11f;

  private float movementX;

  [SerializeField]
  private Rigidbody2D myBody;

  private SpriteRenderer sr;

  private Animator anim;
  private string WALK_ANIMATION = "Walk";

  private bool isGrounded;
  private string GROUND_TAG = "Ground";

  private string ENEMY_TAG = "Enemy";

  private void Awake()
  {
    /* how we get component from code... like dragging & dropping */
    myBody = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    sr = GetComponent<SpriteRenderer>();
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame, if MonoBehaviour is enabled
  void Update()
  {
    PlayerMoveKeyboard();
    AnimatePlayer();
    PlayerJump();
  }

  // Called ever fixed framerate frame, if MonoBehaviour is enabled
  // private void FixedUpdate()
  // {
  //   PlayerJump();
  // }

  void PlayerMoveKeyboard()
  {
    /* Get input when we press left/right key or a/d key */
    /* goes from 0 --> -1 or 0 --> 1*/
    movementX = Input.GetAxisRaw("Horizontal");
    /* Time.deltaTime is the completion time in seconds since last frame.
    Time between each frame */
    transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
  }

  void AnimatePlayer()
  {
    // Going to the right side
    if (movementX > 0)
    {
      anim.SetBool(WALK_ANIMATION, true);
      sr.flipX = false;
    }
    else if (movementX < 0)
    {
      // Going to left side
      anim.SetBool(WALK_ANIMATION, true);
      sr.flipX = true;
    }
    else
    {
      anim.SetBool(WALK_ANIMATION, false);
    }
  }

  void PlayerJump()
  {
    // Will use default button for platform to perform jump
    if (Input.GetButtonDown("Jump") && isGrounded)
    {
      isGrounded = false;
      myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag(GROUND_TAG))
      isGrounded = true;

    if (collision.gameObject.CompareTag(ENEMY_TAG))
      Destroy(gameObject);
    

  } // OnCollisionEnter2D

  private void OnTriggerEnter2D(Collider2D collision)
  {
      // Can omit curly brackets if only 1 line of code under if statement
      if (collision.CompareTag(ENEMY_TAG)) 
        Destroy(gameObject);
  }
} // class

