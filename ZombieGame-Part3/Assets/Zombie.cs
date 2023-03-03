using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform _player;
    private NavMeshAgent _nma;

    // Start is called before the first frame update
    void Start()
    {

        _nma = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _nma.destination = _player.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //the moment the zombie touches the player
        Player p = collision.transform.GetComponent<Player>();

        if (p)
            p.Damage(-collision.GetContact(0).normal);
    }
}
