using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public GameObject characterPrefab;
    public Vector3 savedPosition;
    // Diğer karakter özelliklerini buraya ekleyebilirsiniz
}

public class CharacterSwitcher : MonoBehaviour
{
    public CharacterData[] characters;
    public CharacterController myCharacterController; // CharacterController scriptine referans

    private int activeCharacterIndex = 0;

    private void Start()
    {
        // İlk karakteri etkinleştir
        ActivateCharacter(activeCharacterIndex);
    }

    private void Update()
    {
        // Karakter değiştirme kontrolleri
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchToPreviousCharacter();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchToNextCharacter();
        }
    }

    private void SwitchToPreviousCharacter()
    {
        // Etkin karakterin pozisyonunu kaydet
        SaveCharacterPosition(activeCharacterIndex);

        // Etkin karakterin indeksini azalt
        activeCharacterIndex--;
        if (activeCharacterIndex < 0)
        {
            activeCharacterIndex = characters.Length - 1;
        }

        // Etkin karakteri değiştir
        ActivateCharacter(activeCharacterIndex);
    }

    private void SwitchToNextCharacter()
    {
        // Etkin karakterin pozisyonunu kaydet
        SaveCharacterPosition(activeCharacterIndex);

        // Etkin karakterin indeksini artır
        activeCharacterIndex++;
        if (activeCharacterIndex >= characters.Length)
        {
            activeCharacterIndex = 0;
        }

        // Etkin karakteri değiştir
        ActivateCharacter(activeCharacterIndex);
    }

    private void ActivateCharacter(int index)
    {
        // Etkin karakterin pozisyonunu kaydetme
        SaveCharacterPosition(activeCharacterIndex);

        // Tüm karakterleri devre dışı bırak
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].characterPrefab.SetActive(false);
        }

        // Seçilen karakteri etkinleştir
        characters[index].characterPrefab.SetActive(true);

        // Kaydedilen pozisyona yerleş
        characters[index].characterPrefab.transform.position = characters[index].savedPosition;

        // Karakteri CharacterController scriptine bildirme
        MyCharacterController.SetCharacterPosition(characters[index].savedPosition);
    }


    private void SaveCharacterPosition(int index)
    {
        // Etkin karakterin pozisyonunu kaydet
        characters[index].savedPosition = characters[index].characterPrefab.transform.position;
    }
}
