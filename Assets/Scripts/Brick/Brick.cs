using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private int _armor;
    private int _score;
    private int _takepower;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {

    }
    
    internal void Initialize(string brickColor)
    {
        if (brickColor == "red")
        {
            this._armor = 1;
            this._score = 3;
            spriteRenderer.color = Color.red;
        }
        else if (brickColor == "yellow")
        {
            this._armor = 2;
            this._score = 7;
            spriteRenderer.color = Color.yellow;
        }
        else if (brickColor == "green")
        {
            this._armor = 3;
            this._score = 12;
            spriteRenderer.color = Color.green;
        }
        else if (brickColor == "purple")
        {
            this._armor = 5;
            this._score = 20;
            spriteRenderer.color = new Color(1f, 0f, 1f, 1f);
        }
    }
    private void UpdateColor()
    {
        if (_armor == 1)
        {
            spriteRenderer.color = Color.red;
        }
        else if (_armor == 2)
        {
            spriteRenderer.color = Color.yellow;
        }
        else if (_armor == 3)
        {
            spriteRenderer.color = Color.green;
        }
        else if (_armor >= 4)
        {
            spriteRenderer.color = new Color(1f, 0f, 1f, 1f); // 보라색
        }
    }
    public void SyncPower()
    {
        _takepower = (int)GameManager.Instance.ballpower;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SyncPower();
        if (collision.gameObject.CompareTag("ball"))
        {
            Debug.Log($"Current Armor: {this._armor}");
            this._armor -= _takepower;

            UpdateColor();

            if (this._armor <= 0)
            {
                GameManager.Instance.AddScore(this._score);

                GameManager.Instance.BrickDestroyed(transform.position); //GameManager에게 알림

                Destroy(this.gameObject);
            }
        }
    }

}
