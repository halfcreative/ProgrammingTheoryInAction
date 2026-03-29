using UnityEngine;

public class UserController : MonoBehaviour
{
    private Camera mainCamera;
    private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            if (playerController == null) return;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Check if the clicked object has an Animal component
                Animal animal = hit.collider.GetComponent<Animal>();
                if (animal != null)
                {
                    // Move to and follow the animal
                    playerController.MoveTo(animal);
                }
                else
                {
                    // Move to the clicked point on the ground
                    playerController.MoveTo(hit.point);
                }
            }
        }
    }
}
