using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform explosionPos;
    [SerializeField] private Transform instantiatePos;
    [SerializeField] private Rigidbody yeetingCanon;
    [SerializeField] List<Animator> animators;
    [SerializeField] KeyCode keyToShootOn;
    [SerializeField] LayerMask hitableLayer;
    [SerializeField] Transform muzzlePosition;
    [SerializeField] List<ParticleSystem> impactVFXs;

    private float lastReload = float.MaxValue;
    private int currentVFXID = 0;
    public float damage;
    public float rateOfFirePerSecond;
    public float maxAccuracyMalus;
    public int maxSohtTakenIntoConsiderationForAccuracy = 50;
    private float currentAccuracy;
    private int currentBulletCount;
    private float lastShot = float.MinValue;
    int x;
    int y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        y = Camera.main.pixelHeight/2;
        x = Camera.main.pixelWidth/2;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(keyToShootOn) || Input.GetKey(keyToShootOn)) && Time.time - lastShot >= 1/rateOfFirePerSecond)
        {
            lastShot = Time.time;
            currentBulletCount++;
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && Time.time - lastReload >=2)
        {
            lastShot = Time.time+2;
            Reload();
        }
        
    }


    private void Reload() 
    {
        currentBulletCount = 0;
        foreach (var animator in animators) 
        {
            animator.SetTrigger("Reload");
        }
        Rigidbody tmpRB = Instantiate(yeetingCanon);
        
        tmpRB.gameObject.transform.position = instantiatePos.position;
        tmpRB.gameObject.transform.rotation = transform.rotation;
        //tmpRB.AddExplosionForce(50, explosionPos.position, 20,5,ForceMode.Impulse);
        tmpRB.AddForce((instantiatePos.position - explosionPos.position).normalized * Random.Range(100, 200));
        //Yeet gun
    }

    public void Shoot() 
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint(new Vector3(x,y,100))-muzzlePosition.position;
        Ray gunLine = new Ray(muzzlePosition.position, dir);
        if(Physics.Raycast(gunLine, out RaycastHit hitinfo, 30, hitableLayer)) 
        {

            impactVFXs[currentVFXID].transform.position = hitinfo.point;
            impactVFXs[currentVFXID].Play();
            currentVFXID++;
            if(currentVFXID >= impactVFXs.Count) 
            {
                currentVFXID = 0;
            }
            hitinfo.collider.GetComponent<IHitable>()?.TakeDamage(damage);
        }
    
    }
}
