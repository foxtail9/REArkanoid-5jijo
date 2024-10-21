using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScore : MonoBehaviour
{
    private float _time = 1.0f;

    private void Start()
    {

    }

    void Update()
    {
        _time -= Time.deltaTime;
        if (_time <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

}
