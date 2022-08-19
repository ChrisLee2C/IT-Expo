using UnityEngine;

public class FaceTarget : MonoBehaviour
{
    private CameraController cController;

    private void Awake()
    {
        cController = FindObjectOfType<CameraController>();
    }

    void OnTriggerEnter(Collider other)
    {
        cController.FreeMovement(false);
    }
}
