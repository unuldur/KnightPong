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
    public Life life;
    public int PvMax = 100;
    public int attackDamage = 10;


    private Animator _animator;
    private Attack _attack;
    private int _currentPv;

    private int _position = 2;
    // Use this for initialization
    void Start () {
		Controller.GetComponent<IController>().AddPlayable(this);
	    _animator = GetComponent<Animator>();
        _attack = GetComponentInChildren<Attack>();
        _currentPv = PvMax;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoAction(Action action)
    {
        switch (action)
        {
            case Action.Attack:
                _animator.SetTrigger("attack");
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

    public void AttackDamage()
    {
        Debug.Log("Attack !!!!!!!!!!");
        if (_attack.Knight == null || _attack.Knight.player == player) return;
        if(_attack.Knight._position == _position)
        {
            Debug.Log("Ahah meme position pas de dammage !!! ");
            return;
        }
        _attack.Knight.DoDamage();
    }

    private void DoDamage()
    {
        _currentPv -= attackDamage;
        Debug.Log("Aie il me reste " + _currentPv + " pv");
        life.ChangeLife(this, _currentPv);
    }
}
