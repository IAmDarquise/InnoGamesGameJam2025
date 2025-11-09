using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform rayCastOrigin;
    [SerializeField] private Transform explosionPos;
    [SerializeField] private Transform instantiatePos;
    [SerializeField] private Rigidbody yeetingCanon;
    [SerializeField] List<Animator> animators;
    [SerializeField] KeyCode keyToShootOn;
    [SerializeField] LayerMask hitableLayer;
    [SerializeField] Transform muzzlePosition;
    [SerializeField] List<ParticleSystem> impactVFXs;
    [SerializeField] ParticleSystem hitmarker;

    [SerializeField] UIController_Skanone _skanone;

    private float lastReload = float.MinValue;
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
    Ray currentRay;
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
            _skanone.DisplayAmmo(currentBulletCount);
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && Time.time - lastReload >=2)
        {
            lastReload = Time.time;
            lastShot = Time.time+0.25f; // estimated time for the reload duration
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
        _skanone.DisplayAmmo(currentBulletCount);
        
        tmpRB.gameObject.transform.position = instantiatePos.position;
        tmpRB.gameObject.transform.rotation = transform.rotation;
        //tmpRB.AddExplosionForce(50, explosionPos.position, 20,5,ForceMode.Impulse);
        tmpRB.AddForce((instantiatePos.position - explosionPos.position).normalized * Random.Range(100, 200));
        //Yeet gun
    }

    public void Shoot() 
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint(new Vector3(x,y,100))- Camera.main.ScreenToWorldPoint(new Vector3(x, y, 1));
        Ray gunLine = new Ray(rayCastOrigin.position, dir);
        currentRay = gunLine;

        AudioManager.instance.Play3DOneShot(FMOD_EventList.instance.laserpew, transform.position);

        if (Physics.Raycast(gunLine, out RaycastHit hitinfo, 30, hitableLayer)) 
        {

            impactVFXs[currentVFXID].transform.position = hitinfo.point;
            impactVFXs[currentVFXID].Play();
            currentVFXID++;
            if(currentVFXID >= impactVFXs.Count) 
            {
                currentVFXID = 0;
            }
            var hitable = hitinfo.collider.GetComponent<IHitable>();
            if (hitable != null) 
            {
                hitmarker.transform.position = hitinfo.point;
                hitmarker.Play();
                hitable.TakeDamage(damage);
            }
        }
    
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(currentRay);
    }
}
