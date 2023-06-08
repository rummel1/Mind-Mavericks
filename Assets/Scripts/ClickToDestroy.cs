using UnityEngine;
using Cinemachine;

public class ClickToDestroy : MonoBehaviour
{
    // Yok etmek istediğimiz nesnelerin tag'i
    public string destroyableTag;
    private bool isActive = false;
    private CinemachineBrain cinemachineBrain;

    void Start()
    {
        cinemachineBrain = FindObjectOfType<CinemachineBrain>();

        if (gameObject.CompareTag("Tesla"))
        {
            isActive = true;
        }
    }

    void Update()
    {
        if (!isActive) return;

        Vector3 mousePos = Input.mousePosition;
        Ray ray = cinemachineBrain.OutputCamera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag(destroyableTag) && Input.GetMouseButtonDown(0))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}