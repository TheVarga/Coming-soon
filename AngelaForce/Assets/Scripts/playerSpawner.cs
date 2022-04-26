using UnityEngine;

public class playerSpawner : MonoBehaviour
{

    private void Start()
    {
        Instantiate(CharacterManager.instance.currentCharacter.prefab, transform.position,
            Quaternion.identity);
    }

}
