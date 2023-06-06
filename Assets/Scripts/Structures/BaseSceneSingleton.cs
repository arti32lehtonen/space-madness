using UnityEngine;
using System.Collections;
using System.ComponentModel;

namespace SpaceMadness.Structures
{
	/// <summary>
	/// To use it create an inheritance class NewClass : BaseSceneSingleton<NewClass>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class BaseSceneSingleton<T> : MonoBehaviour where T : BaseSceneSingleton<T>
	{
		public static T Instance { get; private set; }
		[Header("Singleton Settings")]
		[SerializeField] protected bool destroyGameObject = false; 
		
		private void Awake()
		{
			// If there is an instance, and it's not me, delete myself.

			if (Instance != null && Instance != this)
			{
				if (destroyGameObject)
				{
					Destroy(gameObject);
				}
				else
				{
					Destroy(this);
				}
			}
			else
			{
				Instance = this as T;
			}
			
			OnAwake();
		}

		protected virtual void OnAwake()
		{
			
		}
	}
}