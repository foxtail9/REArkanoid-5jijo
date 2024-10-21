using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickScore : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Start()
    {
        Destroy(this.gameObject, 1.0f);
    }

    private void Update()
    {
        this.transform.position += new Vector3(0, 10f, 0) * Time.deltaTime;
    }

    public void SetScore(int score)
    {
        _text.text = $"+ {score}";
    }

}
