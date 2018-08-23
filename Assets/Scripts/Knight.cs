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
    private Etat _etat;

    private int _position = 2;
    // Use this for initialization
    void Start () {
		Controller.GetComponent<IController>().AddPlayable(this);
	    _animator = GetComponent<Animator>();
        foreach(ExitState exit in _animator.GetBehaviours<ExitState>())
        {
            exit.knight = this;
        }
        _attack = GetComponentInChildren<Attack>();
        _currentPv = PvMax;
        _etat = Etat.None;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoAction(Action action)
    {
        if (_etat != Etat.None) return;
        switch (action)
        {
            case Action.Attack:
                _animator.SetTrigger("attack");
                _etat = Etat.Attack; ;
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
        _animator.SetTrigger("stun");
        _etat = Etat.Stun;
    }

    public void EverythingGood(Etat etat)
    {
        if(etat == _etat)
        {
            _etat = Etat.None;
        }

    }

    public void AttackDamage()
    {
        Debug.Log("Attack !!!!!!!!!!");
        _etat = Etat.Attack;
        if (_attack.Knight == null || _attack.Knight.player == player) return;
        if(_attack.Knight._position == _position && _attack.Knight._etat != Etat.Stun)
        {
            Debug.Log("Ahah meme position pas de dammage !!! ");
            DoStun();
            return;
        }
        _attack.Knight.DoDamage();
    }

    private void DoDamage()
    {
        _currentPv -= attackDamage;
        Debug.Log("Aie il me reste " + _currentPv + " pv");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,-1));
        life.ChangeLife(this, _currentPv);
    }
}
