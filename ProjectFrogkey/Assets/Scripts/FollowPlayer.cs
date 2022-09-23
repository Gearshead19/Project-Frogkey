using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToRotate;

    [SerializeField]
    private GameObject playerHead;

    [SerializeField]
    private float yPadding = 1f;

    private Transform joint;

    private void Start()
    {
        if (playerHead == null)
        {
            Debug.Log($"{this.name} does not have a PlayerHead assigned.");
        }

        if (objectToRotate == null)
        {
            Debug.Log($"{this.name} is missing ObjectToRotate.");
        }
        else
        {
            joint = objectToRotate.transform;
        }
    }

    private void Update()
    {
        if (playerHead != null && objectToRotate != null)
        {
            Quaternion newRotation = Quaternion.LookRotation((playerHead.transform.position - joint.position) + new Vector3(0, yPadding, 0), Vector3.up);
            objectToRotate.transform.rotation = newRotation;
        }
    }
}
