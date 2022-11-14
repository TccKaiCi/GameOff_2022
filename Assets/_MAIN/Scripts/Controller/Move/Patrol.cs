using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

namespace KaiCi
{
    public enum PatrolState
    {
        Patrol,

    }

    public class Patrol : MonoBehaviour
    {
        [MustBeAssigned][SerializeField] private Movement _movement;

        public Transform[] wayPoints;
        private int _currentWaypointIndex = 0;

        private void Reset()
        {
            _movement = GetComponent<Movement>();
        }

        private void Start()
        {
            ChangeState(PatrolState.Patrol);
        }

        private void ChangeState(PatrolState patrolState)
        {
            switch (patrolState)
            {
                case PatrolState.Patrol:
                    StartCoroutine(RunPatrol());
                    break;
            }
        }

        IEnumerator RunPatrol()
        {
            while (true)
            {
                var wp = wayPoints[_currentWaypointIndex];

                if (transform.position.x - wp.position.x < 0.2f)
                {
                    Debug.Log("Change way point");

                    transform.position = wp.position;

                    yield return new WaitForSeconds(2.0f);

                    _currentWaypointIndex = (_currentWaypointIndex + 1) % wayPoints.Length;
                }
                else
                {
                    _movement.Move(transform.position.x < wayPoints[_currentWaypointIndex].position.x);
                    yield return new WaitForSeconds(0.02f);
                }
            }
        }
    }
}