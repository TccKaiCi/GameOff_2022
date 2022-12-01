using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace KaiCi
{

    public class CameraMoveByMove : MonoBehaviour
    {
        public static CameraMoveByMove instance;

        public float sensitivity = 0.5f;
        public float maxXAngle = 10f;
        public float maxYAngle = 10f;
        public Vector2 currentPosition;

        public Rigidbody2D rigidbody2D;
        public GameObject playerPosition;

        public bool isMoveViewable = false;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            currentPosition = playerPosition.transform.position;
        }

        void Update()
        {
            currentPosition.x += Input.GetAxis("Mouse X") * sensitivity;
            currentPosition.y += Input.GetAxis("Mouse Y") * sensitivity;

            currentPosition.x = Mathf.Clamp(currentPosition.x, -maxXAngle + playerPosition.transform.position.x, maxXAngle + playerPosition.transform.position.x);
            currentPosition.y = Mathf.Clamp(currentPosition.y, -maxYAngle + playerPosition.transform.position.y, maxYAngle + playerPosition.transform.position.y);

            Cursor.lockState = isMoveViewable ? CursorLockMode.Confined : CursorLockMode.Locked;
        }

        private void FixedUpdate()
        {
            rigidbody2D.MovePosition(currentPosition);
        }

        public void MoveToPoint(Vector3 point)
        {
            transform.DOMove(point, 0.5f).OnComplete(() => { currentPosition = point; });
        }

        // Vector3 mousePosition;
        // public float moveSpeed = 0.1f;
        // public Rigidbody2D rigidbody2D;
        // Vector2 position = Vector2.zero;

        // private void Update()
        // {
        //     mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //     position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        // }
    }
}