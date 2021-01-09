using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    Transform target;
    float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerComponent>().transform;
    }

    // Update is called once per frame
    void Update() => FollowTarget();
    void FollowTarget()
    {
        if (!target)
            return;
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);
    }

}
