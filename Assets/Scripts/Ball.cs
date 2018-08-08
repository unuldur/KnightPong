using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float speed = 30;

    void Start() {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
    }
    
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                    float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col) {
        
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
