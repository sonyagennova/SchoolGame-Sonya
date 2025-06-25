using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkeletonChase : MonoBehaviour
{
    public float chaseDistance = 10f;     // Start chasing if player is near
    public float stopChance = 0.01f;      // Random chance to stop
    public float moveSpeed = 2f;          // Slower than player
    public float resumeDelay = 2f;        // Time to wait before chasing again

    private Transform player;
    private Animator animator;
    private bool isChasing = true;
    private float stopTimer = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // Handle stopping
        if (!isChasing)
        {
            stopTimer -= Time.deltaTime;
            if (stopTimer <= 0 && distance < chaseDistance)
            {
                isChasing = true;
            }
            animator.SetBool("isWalking", false);
            return;
        }

        // Randomly decide to stop
        if (Random.value < stopChance)
        {
            isChasing = false;
            stopTimer = resumeDelay;
            animator.SetBool("isWalking", false);
            return;
        }

        // Only chase if close enough
        if (distance < chaseDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Face the player
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
