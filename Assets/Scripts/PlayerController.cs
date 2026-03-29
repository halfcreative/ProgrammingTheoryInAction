using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Vector3 targetPosition;
    private Animal targetAnimal;
    private Transform targetTransform; // To follow a moving target
    private bool isMoving = false;
    private const float yPosition = 1f;
    private const float stopDistance = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set initial position
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // If we are following a target, check the distance first
            if (targetAnimal != null)
            {
                if (Vector3.Distance(transform.position, targetAnimal.transform.position) <= stopDistance)
                {
                    isMoving = false;
                    Feed(targetAnimal);
                    targetAnimal = null;
                    return; // Stop processing movement for this frame
                }
                // If not close enough, update the target position
                targetPosition = new Vector3(targetAnimal.transform.position.x, yPosition, targetAnimal.transform.position.z);
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Stop moving if we've reached the destination (for stationary targets)
            if (transform.position == targetPosition && targetAnimal == null)
            {
                isMoving = false;
            }
        }
    }

    // Move to a static point
    public void MoveTo(Vector3 destination)
    {
        targetAnimal = null; // Clear the animal target
        targetPosition = new Vector3(destination.x, yPosition, destination.z);
        isMoving = true;
    }

    // Move to and follow an animal
    public void MoveTo(Animal animal)
    {
        targetAnimal = animal;
        isMoving = true;
    }

    private void Feed(Animal animal)
    {
        // Implement feeding logic here
        Debug.Log("Feeding " + animal.name);
        animal.Eat();
    }
}
