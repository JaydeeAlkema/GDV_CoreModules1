using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	private List<KeyCommand> keyCommands = new List<KeyCommand>();

	public void HandelInput()
	{
		foreach(var keyCommand in keyCommands)
		{
			if(Input.GetKeyDown(keyCommand.key))
			{
				keyCommand.command?.Execute();
				if(keyCommand.command != null) IGlobalCommandManager.AddCommand(keyCommand.command);
			}
		}
	}

	public void BindInputToCommand(KeyCode keyCode, ICommand command)
	{
		keyCommands.Add(new KeyCommand()
		{
			key = keyCode,
			command = command
		});
	}

	public void UnbindInput(KeyCode keyCode)
	{
		var items = keyCommands.FindAll(x => x.key == keyCode);
		items.ForEach(x => keyCommands.Remove(x));
	}
}
public class KeyCommand
{
	public KeyCode key;
	public ICommand command;
}
