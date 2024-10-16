using UnityEngine;

public class Brick : MonoBehaviour
{
    public string _color;
    private int _armor;
    private int _score;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (_color == "red")
        {
            this._armor = 1;
            this._score = 3;
            spriteRenderer.color = Color.red;
        }
        else if (_color == "yellow")
        {
            this._armor = 2;
            this._score = 7;
            spriteRenderer.color = Color.yellow;
        }
        else if (_color == "green")
        {
            this._armor = 1;
            this._score = 12;
            spriteRenderer.color = Color.green;
        }
        else if (_color == "purple")
        {
            this._armor = 1;
            this._score = 20;
            spriteRenderer.color = new Color(1f, 0f, 1f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            if (this._armor == 1)
            {
                GameManager.Instance.AddScore(this._score);
                Destroy(this.gameObject);
            }
            else
            {
                this._armor--;
            }
        }
    }
}
