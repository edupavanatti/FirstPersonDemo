using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

    [SerializeField] private CharacterController playerController;

    private float _playerSpeed = 10f;

    private void Update()
    {
        var inputX = Input.GetAxis(HorizontalInput);
        var inputZ = Input.GetAxis(VerticalInput);

        var movement = transform.right * inputX + transform.forward * inputZ;
        playerController.Move(movement * _playerSpeed * Time.deltaTime);
    }
}
