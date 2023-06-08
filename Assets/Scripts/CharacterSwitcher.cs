using UnityEngine;
public class CharacterSwitcher : MonoBehaviour
{
    public GameObject[] characters;
    private int activeCharacterIndex = 0;
    Newposition newPositionScript;
    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
    public GameObject Character4;
    public GameObject Character5;
    public GameObject Character6;
    
    

    private void Start()
    {
        // Tüm karakterleri devre dışı bırak
        DeactivateAllCharacters();

        // İlk karakteri etkinleştir
        ActivateCharacter(activeCharacterIndex);
        newPositionScript = FindObjectOfType<Newposition>();
    }

    private void Update()
    {
        // Karakter değiştirme kontrolleri
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Character1.transform.position = newPositionScript.changepoint.position;
            SwitchToCharacter(0);
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Character2.transform.position = newPositionScript.changepoint.position;
            SwitchToCharacter(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Character3.transform.position = newPositionScript.changepoint.position;
            SwitchToCharacter(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Character4.transform.position = newPositionScript.changepoint.position;
            SwitchToCharacter(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Character5.transform.position = newPositionScript.changepoint.position;
            SwitchToCharacter(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Character6.transform.position = newPositionScript.changepoint.position;
            SwitchToCharacter(5);
        }
    }

    private void SwitchToCharacter(int index)
    {
        // Etkin karakteri devre dışı bırak
        characters[activeCharacterIndex].SetActive(false);

        // Yeni karakteri etkinleştir
        ActivateCharacter(index);

        // Yeni karakteri etkin karakter olarak ayarla
        activeCharacterIndex = index;
        StartCoroutine(MyCharacterController.IncreaseGravityForDuration(0.3f));
    }

    private void ActivateCharacter(int index)
    {
        // Seçilen karakteri etkinleştir
        characters[index].SetActive(true);
    }

    private void DeactivateAllCharacters()
    {
        // Tüm karakterleri devre dışı bırak
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }
    }
}