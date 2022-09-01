using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPower : MonoBehaviour
{
    [SerializeField] private float angle;
    [SerializeField] private float power;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(angle,90,0)* power, ForceMode.Force);
    }
}
