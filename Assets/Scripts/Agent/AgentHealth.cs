using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private int count;
    public AudioSource explosion;
    public GameObject explosionParticle;
    private GameData data;
    
    void Start()
    {
        data = GameObject.Find("GameManager").GetComponent<GameData>();
        count = 0;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("Collision!");
        ProjectileMovement pm = collision.collider.GetComponentInParent<ProjectileMovement>();
        if (pm)
        {
            //this.enabled = false;
            //if (!explosion.isPlaying)
            //{
            //    explosion.Play();
            //}
            
            Destroy(pm.gameObject);
            Explode();
            Debug.Log("Destoryed!"+count);
        }

    }
    public int GetEnemyDestoriedCount
    {
        get { return count; }
    }

    public void Explode()
    {
        //Debug.Log("asdasdasdasdasd");
        GameObject go = Instantiate(explosionParticle) as GameObject;
        go.transform.position = transform.position;
        explosion.Play();
        foreach (var renderer in GetComponentsInChildren<MeshRenderer>())
        {
            renderer.enabled = false;
        }
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false;
        data.score++;
        Destroy(this.gameObject, 5f);
    }
}
