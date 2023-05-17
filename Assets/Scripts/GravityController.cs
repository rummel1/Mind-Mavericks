using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float jumpForce = 5f;
    
    private int _jumpCount;
    private bool _isActive;
    private string touchableTag = "Obje";
    
   

    void Start()
    {
        if (gameObject.CompareTag("Player1"))
        {
            _isActive = true;
        }
        
        Physics.gravity = new Vector3(0, -9.81f, 0);
     
    }

    void Update()
    {
        if (!_isActive) return;

        if (staticCollision.isGrounded)
        {
            _jumpCount = 0;
            staticCollision.isGrounded = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                Rigidbody hitRigidbody = hit.collider.GetComponent<Rigidbody>();
                if (hitRigidbody != null && hit.collider.CompareTag(touchableTag))
                {
                    _jumpCount++;
                    if (_jumpCount == 1)
                    {
                        // İlk zıplama
                        hitRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                        hitRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    }
                    else if (_jumpCount == 2)
                    {
                        // Havada asılı kalma
                        hitRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                        hitRigidbody.velocity = Vector3.zero;
                    }
                    else if (_jumpCount == 3)
                    {
                        hitRigidbody.constraints = RigidbodyConstraints.None;
                        hitRigidbody.velocity = Vector3.down * jumpForce;
                        _jumpCount = 0;
                    }
                }
            }
        }
    }

}
