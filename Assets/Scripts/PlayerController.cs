using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    PlayerInput playerInput;
    CharacterController characterController;

    private Vector2 mousePosition;
    [SerializeField] private ParticleSystem ripples = default;

    // Start is called before the first frame update
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = new PlayerInput();
        playerInput.KeyboardMouse.LeftClick.performed += ctx => OnLeftClickPerformed();
        playerInput.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        mousePosition = playerInput.KeyboardMouse.Mouse.ReadValue<Vector2>();
        var projectedMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        Debug.Log($"mousePosition: {mousePosition.ToString()}\nprojectedPosition: {projectedMousePosition.ToString()}");
        LookCursor();
        Move();
    }

    private void LookCursor()
    {

    }

    private void Move()
    {

    }

    private void OnLeftClickPerformed()
    {
        Plane plane = new Plane(Vector3.zero, Vector3.up);
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        float enter = 0.0f;
        if (plane.Raycast(ray, out enter))
        {
            //Get the point that is clicked
            Vector3 hitPoint = ray.GetPoint(enter);
            Instantiate(ripples, hitPoint, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Raycast unsuccessful");
        }
    }
}
