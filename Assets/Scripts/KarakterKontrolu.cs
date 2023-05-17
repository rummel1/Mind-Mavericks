using UnityEngine;

public class KarakterKontrolu : MonoBehaviour
{
    public float hiz = 10.0f; // karakterin hızı
    public float ziplamaGucu = 5.0f; // karakterin zıplama gücü
    private Rigidbody rb;
    private bool yereTemas = true; // karakterin yere temas durumu
    private bool ziplamaYapildi = false; // zıplama yapıldı mı kontrolü
    private bool ikinciZiplamaYapildi = false;
    public float ikinciZiplamaGucu = 5.0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
        
        
            
        if (yereTemas && Input.GetKey(KeyCode.Space) && !ziplamaYapildi) // yere temas ve space tuşuna basıldığında ve zıplama yapılmadıysa
        {
            rb.AddForce(new Vector3(0.0f, ziplamaGucu, 0.0f), ForceMode.Impulse); // zıplama kuvveti uygula
            yereTemas = false; // yere temas durumunu değiştir
            ziplamaYapildi = true; // zıplama yapıldı mı kontrolünü değiştir
        }
        else if (!yereTemas && Input.GetKeyDown(KeyCode.Space) && !ikinciZiplamaYapildi) // havadayken space tuşuna basıldığında ve ikinci zıplama yapılmadıysa
        {
            rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z); // yatay hareketi koru
            rb.AddForce(new Vector3(0.0f, ikinciZiplamaGucu, 0.0f), ForceMode.Impulse); // ikinci zıplama kuvveti uygula
            ikinciZiplamaYapildi = true; // ikinci zıplama yapıldı mı kontrolünü değiştir
        }
            
        
        
        
        
        
        
        float yatayInput = Input.GetAxis("Horizontal"); // klavyeden yatay girdi al
        float dikeyInput = Input.GetAxis("Vertical"); // klavyeden dikey girdi al
        Vector3 hareket = new Vector3(yatayInput, 0.0f, dikeyInput); // karakterin hareket yönü
        rb.AddForce(hareket * hiz); // karakterin hareketini

        /*if (yereTemas && Input.GetKey(KeyCode.Space) && !ziplamaYapildi) // yere temas ve space tuşuna basıldığında ve zıplama yapılmadıysa
        {
            rb.AddForce(new Vector3(0.0f, ziplamaGucu, 0.0f), ForceMode.Impulse); // zıplama kuvveti uygula
            yereTemas = false; // yere temas durumunu değiştir
            ziplamaYapildi = true; // zıplama yapıldı mı kontrolünü değiştir
        }*/
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) // karakter zemine temas ettiğinde
        {
            yereTemas = true; // yere temas durumunu değiştir
            ziplamaYapildi = false;
            ikinciZiplamaYapildi = false; // zıplama yapıldı mı kontrolünü sıfırla
        }
        else if (other.gameObject.CompareTag("Obje")) // karakter zemine temas ettiğinde
        {
            yereTemas = true; // yere temas durumunu değiştir
            ziplamaYapildi = false;
            ikinciZiplamaYapildi = false;// zıplama yapıldı mı kontrolünü sıfırla
        }
    }
}