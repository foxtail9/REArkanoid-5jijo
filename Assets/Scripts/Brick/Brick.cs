using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private int _armor;
    private int _score;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Debug.Log($"Current Armor: {this._armor}");
            this._armor--;
            if (this._armor <= 0)
            {
                GameManager.Instance.AddScore(this._score);
                Destroy(this.gameObject);
            }
        }
    }

}
