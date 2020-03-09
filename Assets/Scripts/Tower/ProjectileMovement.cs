using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    //Edited by Xiubo for the homing projectile
    public GameObject target;
    public bool isHoming = true;
    /// <summary>
    /// The speed at which the projectile flies.
    /// </summary>
    public float ProjectileVelocity = 1f;

    /// <summary>
    /// The maximum lifetime of this projectile.
    /// </summary>
    public float MaxLifetime = 15f;

    private float currentLifetime = 0f;
    private float step;
    public float CurrentLifetime
    {
        get => currentLifetime;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHoming)
        {
            step = ProjectileVelocity * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
        else
        {
            transform.Translate(0, 0, ProjectileVelocity * Time.deltaTime, Space.Self);
            currentLifetime += Time.deltaTime;
            if (currentLifetime >= MaxLifetime)
                Destroy(gameObject);
        }
        
    }
}
