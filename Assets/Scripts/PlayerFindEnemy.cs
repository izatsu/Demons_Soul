using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFindEnemy : MonoBehaviour
{
	public Transform direction_attack;

	void Update()
	{
		FindClosestEnemy();

	}

	void FindClosestEnemy()
	{
		float distanceToClosestEnemy = Mathf.Infinity;
		Enemy closestEnemy = null;
		Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

		foreach (Enemy currentEnemy in allEnemies)
		{
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy)
			{
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}
		if (closestEnemy == null)
		{
			// nếu không có enemy nào còn lại, không làm gì cả
			return;

		}
		Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
		direction_attack = closestEnemy.transform;

	}
}
