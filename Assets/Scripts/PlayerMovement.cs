using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D playerRigidBody;
    Animator playerAnimator;
    GameManager gameManager;

    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float jumpSpeed = 15f;
    bool isRunning = false;
    bool isJumping = false;
    bool isAtDoor = false;

    Door door;
    SpawnPoint spawnPoint;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();


        spawnPoint = FindObjectOfType<SpawnPoint>();
        if(spawnPoint)
        {
            transform.position = spawnPoint.transform.position;
        }
        else
        {
            Vector3 spawnLocation = gameManager.GetStreetSpawnLocation();
            transform.position = spawnLocation;
        }
    }

    
    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(value.isPressed && !isJumping)
        {
            isJumping = true;
            playerRigidBody.velocity += new Vector2(0f, jumpSpeed);
            playerAnimator.SetBool("isJumping", isJumping);
        }
    }

    void Run()
    {
        isRunning = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", isRunning);
        Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, playerRigidBody.velocity.y);
        playerRigidBody.velocity = playerVelocity;
    }

    void FlipSprite()
    {
        bool isMoving = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;

        if(isMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidBody.velocity.x), 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground")
        {
            isJumping = false;
            playerAnimator.SetBool("isJumping", isJumping);
        }        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Door")
        {
            isAtDoor = true;
            door = other.GetComponent<Door>();
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Door")
        {
            isAtDoor = false;
            door = null;
        }
    }


    void OnInteract(InputValue value)
    {
        if(value.isPressed)
        {
            if(isAtDoor)
            {
                string nextScene = door.GetNextSceneName();
                EnterBuilding(nextScene);
            }
        }
    }
    
    void EnterBuilding(string nextScene)
    {
        if(!door.GetIsExit())
        {
            Vector3 playerPosition = transform.position;
            gameManager.SetStreetSpawnLocation(playerPosition);
        }
        // else
        // {
        //     gameManager.SetNextSpawnLocation(gameManager.GetStreetSpawnLocation());
        // }
        SceneManager.LoadScene(nextScene);
    }
}
