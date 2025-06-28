using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	[SerializeField] private Player player_ = null;
	[SerializeField] private Enemy Enemy = null;

    void Update()
    {
		if (Enemy.playerbool == false) { return; }
		var target = (player_.transform.position - transform.position).normalized;
		Vector3 vector = (target * 0.2f);
		transform.position += vector;		
    }
}
