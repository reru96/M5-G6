using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Screen", menuName = "Data/Inventory Object", order = 1)]
public class TeleportRingSO : ItemSO
{
    [SerializeField] private float offsetY = 0.5f;
    public override void Use(GameObject user)
    {
        user.transform.position = new Vector3(0, offsetY, 0);
    }

}
