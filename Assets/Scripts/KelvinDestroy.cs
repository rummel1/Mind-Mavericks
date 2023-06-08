using UnityEngine;


public class KelvinDestroy : MonoBehaviour
{
    // Yok etmek istediğimiz nesnelerin tag'i
    public string destroyableTag;
    private bool isActive = false;
    void Start()
    {
        if (gameObject.CompareTag("Kelvin"))
        {
            isActive = true;
        }
    }
    void Update()
    {
        if (!isActive) return;
        
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag(destroyableTag) && Input.GetMouseButtonDown(0))
            {
                Destroy(hit.collider.gameObject);
            }
        }

        }
    }

