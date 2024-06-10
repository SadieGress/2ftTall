// Sadie Gress, June 2024
// Camera Code for TwoFeetTall

using UnityEngine;

public class Camera : MonoBehaviour
{
    void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    float xRot = 0f;
    float yRot = 0f;
    Vector3 currentRotation;
    [SerializeField] float sensitivity = 800f;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }
        xRot += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        yRot += -Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        yRot = Mathf.Clamp(yRot, -70, 70);
        transform.localRotation = Quaternion.Euler(yRot, transform.localRotation.y, transform.localRotation.z); //camera moves up and down
        transform.parent.rotation = Quaternion.Euler(transform.parent.rotation.x, xRot, transform.parent.rotation.z); //body moves left and right
    }
}
