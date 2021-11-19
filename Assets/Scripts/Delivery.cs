using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage) {
            spriteRenderer.color = hasPackageColor;

            Destroy(other.gameObject, destroyDelay);
            hasPackage = true;

            Debug.Log("Package pick up");
        }
        if(other.tag == "Customer" && hasPackage) {
            spriteRenderer.color = noPackageColor;

            hasPackage = false;
            
            Debug.Log("Package Delivery");
        }
    }
}
