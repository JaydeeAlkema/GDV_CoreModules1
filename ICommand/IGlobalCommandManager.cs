using System.Collections.Generic;
using UnityEngine;

public static class IGlobalCommandManager
{
	private static List<ICommand> commands = new List<ICommand>();
	private static int commandIndex = 0;

	public static void AddCommand(ICommand command)
	{
		commands.Add(command);
		commandIndex = commands.Count;
	}

	public static void RemoveCommand(ICommand command)
	{
		commands.Remove(command);
		commandIndex = commands.Count;
	}

	public static void UndoCommand()
	{
		commandIndex = Mathf.Max(0, commandIndex - 1);
		commands[commandIndex]?.Undo();
	}

	public static void RedoCommand()
	{
		if(commandIndex < commands.Count)
		{
			commands[commandIndex].Execute();
			commandIndex = Mathf.Min(commands.Count, commandIndex + 1);
		}
	}

	public static void PrintCommandsList()
	{
		for(int i = 0; i < commands.Count; i++)
		{
			Debug.Log("Command: " + commands[i]);
		}
	}
}
