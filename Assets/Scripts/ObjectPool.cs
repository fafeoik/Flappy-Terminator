using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected Transform Container;

    private List<T> _pool = new();

    protected IEnumerable<T> Pool => _pool;

    private void Awake()
    {
        _pool = new List<T>();
    }

    public virtual void Restart()
    {
        foreach (var item in _pool)
            item.gameObject.SetActive(false);
    }

    protected T GetObject(T prefab)
    {
        T result = _pool.FirstOrDefault(item => item.gameObject.activeSelf == false);

        if (result == null)
         {
            result = Instantiate(prefab, Container);
            result.gameObject.SetActive(false);
            _pool.Add(result);
        }

        return result;
    }

    protected T GetObject(List<T> prefab)
    {
        T result = _pool.FirstOrDefault(item => item.gameObject.activeSelf == false);

        if (result == null)
        {
            int index = Random.Range(0, prefab.Count);
            result = Instantiate(prefab[index], Container);
            result.gameObject.SetActive(false);
            _pool.Add(result);
        }

        return result;
    }
}
