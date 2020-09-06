using UnityEngine;
public abstract class ActorBase : MonoBehaviour
{
	public abstract int Health { get; set; }
	public abstract Vector2Int pos { get; set; }

	public abstract void Move();

	public abstract void Attack(); // Why make an Attack function if the Enemis die by clicking on them, and enemies can't attack the player?
}
