using UnityEngine;
using System.Collections;
using DefaultNamespace;

public class Ball : MonoBehaviour {
    public float speed = 30;
    public bool Starting { get;private set; }
    private Vector3 _startPos;
    public Player PlayerStart;

    void Start() {
        Starting = false;
        _startPos = transform.position;
    }

    public void Restart(Player player)
    {
        transform.SetPositionAndRotation(_startPos, Quaternion.identity);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Starting = false;
        PlayerStart = player;
    }

    public void SetStart(Player player)
    {
        if (player != this.PlayerStart) return;
        switch (player)
        {
            case Player.Player1:
                GetComponent<Rigidbody2D>().velocity = Vector2.left * -speed;
                break;
            case Player.Player2:
                GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
                break;
        }
        Starting = true;
    }
    
    public float hitFactor(Vector2 ballPos, Vector2 racketPos,
                    float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
    

    public void OnCollisionEnter2D(Collision2D col) {
        
        if (col.gameObject.name == "pongBarLeft") {
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);
            
            Vector2 dir = new Vector2(1, y).normalized;
            
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        
        if (col.gameObject.name == "pongBarRight") {
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);
            
            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        
    }
}
