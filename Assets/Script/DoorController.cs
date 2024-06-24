using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public GameObject triggerArea; // Reference to the trigger area GameObject

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger area");
            if (door != null)
            {
                door.SetActive(false); // Hide the door
                Debug.Log("Door hidden");
            }
            if (triggerArea != null)
            {
                triggerArea.SetActive(false); // Hide the trigger area
                Debug.Log("Trigger area hidden");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger area");
            if (door != null)
            {
                door.SetActive(true); // Show the door
                Debug.Log("Door shown");
            }
            if (triggerArea != null)
            {
                triggerArea.SetActive(true); // Show the trigger area
                Debug.Log("Trigger area shown");
            }
        }
    }
}
