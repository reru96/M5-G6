using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<ItemSO> items = new List<ItemSO>();
    [SerializeField] private float delay = 3f;
    public TeleportRingUI countDown;
    private bool isCounting = false;
    private static PlayerInventory instance;
    private static bool _isApplicationQuitting = false;

    public static PlayerInventory Instance
    {
        get
        {
            if (_isApplicationQuitting) return null;
            CreateOrGetInstance();
            return instance;
        }
    }

    static void CreateOrGetInstance()
    {
        if (instance == null)
        {
            instance = FindAnyObjectByType<PlayerInventory>();
            if (instance == null)
            {
                GameObject newObject = new GameObject("Inventario");
                newObject.AddComponent<PlayerInventory>();
                instance = newObject.GetComponent<PlayerInventory>();
                DontDestroyOnLoad(newObject);
            }
        }
    }
    protected PlayerInventory()
    {

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        _isApplicationQuitting = true;
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha3) && !isCounting)
        {
            if (items.Count > 0)
            {
                StartCoroutine(StartCountdownOnce(items[0].Id));
            }
        }

    }
    IEnumerator StartCountdownOnce(int id)
    {
        isCounting = true;


        yield return StartCoroutine(countDown.Countdown(delay, () => UseItemById(id)));

        isCounting = false;
    }

    public void AddItem(ItemSO item)
    {
        items.Add(item);
        Debug.Log($"Item con ID {item.Id} aggiunto all'inventario.");
    }


    public void UseItemById(int id)
    {
        ItemSO item = items.Find(i => i.Id == id);
        if (item != null)
        {
            item.Use(gameObject);
            items.Remove(item);
            Debug.Log($"Item con ID {id} usato e rimosso.");
        }
    }
}
