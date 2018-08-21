using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Action = DefaultNamespace.Action;

public class PongBar : MonoBehaviour, IPlayable
{

    public Transform Controller;
    public float Speed;
    public Collider2D TopWall;
    public Collider2D BottomWall;
    public Ball ball;
    public Player player;

    private BoxCollider2D _boxCollider;
    private BoxCollider2D _attack;

	// Use this for initialization
	void Start () {
		Controller.GetComponent<IController>().AddPlayable(this);
	    _boxCollider = GetComponent<BoxCollider2D>();
        _attack = GetComponentInChildren<BoxCollider2D>();
	}

    public void DoAction(Action action)
    {
        switch (action)
        {
            case Action.Attack:
                if (!ball.Starting)
                {
                    ball.SetStart(player);
                    break;
                }
                if (_attack.IsTouching(ball.GetComponent<BoxCollider2D>())){
                    ball.IncreaseSpeed();
                }
                break;
            case Action.Up:
                if (!_boxCollider.IsTouching(TopWall))
                {
                    transform.Translate(new Vector3(0, Speed));
                }
                break;
            case Action.Down:
                if (!_boxCollider.IsTouching(BottomWall))
                {
                    transform.Translate(new Vector3(0, -Speed));
                }

                break;
        }
    }
}
