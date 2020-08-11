using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FOV : MonoBehaviour
{
    private Mesh mesh;
    private Vector3 origin;
    private float startingAngle;
    private float fov;
    void Start()
    {
        fov = 65f;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
    }

    public void LateUpdate()
    {

        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 2f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;
        vertices[1] = new Vector3(3, 0);
        vertices[2] = new Vector3(0, -3);

        int vertexIndex = 1;
        int triangleIndex = 0;
        //Finds Collisions.
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            Vector3 change = new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), Mathf.Sin(angle * (Mathf.PI / 180f)));
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, change, viewDistance);
            if (raycastHit2D.collider == null)
            {
                change = new Vector3(Mathf.Cos(angle * (Mathf.PI / 180f)), Mathf.Sin(angle * (Mathf.PI / 180f)));
                vertex = origin + change * viewDistance;
            }
            else
            {
                vertex = raycastHit2D.point;
                //Used To detect player
                if (raycastHit2D.collider.name == "Player")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                }
            }

            vertices[vertexIndex] = vertex;
            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
    //Keps FOV on enemy.
    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    //Used To get direction enemy is facing FOV faces that way
    public void SetAimDirection(Vector3 aimDirection)
    {
        Vector3 dir = aimDirection.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        startingAngle = n + fov / 2f;
    }

}
