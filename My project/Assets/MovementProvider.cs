using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class MovementProvider : LocomotionProvider
{
    
    public float speed = 1.5f;
    public float gravityMultiplier = 1.0f;
    public List<XRController> controllers = null;
    private CharacterController characterController = null;
    private GameObject head = null;
    
    protected override void Awake()
    {
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        PositionController();
    }

    private void PositionController()
    {
        // Get the head in the local, playspace ground to fit different heights of viewpoints to the scene
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2); // Height betweeen 1-2m
        characterController.height = headHeight;
        // Cut in half, add skin
        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2;
        newCenter.y += characterController.skinWidth;
        // Move the capsule in local space as well
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;
        // Apply to characterController
        characterController.center = newCenter;
        Debug.Log("Time: " + Time.time + "Head height: " + headHeight);
    }
    // Update is called once per frame
    void Update()
    {
       PositionController();
        CheckForInput();
        ApplyGravity(); 
    }

    private void CheckForInput()
    {
        foreach (XRController controller in controllers)
        {
            if (controller.enableInputActions)
            {

            
                CheckForMovement(controller.inputDevice);
            }
        }
    }

    private void CheckForMovement(InputDevice device)
{
    if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
    {
        StartMove(position);
    }
}
private void StartMove (Vector2 position)
{
    // Apply the touch position to the head's forward vector
    Vector3 direction = new Vector3(position.x, 0, position.y);
    Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);
    // Rotate the input direction by the horizontal head rotation
    direction = Quaternion.Euler(headRotation) * direction;
    // Apply speed and move
    Vector3 movement = direction * speed;
    characterController.Move(movement * Time.deltaTime);
    }
    private void ApplyGravity()
    {
        Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier, 0);
        characterController.Move(gravity * Time.deltaTime);
    }
}
