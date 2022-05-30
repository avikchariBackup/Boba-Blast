using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;

public class CustomerKilled : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Health h = this.GetComponent<Health>();
        if (!h.Model.activeSelf) 
        {
            MMGameEvent.Trigger("Customer Killed");
        }
    }
}
