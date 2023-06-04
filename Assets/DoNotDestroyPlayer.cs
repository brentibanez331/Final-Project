using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
