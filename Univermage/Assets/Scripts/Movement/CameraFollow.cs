using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform myTransform;
    CharacterDirection dir;

    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] Vector3 offset;

    void Awake()
    {
        myTransform = transform;
        myTransform.position = target.position + offset;
        dir = target.GetComponent<CharacterDirection>();
    }

    void LateUpdate()
    {
        //offset.x = dir.Direction.x;
        myTransform.position = Vector3.MoveTowards(myTransform.position, target.position + offset, speed * Time.deltaTime);
    }
}