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
    DialogueManager dialogueManager;
    Radio radio;

    int buildingCompleteBonus = 25;
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float jumpSpeed = 15f;
    bool isRunning = false;
    bool isJumping = false;
    bool isAtDoor = false;
    bool isAtCabinet = false;
    bool isAtRadio = false;



    Door door;
    Cabinet cabinet;
    SpawnPoint spawnPoint;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        radio = FindObjectOfType<Radio>();


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
        else if(other.gameObject.tag == "Cabinet")
        {
            isAtCabinet = true;
            cabinet = other.GetComponent<Cabinet>();
        }
        else if(other.gameObject.tag == "Radio")
        {
            isAtRadio = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Door")
        {
            isAtDoor = false;
            door = null;
        }
        else if(other.gameObject.tag == "Cabinet")
        {
            isAtCabinet = false;
            cabinet = null;
        }
        else if (other.gameObject.tag == "Radio")
        {
            isAtRadio = false;
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
            else if(isAtCabinet)
            {
                if(radio)
                {
                    if(radio.GetHasBeenFound())
                    {
                        bool hasItem = cabinet.GetHasItem();
                        if (hasItem)
                        {
                            radio.ItemFound();
                            string itemFoundText = cabinet.GetItemFoundText();
                            dialogueManager.SetUIText(itemFoundText, 4f);
                        }
                        else
                        {
                            string itemNotFoundText = cabinet.GetItemNotFoundText();
                            dialogueManager.SetUIText(itemNotFoundText, 4f);
                        }
                    }
                }
            }
            else if(isAtRadio)
            {
                if (radio.GetAllItemsFound())
                {
                    gameManager.AddToScore(buildingCompleteBonus);
                    dialogueManager.SetUIText("Sweet, I found everything!", 4f);
                }
                else
                {
                    string[] radioNeeds = radio.GetRadioNeeds();
                    radio.SetHasBeenFound();
                    string radioItems = "";
                    foreach (string item in radioNeeds)
                    {
                        radioItems += $"\n{item}";
                    }
                    dialogueManager.SetUIText($"Found it! But it's not working! I need to find: {radioItems}", 4f);
                }
                
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

        SceneManager.LoadScene(nextScene);
    }
}
