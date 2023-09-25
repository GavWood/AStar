using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class BWCameraController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The movement speed of the camera in m/s")]
    float cameraMovementSpeed = 10.0f;

    [SerializeField]
    [Tooltip("The camera rotation speed in m/s")]
    float cameraRotationSpeed = 10.0f;

    [Tooltip("Use this to switch between moving the mouse up to look down and vice versa")]
    [SerializeField]
    bool invertYAxis = true;

    private BWCustomControl movementActions;

    private Vector2 moveVector = Vector2.zero;
    private Vector2 deltaRotation = Vector2.zero;
    
    public Vector2 eulerAxis = Vector2.zero;

    private bool isSpeedUp = false;                     // has the user pressed shift to go faster?
    private bool isRotating = false;                    // has the user held RMB to enable rotation
    
    // Save the current position and rotation of the camera
    private void SaveCameraData()
    {
        EditorPrefs.SetFloat("CameraPosX", transform.position.x);
        EditorPrefs.SetFloat("CameraPosY", transform.position.y);
        EditorPrefs.SetFloat("CameraPosZ", transform.position.z);
        EditorPrefs.SetFloat("CameraRotX", eulerAxis.x);
        EditorPrefs.SetFloat("CameraRotY", eulerAxis.y);
    }

    // Load the camera's position and rotation if saved data exists
    private void LoadCameraData()
    {
        if (EditorPrefs.HasKey("CameraPosX") && EditorPrefs.HasKey("CameraPosY") &&
            EditorPrefs.HasKey("CameraPosZ") && EditorPrefs.HasKey("CameraRotX") &&
            EditorPrefs.HasKey("CameraRotY"))
        {
            Vector3 savedPosition = new Vector3(
                EditorPrefs.GetFloat("CameraPosX"),
                EditorPrefs.GetFloat("CameraPosY"),
                EditorPrefs.GetFloat("CameraPosZ")
            );

            Vector2 savedRotation = new Vector2(
                EditorPrefs.GetFloat("CameraRotX"),
                EditorPrefs.GetFloat("CameraRotY")
            );

            transform.position = savedPosition;
            eulerAxis = savedRotation;
            transform.rotation = Quaternion.Euler(eulerAxis.x, eulerAxis.y, 0);
        }
    }

    void Awake()
    {
        movementActions = new BWCustomControl();

        movementActions.User.Movement.performed += OnMovementPerformed;
        movementActions.User.Movement.canceled += OnMovementCancelled;
        
        movementActions.User.MovementSpeed.performed += OnMovementSpeedPerformed;
        movementActions.User.MovementSpeed.canceled += OnMovementSpeedCancelled;

        movementActions.User.Orientation.performed += OnOrientationPerformed;
        movementActions.User.Orientation.canceled += OnOrientationCancelled;

        movementActions.User.OrientationToggle.performed += OnOrientationTogglePerformed;
        movementActions.User.OrientationToggle.canceled += OnOrientationToggleCancelled;
    }

    void Start()
    {
        // Set the euler angles so we can set this up with any initial transform
        eulerAxis.x = transform.rotation.eulerAngles.x;
        eulerAxis.y = transform.rotation.eulerAngles.y;

        // Or just used the camera data
        LoadCameraData();
    }

    private void OnEnable()
    {
        movementActions.Enable();
    }

    private void OnDisable()
    {
        movementActions.Disable();
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext context)
    {
        moveVector = Vector2.zero;
    }

    private void OnMovementSpeedPerformed(InputAction.CallbackContext context)
    {
        float buttonValue = context.ReadValue<float>();
        isSpeedUp = buttonValue > 0f;
    }

    private void OnMovementSpeedCancelled(InputAction.CallbackContext context)
    {
        isSpeedUp = false;
    }

    private void OnOrientationPerformed(InputAction.CallbackContext context)
    {
        deltaRotation = context.ReadValue<Vector2>();
    }

    private void OnOrientationCancelled(InputAction.CallbackContext context)
    {
        deltaRotation = Vector2.zero;
    }

    private void OnOrientationTogglePerformed(InputAction.CallbackContext context)
    {
        float buttonValue = context.ReadValue<float>();
        isRotating = buttonValue > 0f;
    }

    private void OnOrientationToggleCancelled(InputAction.CallbackContext context)
    {
        isRotating = false;
    }

    private void Update()
    {
        // Set the speed using the ternary operator
        float useSpeed = isSpeedUp ? cameraMovementSpeed * 10.0f : cameraMovementSpeed;

        // Set the camera (this GameObject)'s position and rotation
        transform.position += transform.forward * moveVector.y * useSpeed * Time.deltaTime;
        transform.position += transform.right   * moveVector.x * useSpeed * Time.deltaTime;

        // Are we wanting to rotate, for example, hold right mouse button
        // this enables us to easily debug without rotating the view
        if (isRotating)
        {
            // Set the local rotation. These are the axis we are rotating around
            // rotating around a vertical axis gives you yaw
            // rotating around a horizontal axis gives you pitch
            // which is why yx are reversed
            if (invertYAxis)
            {
                eulerAxis.x += deltaRotation.y * cameraRotationSpeed * Time.deltaTime;
            }
            else
            {
                eulerAxis.x -= deltaRotation.y * cameraRotationSpeed * Time.deltaTime;
            }

            eulerAxis.y += deltaRotation.x * cameraRotationSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.Euler( eulerAxis.x, eulerAxis.y, 0);
    }

    private void OnDestroy()
    {
        // Save the current camera data
        SaveCameraData();
    }
}
