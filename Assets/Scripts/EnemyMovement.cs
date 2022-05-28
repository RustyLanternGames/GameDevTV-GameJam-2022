using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] List<Transform> positions;
    [SerializeField] float enemyIdleTime = 3f;
    int positionIndex = 0;
    Vector3 nextPosition;
    Animator enemyAnimator;

    void Start()
    {
        transform.position = positions[positionIndex].position;
        enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {

        nextPosition = positions[positionIndex].position;

        if (positionIndex < positions.Count)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
            enemyAnimator.SetBool("isWalking", true);
        }
        else
        {
            positionIndex = 0;
        }
        
        if(transform.position == nextPosition)
        {
            if(positionIndex == 0)
            {
                transform.localScale = new Vector2(1f, 1f);
            }
            positionIndex++;
            if(positionIndex == positions.Count)
            {
                positionIndex = 0;
                transform.localScale = new Vector2(-1f, 1f);
            }
        }
    }
}
