using UnityEngine;
/// <summary>
/// Auto load singleton from Resources/Singletons folder
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ResourceSingleton<T> : MonoBehaviour where T : ResourceSingleton<T>
{
	[SerializeField] bool isDontDestroyOnLoad = false;
	public bool IsDontDestroyOnLoad => isDontDestroyOnLoad;
	private static T instance;
	public static T Instance
	{

		get
		{

			if (instance == null)
			{
				string namePrefab = typeof(T).Name;

				var prefab = Resources.Load<T>("Singletons/" + namePrefab);
				var t = GameObject.Instantiate<T>(prefab);
				t.name = namePrefab + "(Singleton From Resource)";
				if (prefab.IsDontDestroyOnLoad)
				{
					GameObject.DontDestroyOnLoad(t.gameObject);
				}

				instance = t;
			}

			return instance;

		}
	}

	private void OnDestroy()
	{
		if (!isDontDestroyOnLoad)
		{
			if (instance)
			{
				instance = null;
			}
		}
	}
}