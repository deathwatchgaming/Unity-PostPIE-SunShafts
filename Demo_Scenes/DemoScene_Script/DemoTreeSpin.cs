using UnityEngine;

public class DemoTreeSpin : MonoBehaviour
{
    public float treeSpinSpeed = 8f;

    private void Update()
    {
        Vector3 treeSpin = new Vector3(0, 0, treeSpinSpeed);
        transform.Rotate(treeSpin.x, treeSpin.y, treeSpin.z * Time.deltaTime);
    }
}
