using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Fly : MonoBehaviour
{
    private Text UIText;

    private XRGrabInteractable grabInteractable;
    private Transform playerTransform;
    private float movementSpeed = 3f;
    public float proximityDistance = 0.5f;
    private bool isTriggerPressed = false;
    public pointManager pointManager;
    public hungerManager hungerManager;

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnSelectEnter);

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        UIText = GameObject.FindGameObjectWithTag("Points").GetComponent<Text>();
        Debug.Log(UIText.text);
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        isTriggerPressed = true;
        StartCoroutine(MoveTowardsPlayer());
    }

    IEnumerator MoveTowardsPlayer()
    {
        while (Vector3.Distance(transform.position, playerTransform.position) > proximityDistance || !isTriggerPressed)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, movementSpeed * Time.deltaTime);
            yield return null;
        }

        // Enable trigger collider for collision detection with the player
        Collider triggerCollider = gameObject.AddComponent<SphereCollider>();
        triggerCollider.isTrigger = true;
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pointManager.addPoints(1);
            UIText.text = pointManager.getPoints().ToString();
            hungerManager.Eat(5);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
