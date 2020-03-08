using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour
{
    public float rotateSpeed = 10.0f;
    public float zoomSpeed = 10.0f;
    public float panSpeed = 10.0f;

    private Camera mainCamera;

    void Start() {
        mainCamera = GetComponent<Camera>();
    }

    void Update() {
        Move();
        Zoom();
        //Rotate();
    }

    private void Zoom() {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            if (mainCamera.orthographic)
            {
                mainCamera.orthographicSize += distance;
                mainCamera.orthographicSize = Mathf.Max(1, mainCamera.orthographicSize);
                mainCamera.orthographicSize = Mathf.Min(10, mainCamera.orthographicSize);
            }
            else
            {
                mainCamera.fieldOfView += distance;
            }
        }
    }

    private void Rotate() {
        if (Input.GetMouseButton(1))
        {
            Vector3 rot = transform.rotation.eulerAngles; // 현재 카메라의 각도를 Vector3로 반환
            rot.y += Input.GetAxis("Mouse X") * rotateSpeed; // 마우스 X 위치 * 회전 스피드
            rot.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed; // 마우스 Y 위치 * 회전 스피드
            Quaternion q = Quaternion.Euler(rot); // Quaternion으로 변환
            q.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f); // 자연스럽게 회전
        }
    }

    private void Move() {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButton(1))
            {
                Vector3 position = transform.position; // 현재 카메라의 각도를 Vector3로 반환
                position.x -= Input.GetAxis("Mouse X") * panSpeed; // 마우스 X 위치 * 회전 스피드
                position.y += -1 * Input.GetAxis("Mouse Y") * panSpeed; // 마우스 Y 위치 * 회전 스피드
                                                                                         //Quaternion q = Quaternion.Euler(position); // Quaternion으로 변환
                                                                                         //q.z = 0;
                                                                                         //transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f); // 자연스럽게 회전
                transform.position = position;
            }
        }
    }
}