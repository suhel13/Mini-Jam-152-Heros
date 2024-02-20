using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIBow : MonoBehaviour, IDeathAble
{
    [SerializeField] float cooldownDuration;
    float cooldownTimer;

    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform arrowSpawnPoint;

    public void Death()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (cooldownTimer < cooldownDuration/ CooldownMod())
        {
            cooldownTimer += Time.deltaTime;
        }
        else
        {
            Shoot();
        }
    }
    float CooldownMod()
    { return GameManager.instance.cameraMovement.cameraSpeed *0.25f + 0.5f; }

    void Shoot()
    {
        if (transform.eulerAngles.y == 0)
        {
            Instantiate(arrowPrefab, arrowSpawnPoint.position, transform.rotation).GetComponent<Arrow>().SetVelocity(arrowSpawnPoint.position + Vector3.right);
        }
        else
        {
            Instantiate(arrowPrefab, arrowSpawnPoint.position, transform.rotation).GetComponent<Arrow>().SetVelocity(arrowSpawnPoint.position + Vector3.left);
        }
            cooldownTimer = 0;
    }
}