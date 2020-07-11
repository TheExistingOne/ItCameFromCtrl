using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IIsKillable
{
    [SerializeField] private EnemyClass enemyClass;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject hudPrefab;

    private int _currHealth;
    private bool _holdingKey;
    private float _speed;
    
    private GameObject _targetKey;

    private GameObject _hud;
    // private GameObject _player;

    public int CurrHealth
    {
        get => _currHealth;
    }

    public bool HoldingKey
    {
        get => _holdingKey;
    }
    
    void Start()
    {
        _hud = Instantiate(hudPrefab);
        _hud.transform.parent.SetParent(canvas.transform, false);

        GetComponent<SpriteRenderer>().sprite = enemyClass.sprite;
        _currHealth = enemyClass.health;
        _speed = enemyClass.speed;
        //_player = GameObject.FindWithTag("Player");

        GameObject[] keys = GameObject.FindGameObjectsWithTag("Key");
        _targetKey = keys[Random.Range(0, keys.Length - 1)];
    }

    void Update()
    {
        if (_currHealth <= 0)
        {
            Destroy(gameObject);
        }
        
        float step = _speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _targetKey.transform.position, step);
    }

    public void Damage(int damage)
    {
        _currHealth -= damage;
    }
}
