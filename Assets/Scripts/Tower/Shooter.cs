using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Camera mainCam;
    public GameObject projectile;
    public Transform shootFrom;
    public bool auto_shoot = true;
    public GameObject target;
    /// <summary>
    /// The rate at which a projectile is fired.
    /// </summary>
    public float FireRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Maybe better to use InvokeRepeating() - edited by Xiubo
        //InvokeRepeating("Shoot", FireRate, FireRate);
        Invoke("Shoot", FireRate);
        shootFrom = shootFrom ?? gameObject.transform;
    }

    public void Shoot()
    {
        if(auto_shoot)
        {
            var launched = Instantiate(projectile);
            if(mainCam != null)
            {
                launched.transform.position = mainCam.transform.position;
                launched.transform.rotation = mainCam.transform.rotation;
            }
            else
            {
                launched.transform.position = shootFrom.position;
                launched.transform.rotation = shootFrom.rotation;
            }
            
            launched.SetActive(true);
            Invoke("Shoot", FireRate);
        }
        else
        {
            var launched = Instantiate(projectile);
            launched.GetComponent<ProjectileMovement>().target = this.target;
            launched.transform.position = shootFrom.position;
            launched.transform.rotation = shootFrom.rotation;
            launched.SetActive(true);
        }
    }

    public void StopShooting()
    {
        this.enabled = false;
        CancelInvoke();
    }
}
