using System;
using UnityEngine;
using WayPoints;


namespace NPC
{
    public class NPCMovement : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float moveSpeed;
        
        private readonly int moveX = Animator.StringToHash("MoveX");
        private readonly int moveY = Animator.StringToHash("MoveY");
        
        private WayPoint wayPoint;
        private Animator animator;
        private Vector3 previousPosition;
        private int currentPointIndex;
        
        private void Awake()
        { 
            wayPoint = GetComponent<WayPoint>();
            animator = GetComponent<Animator>();
        }
        
        private void Update()
        {
            Vector3 nextPos = wayPoint.GetPosition(currentPointIndex);
            UpdateMoveValues(nextPos);
            transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, nextPos) <= 0.2f)
            {
                previousPosition = nextPos;
                currentPointIndex = (currentPointIndex + 1) % wayPoint.Points.Length;
            }
        }
        
        private void UpdateMoveValues(Vector3 nextPos)
        {
            Vector2 dir = Vector2.zero;
            if (previousPosition.x < nextPos.x) dir = new Vector2(1f, 0f);
            if (previousPosition.x > nextPos.x) dir = new Vector2(-1f, 0f); 
            if (previousPosition.y < nextPos.y) dir = new Vector2(0f, 1f);
            if (previousPosition.y > nextPos.y) dir = new Vector2(0f, -1f);
            animator.SetFloat(moveX, dir.x);
            animator.SetFloat(moveY, dir.y);
        }
    }
}