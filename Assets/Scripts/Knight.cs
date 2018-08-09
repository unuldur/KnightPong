using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Action = DefaultNamespace.Action;

public class Knight : MonoBehaviour, IPlayable
{

    public Transform Controller;
    public float Speed = 1f;
    public Player player;
    private Animator _animator;

    private int _position = 2;
    // Use this for initialization
    void Start () {
		Controller.GetComponent<IController>().AddPlayable(this);
	    _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoAction(Action action)
    {
        switch (action)
        {
            case Action.Attack:
                break;
            case Action.Up:
                if (_position < 3)
                {
                    _position++;
                }
                _animator.SetInteger("position", _position);
                break;
            case Action.Down:
                if (_position > 1)
                {
                    _position--;
                }
                _animator.SetInteger("position", _position);
                break;
            case Action.Left:
                transform.Translate(Vector3.left * Time.deltaTime * Speed);
                _animator.SetBool("walk", true);
                break;
            case Action.Right:
                transform.Translate(Vector3.right * Time.deltaTime * Speed);
                _animator.SetBool("walk", true);
                break;
            case Action.None:
                _animator.SetBool("walk", false);
                break;
            default:
                throw new ArgumentOutOfRangeException("action", action, null);
        }
    }

    public void DoStun()
    {

    }
}
