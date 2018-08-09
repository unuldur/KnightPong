using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Action = DefaultNamespace.Action;

public class Controller : MonoBehaviour, IController
{

    private List<IPlayable> _playables = new List<IPlayable>();
    

    public KeyCode AttackKey;
    public KeyCode UpKey;
    public KeyCode DownKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyUp(UpKey))
	    {
            Notifie(Action.Up);
            return;
	    }
	    if (Input.GetKeyUp(DownKey))
	    {
	        Notifie(Action.Down);
            return;
	    }
	    if (Input.GetKeyUp(AttackKey))
	    {
	        Notifie(Action.Attack);
            return;
	    }
	    if (Input.GetKey(LeftKey))
	    {
	        Notifie(Action.Left);
            return;
	    }
	    if (Input.GetKey(RightKey))
	    {
	        Notifie(Action.Right);
            return;
	    }
        Notifie(Action.None);
    }

    void Notifie(Action action)
    {
        foreach (IPlayable playable in _playables)
        {
            playable.DoAction(action);
        }
    }
    

    public void AddPlayable(IPlayable playable)
    {
        _playables.Add(playable);
    }

    public void RemovePlayable(IPlayable playable)
    {
        _playables.Remove(playable);
    }
}
