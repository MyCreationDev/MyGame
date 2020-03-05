﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Transform LookAt;

    private void Update()
    {
        LookAt = GlobalVariables.MainCamera;
        gameObject.transform.parent.gameObject.transform.LookAt(LookAt.position);
    }
}
