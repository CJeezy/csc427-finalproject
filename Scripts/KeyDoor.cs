using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Keys.KeyType keyType;

    public Keys.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
