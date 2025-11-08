using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] KeyCode keyToShootOn;
    [SerializeField] LayerMask hitableLayer;
    [SerializeField] Transform muzzlePosition;
    [SerializeField] List<ParticleSystem> impactVFXs;
    private int currentVFXID = 0;
    public int damage;
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
            currentBulletCount++;
            Shoot();
        }
        
    }


    private void Reload() 
    {
        currentBulletCount = 0;
        //Yeet gun
    }

    public void Shoot() 
    {
        int lerpT = Mathf.Clamp(currentBulletCount, 0, maxSohtTakenIntoConsiderationForAccuracy)/currentBulletCount;
        currentAccuracy = Mathf.RoundToInt( Mathf.Lerp(maxAccuracyMalus,0, lerpT));
        int tmpX = x + Mathf.RoundToInt( Random.Range(-currentAccuracy, currentAccuracy + 1));
        int tmpY = y + Mathf.RoundToInt( Random.Range(-currentAccuracy, currentAccuracy + 1));
        Vector3 dir = Camera.main.ScreenToWorldPoint(new Vector3(tmpX,tmpY,100))-muzzlePosition.position;
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


    private void OnDrawGizmos()
    {


    }
}
