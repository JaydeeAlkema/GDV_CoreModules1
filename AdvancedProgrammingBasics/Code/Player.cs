using UnityEngine;

public class Player : ActorBase
{
	public override int Health { get; set; }
	public override Vector2Int pos { get; set; }

	private void Start()
	{
		pos = new Vector2Int((int)transform.position.x, (int)transform.position.y);
	}

	private void Update()
	{
		Move();
	}

	public override void Move()
	{
		if(Input.GetKeyDown(KeyCode.W)) pos = new Vector2Int(pos.x, pos.y + 1);
		else if(Input.GetKeyDown(KeyCode.A)) pos = new Vector2Int(pos.x - 1, pos.y);
		else if(Input.GetKeyDown(KeyCode.S)) pos = new Vector2Int(pos.x, pos.y - 1);
		else if(Input.GetKeyDown(KeyCode.D)) pos = new Vector2Int(pos.x + 1, pos.y);

		transform.position = (Vector2)pos;
	}

	public override void Attack()
	{
		// do stuff.
	}
}
