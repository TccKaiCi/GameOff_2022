using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

namespace KaiCi
{
    [System.Serializable]
    public struct WayPoint
    {
        public Transform transform;
        public float waitTime;
        public Direction direction;
        public float moveSpeed;
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Patrol : MonoBehaviour
    {
        // public Animator _animator;
        public PatrolSettings patrolSettings;
        public GameObject patrolGroup;

        [Foldout("DATA OBJECT", true)] public WayPoint[] listWaypoint;
        [Foldout("DATA OBJECT", true)] public GameObject flashlight;
        [Foldout("DATA OBJECT", true)] public int _currentWaypointIndex = 0;

        private float _waitCounter = 0f;
        private bool _waiting = false;

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            flashlight = transform.GetChild(0).gameObject;
            ChangeDirection();
        }


        [ButtonMethod]
        private void Init()
        {
            listWaypoint = new WayPoint[patrolSettings.wayPointLength];
            for (int i = 0; i < listWaypoint.Length; i++)
            {
                listWaypoint[i] = new WayPoint();

                listWaypoint[i].transform = patrolGroup.transform.GetChild(patrolSettings.wayPoint[i].childPositionInParent);
                listWaypoint[i].waitTime = patrolSettings.wayPoint[i].wayPoint.waitTime;
                listWaypoint[i].direction = patrolSettings.wayPoint[i].wayPoint.direction;
                listWaypoint[i].moveSpeed = patrolSettings.wayPoint[i].wayPoint.moveSpeed;
            }
        }

        private void FixedUpdate()
        {
            if (listWaypoint.Length > 0)
            {
                if (_waiting)
                {
                    _waitCounter += Time.deltaTime;
                    if (_waitCounter < listWaypoint[Mathf.Clamp(_currentWaypointIndex - 1, 0, listWaypoint.Length)].waitTime)
                        return;
                    _waiting = false;

                    ChangeDirection();
                    // _animator.SetBool("IsRun", true);
                }

                Transform wp = listWaypoint[_currentWaypointIndex].transform;
                if (Vector3.Distance(transform.position, wp.position) < 0.01f)
                {
                    transform.position = wp.position;
                    _waitCounter = 0f;
                    _waiting = true;

                    _currentWaypointIndex = (_currentWaypointIndex + 1) % listWaypoint.Length;

                    // _animator.SetBool("IsRun", false);

                }
                else
                {
                    MoveToPosition(wp);
                }
            }
        }

        private void MoveToPosition(Transform point)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                point.position,
                listWaypoint[_currentWaypointIndex].moveSpeed * Time.deltaTime
            );
        }

        private void ChangeDirection()
        {
            switch (listWaypoint[_currentWaypointIndex].direction)
            {
                case Direction.Up:
                    ChangeFlashLightRotation(0, 0, 0);
                    break;
                case Direction.Down:
                    ChangeFlashLightRotation(0, 0, 180);
                    break;
                case Direction.Left:
                    ChangeFlashLightRotation(0, 0, 90);
                    break;
                case Direction.Right:
                    ChangeFlashLightRotation(0, 0, 270);
                    break;
            }
        }

        private void ChangeFlashLightRotation(float x, float y, float z)
        {

            flashlight.transform.rotation = Quaternion.Euler(x, y, z);
        }
    }
}