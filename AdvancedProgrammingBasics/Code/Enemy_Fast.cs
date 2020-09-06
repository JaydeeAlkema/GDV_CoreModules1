using System.Collections;
using UnityEngine;

public class Enemy_Fast : ActorBase, IDamageable
{
	public override int Health { get; set; }
	public override Vector2Int pos { get; set; }

	private float moveInterval = 1f;
	private int moveIndex = 0;

	private void Start()
	{
		Health = 2;
		pos = new Vector2Int((int)transform.position.x, (int)transform.position.y);

		StartCoroutine(MoveOnInterval());
	}
	private void OnMouseDown()
	{
		TakeDamage();
	}

	private IEnumerator MoveOnInterval()
	{
		while(true)
		{
			yield return new WaitForSeconds(moveInterval);

			// Get random move index between 0 and 4.
			moveIndex = Random.Range(0, 3);

			Move();
		}
	}

	public override void Move()
	{
		switch(moveIndex)
		{
			case 0:
				pos = new Vector2Int(pos.x, pos.y + 1);
				break;

			case 1:
				pos = new Vector2Int(pos.x - 1, pos.y);
				break;

			case 2:
				pos = new Vector2Int(pos.x, pos.y - 1);
				break;

			case 3:
				pos = new Vector2Int(pos.x + 1, pos.y);
				break;

			default:
				break;
		}
		transform.position = (Vector2)pos;
	}

	public override void Attack()
	{
		// Attack player, maybe other enemies aswell?.
	}

	public void TakeDamage()
	{
		Health -= 1;
		if(Health <= 0) Destroy(this.gameObject);
	}
}
