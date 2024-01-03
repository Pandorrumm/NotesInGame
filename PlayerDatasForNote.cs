using UnityEngine;

public class PlayerDatasForNote : MonoBehaviour
{
    [SerializeField] private GameObject target = null;
    [SerializeField] private Transform playerCamera = null;

    public GameObject Target()
    {
        return target;
    }

    public Transform PlayerCamera()
    {
        return playerCamera;
    }
}
