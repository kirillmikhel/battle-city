using System.Collections;
using UnityEngine;

namespace AI
{
	public class RandomStrategy : MonoBehaviour, IStrategy {
	
		public IEnumerator Run(Move move, Shooting shooting)
		{
			while (true)
			{
				shooting.Shoot();

				var random = Random.value;

				if (random < 0.15)
					move.Down();
				else if (random >= 0.15 && random < 0.3)
					move.Up();
				else if (random >= 0.3 && random < 0.45)
					move.Right();
				else if (random >= 0.45 && random < 0.6)
					move.Left();

				yield return new WaitForSeconds(1);
			}
		}
	}
}
