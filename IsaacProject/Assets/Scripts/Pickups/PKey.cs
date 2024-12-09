using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PKey : PickUp
{
    protected override void OnDestroy()
    {
        Key++;
    }
}
