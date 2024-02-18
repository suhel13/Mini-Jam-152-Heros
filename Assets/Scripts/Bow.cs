using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;

public class Bow : Tools
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform arrowSpawnPoint;
    public void interact(Vector3 targetPos)
    {
        interact();
        Shoot(targetPos);
    }
    void Shoot(Vector3 targetPos)
    {
        Vector3 dir = (targetPos - arrowSpawnPoint.position).normalized;
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, transform.rotation);

        arrow.GetComponent<Arrow>().SetVelocity(targetPos);
        arrow.layer = LayerMask.NameToLayer("HeroArrows");
        arrow.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * 180 / Mathf.PI);
    }
}
