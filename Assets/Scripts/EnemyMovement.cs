using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] List<Transform> positions;
    int positionIndex = 0;
    Vector3 nextPosition;
    Animator enemyAnimator;
    Rigidbody2D enemyRigidBody;
    Vector3 oldPosition;
    Vector3 newPosition;

    void Start()
    {
        transform.position = positions[positionIndex].position;
        enemyAnimator = GetComponent<Animator>();
        enemyRigidBody = GetComponent<Rigidbody2D>();

        enemyAnimator.SetBool("isWalking", true);

        oldPosition = transform.position;
    }

    void Update()
    {

        nextPosition = positions[positionIndex].position;

        if (positionIndex < positions.Count)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
            
            // transform.localScale = new Vector2(Mathf.Sign(enemyRigidBody.velocity.x), 1f);

            newPosition = transform.position;
            Vector3 med = newPosition - oldPosition;
            Vector3 vel = med / Time.deltaTime;
            oldPosition = newPosition;
            transform.localScale = new Vector2(Mathf.Sign(vel.x), 1f);
        }
        else
        {
            positionIndex = 0;
        }
        
        if(transform.position == nextPosition)
        {
            if(positionIndex == 0)
            {
               // transform.localScale = new Vector2(1f, 1f);
            }
            positionIndex++;
            if(positionIndex == positions.Count)
            {
                positionIndex = 0;
                //transform.localScale = new Vector2(-1f, 1f);
            }
        }
    }
}
