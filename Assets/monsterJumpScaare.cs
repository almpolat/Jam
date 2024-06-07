using UnityEngine;

public class monsterJumpScaare : MonoBehaviour
{
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
