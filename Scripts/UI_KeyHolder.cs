using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeyHolder : MonoBehaviour
{
    [SerializeField] private KeyHolder keyHolder;
    private Transform container;
    private Transform keyTemplate;

    private void Awake()
    {
        container = transform.Find("Container");
        keyTemplate = container.Find("keyTemplate");
        keyTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        keyHolder.OnKeysChanged += KeyHolder_OnKeysChanged;
    }

    private void KeyHolder_OnKeysChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        //Clean old keys
        foreach (Transform child in container)
        {
            if (child == keyTemplate) continue;
            Destroy(child.gameObject);
        }

        //Instantiate current key list
        List<Keys.KeyType> keyList = keyHolder.GetKeyList();
        for(int i = 0; i < keyList.Count; i++)
        {
            Keys.KeyType keyType = keyList[i];
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * i, 0);

            Image keyImage = keyTransform.Find("Image").GetComponent<Image>();

            switch (keyType)
            {
                default:
                case Keys.KeyType.Red:      keyImage.color = Color.red;    break;
                case Keys.KeyType.Green:    keyImage.color = Color.green;  break;
                case Keys.KeyType.Blue:     keyImage.color = Color.blue;   break;
            }
        }
    }
}
