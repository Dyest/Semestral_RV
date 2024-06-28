using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private Image crosshair = null;
    [SerializeField] private Canvas interactCanvas = null; // Canvas para "clique E para interagir"
    [SerializeField] private Canvas acquiredCanvas = null; // Canvas para "item X adquirido"
    [SerializeField] private string itemName = "Item X";

    private bool isCrosshairActive;
    private bool doOnce;
    private const string interactableTag = "InteractiveObject";
    private bool canInteract = true;

    private void Update()
    {
        if (!canInteract) return;

        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    CrosshairChange(true);
                    interactCanvas.enabled = true; // Ativa o canvas de interação
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(interactKey))
                {
                    StartCoroutine(CollectItem(hit.collider.gameObject));
                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
                interactCanvas.enabled = false; // Desativa o canvas de interação
            }
        }
    }

    private IEnumerator CollectItem(GameObject item)
    {
        canInteract = false;
        interactCanvas.enabled = false; // Desativa o canvas de interação
        acquiredCanvas.enabled = true; // Ativa o canvas de item adquirido

        Text acquiredText = acquiredCanvas.GetComponentInChildren<Text>();
        if (acquiredText != null)
        {
            acquiredText.text = itemName + " adquirido";
        }

        // Desativa o item
        item.SetActive(false);

        // Espera 3 segundos
        yield return new WaitForSeconds(3);

        acquiredCanvas.enabled = false; // Desativa o canvas de item adquirido
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
