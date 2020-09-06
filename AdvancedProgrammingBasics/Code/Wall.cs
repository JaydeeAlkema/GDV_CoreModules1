using UnityEngine;

public class Wall : MonoBehaviour, IDamageable
{
	private int health = 5;

	private void OnMouseDown()
	{
		TakeDamage();
	}

	public void TakeDamage()
	{
		health -= 1;
		if(health <= 0) Destroy(this.gameObject);
	}
}
