using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private MyDoorController raycastedDoor;
    private GameObject raycastedItem;

    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private Image crosshair = null;
    [SerializeField] private Canvas InteractCanvas = null; // Canvas para "interagir com a porta"
    [SerializeField] private Canvas itemCanvas = null;
    [SerializeField] private GameObject objectToActivate; // Canvas para "interagir com a chave" // Texto do Canvas para "interagir com a chave"

    private bool isCrosshairActive;
    private bool doOnce;
    private const string doorTag = "InteractiveObject";
    private const string itemTag = "Key";
    private bool canInteract = true;

    private void Update()
{
    if (!canInteract) return;

    RaycastHit hit;
    Vector3 fwd = transform.TransformDirection(Vector3.forward);

    int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

    if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
    {
        if (hit.collider.CompareTag(doorTag))
        {
            if (!doOnce)
            {
                raycastedDoor = hit.collider.gameObject.GetComponent<MyDoorController>();
                if (raycastedDoor != null)
                {
                    CrosshairChange(true);
                }
            }

            isCrosshairActive = true;
            doOnce = true;

            InteractCanvas.enabled = true; // Ativa o Canvas da porta
            itemCanvas.enabled = false; // Desativa o Canvas da chave

            if (Input.GetKeyDown(interactKey))
            {
                StartCoroutine(InteractWithDoor());
            }
        }
        else if (hit.collider.CompareTag(itemTag))
        {
            if (!doOnce)
            {
                raycastedItem = hit.collider.gameObject;
                if (raycastedItem != null)
                {
                    CrosshairChange(true);
                }
            }

            isCrosshairActive = true;
            doOnce = true;

            InteractCanvas.enabled = true; // Ativa o Canvas de interação
            itemCanvas.enabled = false; // Desativa o Canvas da chave

            if (Input.GetKeyDown(interactKey))
            {
                StartCoroutine(CollectItem());

                // Ativar o itemCanvas após a coleta
                itemCanvas.enabled = true;
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
            InteractCanvas.enabled = false; 
            itemCanvas.enabled = false; 
        }
    }
    else
    {
        if (isCrosshairActive)
        {
            CrosshairChange(false);
            doOnce = false;
        }
        InteractCanvas.enabled = false; 
        itemCanvas.enabled = false; 
    }
}

    private IEnumerator InteractWithDoor()
    {
        canInteract = false;
        raycastedDoor.PlayAnimation();
        yield return new WaitForSeconds(raycastedDoor.GetAnimationLength());
        canInteract = true;
    }

    private IEnumerator CollectItem()
{
    canInteract = false;

    if (raycastedItem != null)
    {
        raycastedItem.SetActive(false);
    }

    if (objectToActivate != null)
    {
        objectToActivate.SetActive(true);
    }

    yield return new WaitForSeconds(2f);
    itemCanvas.enabled = false;

    canInteract = true;
}


    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
}
