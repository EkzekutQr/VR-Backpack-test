using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWithRaycast : MonoBehaviour, IUsingControllable
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] float raycastRange;

    [SerializeField] Camera playerCamera;

    bool isRaycastTrowing;

    private void Awake()
    {
        playerCamera = transform.GetComponentInChildren<Camera>();
    }
    public void Use()
    {
        isRaycastTrowing = true;
    }
    private void Update()
    {
        if (!isRaycastTrowing) return;

        TrowRaycast();

        isRaycastTrowing = false;
    }
    void TrowRaycast()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        RaycastHit hit;

        Physics.Raycast(ray, out hit, raycastRange, layerMask, QueryTriggerInteraction.Collide);

        if (!hit.transform.TryGetComponent<RespawningPlayersCube>(out RespawningPlayersCube respawningPlayersCube1))
            return;
        RespawningPlayersCube respawningPlayersCube = respawningPlayersCube1;
        TryRespawn(respawningPlayersCube);
    }
    void TryRespawn(RespawningPlayersCube respawningPlayersCube)
    {
        respawningPlayersCube.RespawnPlayer(gameObject);
    }
}
