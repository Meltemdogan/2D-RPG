using System;
using UnityEngine;
using WayPoints;


namespace Enemy.FSM.Actions
{
    public class ActionPatrol : FSMAction
    {
        [Header("Config")]
        [SerializeField] private float speed;
        
        private WayPoint wayPoint;
        private int pointIndex = 0;
        private Vector3 nextPosition;
        private void Awake()
        {
            wayPoint = GetComponent<WayPoint>();
        }
        public override void Act()
        {
            FallowPath();
        }
        
        private void FallowPath()
        {
            transform.position = Vector3.MoveTowards(transform.position, GetCurrentPosition(), speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, GetCurrentPosition()) <=0.1f)
            {
                UpdateNextPosition();
            }
        }
        
        private void UpdateNextPosition()
        {
            pointIndex++;
            if (pointIndex> wayPoint.Points.Length - 1)
            {
                pointIndex = 0;
            }
        }
        
        private Vector3 GetCurrentPosition()
        {
            return wayPoint.GetPosition(pointIndex);
        }
    }
}