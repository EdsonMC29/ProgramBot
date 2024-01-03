using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour{
    public GameObject changeCounter;
    public GameObject projectileGenerator;
    public GameObject trajectoryGameManager;
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    [SerializeField]
    private float forceMultiplier = 10;

    private Rigidbody rb;

    private bool isShoot;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 forceInit = Input.mousePosition - mousePressDownPos;
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, forceInit.y)) * forceMultiplier;
        if (!isShoot)
        {
            DrawTrajectory.Instance.UpdateTrajectory(forceV, rb, transform.position);
        }
    }


    private void OnMouseUp()
    {
        DrawTrajectory.Instance.HideLine();
        Shoot();
    }

    void Shoot()
    {
        if(isShoot)    
            return;
        
        Vector3 forceInit = Input.mousePosition - mousePressDownPos;
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, forceInit.y)) * forceMultiplier;
        rb.AddForce(forceV);
        isShoot = true;
        Invoke("updateCounter", 2f);

        projectileGenerator.GetComponent<ProjectileGenerator>().CreateNewProjectileWithDelay();
        if(trajectoryGameManager.GetComponent<TrajectoryGameManager>().remainingProjectiles == 0){
            trajectoryGameManager.GetComponent<TrajectoryGameManager>().VerifyStateGameWithDelay();
        }

    }   

    void updateCounter (){
        changeCounter.GetComponent<ChangeCounter>().UpdateProjectileDisplay();
    }

}