using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private Vector3 _initialPosition = Vector3.zero; 
    [SerializeField] private Vector3 _direction = Vector3.right; 
    [SerializeField] private int _quantityObjects = 1;
    [SerializeField] private float _distanceBetweenObjects = 1f;
    private Vector3 _currentPosition;
    private List<GameObject> _objectList = new List<GameObject>();
    
    
    public void BuildObjects()
    {
        if (_objectList.Count > 0)
        {
            _objectList.ForEach(obj => DestroyImmediate(obj));
            _objectList.Clear();
        }

        if(_objectPrefab != null)
        {
            GameObject gameObj;
            _currentPosition = _initialPosition;
            Vector3 offset = _direction * _distanceBetweenObjects;
            
            for (int i = 0; i < _quantityObjects; i++)
            {
                gameObj = Instantiate(_objectPrefab, transform, true);
                gameObj.transform.localPosition = _currentPosition;
                _objectList.Add(gameObj);

                _currentPosition += offset;
            }            
        }
        else
        {
            Debug.LogWarning($"[{GetType()}.{nameof(BuildObjects)}] objectPrefab is missing!");
        }
    }
}