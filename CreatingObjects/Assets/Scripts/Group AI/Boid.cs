using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Boid : MonoBehaviour
{
    public Vector3 desiredVelocity;
    public Transform target;
    private Rigidbody rb;
    public float slowingDistance;
    [Range(0,20)]
    public float maxSpeed;
    [Range(0,5)]
    public float seekForce = 1;
    [Range(0,5)]
    public float fleeForce = 1;
    public float timeToReach;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        this.transform.forward = this.rb.velocity;
    }

    void FixedUpdate()
    {
        //this.rb.velocity += seekForce * Seek(rb.position, target.position);
        //this.rb.velocity += fleeForce * Flee(rb.position, target.position);
        //this.rb.velocity += seekForce * Wander(rb.position, rb.velocity);

        var distance = (target.position - this.transform.position).magnitude;
        var time = Arrive(distance, slowingDistance, timeToReach);
        //this.rb.velocity = Truncate(rb.velocity, Arrive(distance, slowingDistance, maxSpeed)); //Only use if seeking
        //this.rb.velocity += seekForce * Chase(rb.position, target.transform.position, rb.velocity, time);

        this.rb.velocity = Truncate(rb.velocity, maxSpeed);

    }

    Vector3 Chase(Vector3 selfPosition, Vector3 targetPosition, Vector3 targetVelocity, float time)
    {
        var futurePosition = targetPosition + targetVelocity * time;
        return Seek(selfPosition, futurePosition);
    }

    Vector3 Evade(Vector3 selfPosition, Vector3 targetPosition, Vector3 targetVelocity, float time)
    {
        var futurePosition = targetPosition + targetVelocity * time;
        return Flee(selfPosition, futurePosition);
    }

    Vector3 Steer(Vector3 currentVelocity, Vector3 desiredVelocity)
    {
        return (desiredVelocity.normalized - currentVelocity.normalized).normalized;
    }

    Vector3 Seek(Vector3 currentPosition, Vector3 targetPosition)
    {
        return (targetPosition - currentPosition).normalized;
    }

    Vector3 Flee(Vector3 currentPosition, Vector3 targetPosition)
    {
        return -(targetPosition - currentPosition).normalized;
    }

    Vector3 Truncate(Vector3 vector, float maximum)
    {
        return (vector.magnitude > maximum) ? vector.normalized * maximum: vector;
    }

    float Arrive(float distance, float slowingDistance, float maxDistance)
    {
        return (distance < slowingDistance) ? (slowingDistance / maxDistance) * distance : distance;
    }

    Vector3 Wander(Vector3 position, Vector3 velocity)
    {
        Vector3 point = position + velocity.normalized;
        var theta = Random.Range(-Mathf.PI, Mathf.PI);
        var radius = 1;
        point.x += radius * Mathf.Cos(theta);
        point.y += radius * Mathf.Sign(theta);

        return point;
    }
}
