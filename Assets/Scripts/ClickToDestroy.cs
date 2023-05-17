using UnityEngine;


public class ClickToDestroy : MonoBehaviour
{
    // Yok etmek istediğimiz nesnelerin tag'i
    public string destroyableTag;
    private bool isActive = false;
    void Start()
    {
        if (gameObject.CompareTag("Player"))
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

