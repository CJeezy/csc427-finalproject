using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public event EventHandler OnKeysChanged;
    private List<Keys.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<Keys.KeyType>();
    }

    

    public List<Keys.KeyType> GetKeyList()
    {
        return keyList;
    }

    public void AddKey(Keys.KeyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(Keys.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }
    public bool ContainsKey(Keys.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter(Collider other)
    {
        Keys key = other.GetComponent<Keys>();

        if (other.tag.Equals("Key"))
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
            AudioManager.Instance.PlaySoundEffect(0); //Play key sound effect
            //FindObjectOfType<AudioManager>().Play("KeyPickUp");
            
        }

        KeyDoor keyDoor = other.GetComponent<KeyDoor>();

        if (ContainsKey(keyDoor.GetKeyType()))
        {
            //checks if held key is key to that specific door
            RemoveKey(keyDoor.GetKeyType());
            keyDoor.OpenDoor();
        }
    }

}
