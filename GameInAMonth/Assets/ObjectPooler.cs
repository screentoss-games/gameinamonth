using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	public static ObjectPooler instance;
	public List<ObjectPoolItem> PoolItems;
	private Dictionary<string, ObjectPoolItem> poolMap = new Dictionary<string, ObjectPoolItem>();
	// Use this for initialization
	void Awake() {
		instance = this;
		foreach (ObjectPoolItem item in PoolItems) {
			poolMap.Add(item.GameObject.tag, item);
		}
	}

	public GameObject getPoolObject(string tag) {
		if (poolMap.ContainsKey(tag)) {
			return poolMap[tag].GetObject();
		}
		return null;
	}

	[System.Serializable]
	public class ObjectPoolItem {
		public GameObject GameObject;
		public int poolSize;
		public bool expand;
		public List<GameObject> pool;
		void init() {
			pool = new List<GameObject>();
			for (int i = 0; i < poolSize; i++) {
				GameObject poolObject = Instantiate(GameObject);
				poolObject.SetActive(false);
				pool.Add(poolObject);
			}
		}

		public GameObject GetObject() {
			foreach (GameObject pooledObject in pool) {
				if (!pooledObject.activeInHierarchy) {
					pooledObject.SetActive(true);
					return pooledObject;
				}
			}
			if (expand) {
				GameObject poolObject = Instantiate(GameObject);
				pool.Add(poolObject);
				return poolObject;
			}
			return null;
		}
	}
}