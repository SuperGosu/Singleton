using UnityEngine;

public class LazySingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	public static T Instance
	{
		get
		{
			if (instance)
				return instance;
			instance = FindObjectOfType<T>();
			if (instance)
				return instance;

			instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
			return instance;
		}
	}

	private  void Awake()
	{
		if (instance && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			instance = this.GetComponent<T>();
			DontDestroyOnLoad(instance.gameObject);
			OnAwake();
		}
	}

	protected virtual void OnAwake()
	{

	}


}
