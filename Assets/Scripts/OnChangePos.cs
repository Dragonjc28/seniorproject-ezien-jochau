using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChangePos : MonoBehaviour
{
    public PolygonCollider2D hole2dCollider;
    public PolygonCollider2D ground2dCollider;
    public MeshCollider GenMeshCollider;
    public Collider GroundCollider;
    public float scale = 0.5f;
    Mesh GenMesh;

    public IEnumerator IncreaseSize()
    {
        Vector3 InitScale = transform.localScale;
        Vector3 FinScale = InitScale * 1.8f;

        float t = 0;
        while (t <= 0.4f)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(InitScale, FinScale, t);
            yield return null;
        }
    }

    private void Start()
    {
        GameObject[] objects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (var obj in objects)
        {
            if (obj.layer == LayerMask.NameToLayer("Obstacles"))
            {
                Physics.IgnoreCollision(obj.GetComponent<Collider>(), GenMeshCollider, true);
            }
        }
    }
    private void FixedUpdate()
    {
        if(transform.hasChanged == true)
        {
            transform.hasChanged = false;
            hole2dCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
            hole2dCollider.transform.localScale = transform.localScale * scale;
            MakeHole();
            Make3dMeshCollider();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Physics.IgnoreCollision(other, GroundCollider, true);
        Physics.IgnoreCollision(other, GenMeshCollider, false);
    }

    private void OnTriggerExit(Collider other)
    {
        Physics.IgnoreCollision(other, GroundCollider, false);
        Physics.IgnoreCollision(other, GenMeshCollider, true);
    }

    private void MakeHole()
    {
        Vector2[] positions = hole2dCollider.GetPath(0);

        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = hole2dCollider.transform.TransformPoint(positions[i]);
        }

        ground2dCollider.pathCount = 2;
        ground2dCollider.SetPath(1, positions);
    }

    private void Make3dMeshCollider()
    {
        if (GenMesh!=null) Destroy(GenMesh);
        GenMesh = ground2dCollider.CreateMesh(true, true);
        GenMeshCollider.sharedMesh = GenMesh;
    }
}
