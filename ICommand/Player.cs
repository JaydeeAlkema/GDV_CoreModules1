using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private InputHandler inputHandler = new InputHandler();

	private IJumpCommand jumpCommand;

	private void Start()
	{
		jumpCommand = new IJumpCommand();
		inputHandler.BindInputToCommand(KeyCode.Space, jumpCommand);
	}

	private void Update()
	{
		inputHandler.HandelInput();

		if(Input.GetKeyDown(KeyCode.U))
		{
			IGlobalCommandManager.UndoCommand();
		}
		if(Input.GetKeyDown(KeyCode.R))
		{
			IGlobalCommandManager.RedoCommand();
		}
		if(Input.GetKeyDown(KeyCode.P))
		{
			IGlobalCommandManager.PrintCommandsList();
		}
	}
}

public class IJumpCommand : ICommand
{
	public void Execute()
	{
		Debug.Log("I Jumped!");
	}
	public void Undo()
	{
		Debug.Log("I Undo my Jump!");
	}
}