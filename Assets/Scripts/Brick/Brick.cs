using System;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
    private int _armor;
    private int _score;
    private int _takepower;

    SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject brickScore;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {

    }

    private void Attacked()
    {
        if (this._armor > 3)
        {
            spriteRenderer.color = new Color(1f, 0f, 1f, 1f);
        }
        else if(this._armor > 2)
        {
            spriteRenderer.color = Color.green;
        }
        else if(this._armor > 1)
        {
            spriteRenderer.color = Color.yellow;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
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
            Attacked();

            if (this._armor <= 0)
            {
                GameManager.Instance.AddScore(this._score);

                GameManager.Instance.BrickDestroyed(transform.position); //GameManager에게 알림

                GameObject scoreText = Instantiate(brickScore, transform.position, Quaternion.identity);
                scoreText.transform.SetParent(GameObject.Find("Canvas").transform, false);
                Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
                scoreText.GetComponent<Transform>().position = screenPosition;
                scoreText.GetComponent<BrickScore>().SetScore(this._score);

                Destroy(this.gameObject);
            }
        }
    }

}
