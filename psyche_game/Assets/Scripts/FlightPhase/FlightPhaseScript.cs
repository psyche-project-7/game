using UnityEngine;
using System.Collections;

    [RequireComponent(typeof(LineRenderer))]
public class FlightPhaseScript : MonoBehaviour
{
    public int vertexCount = 150;
    public float lineWidth = 0.2f;
    public float radius;

    private LineRenderer renderer;
    
    private void Awake() 
    {
        renderer = GetComponent<LineRenderer>();
        makeCircle();
    }

    private void makeCircle()
    {
        renderer.widthMultiplier = lineWidth;
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;        
        renderer.positionCount = vertexCount;        
        var points = new Vector3[vertexCount + 1];
        for (int i = 0; i < vertexCount + 1; i++)
        {
            radius = i*5;             
            points[i] = new Vector3((radius/vertexCount) * Mathf.Cos(theta*3), (radius/vertexCount) * Mathf.Sin(theta*3), 0f);
            
            theta += deltaTheta;
            Debug.Log("This is Theta: " + deltaTheta.ToString());
        }
        renderer.SetPositions(points);
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        float deltaTheta = (2f * Mathf.PI) / 40f;
        float theta = 0f;
        
        float counter = 0f;
        
        Vector3 oldPos = Vector3.zero;
        for (int i = 0; i < vertexCount + 1; i++){
        float r = theta * (counter);
        Vector3 pos = new Vector3((r/400) * Mathf.Cos(theta), (r/400) * Mathf.Sin(theta), 0f);
        Gizmos.DrawLine(oldPos, transform.position + pos);
        oldPos = transform.position + pos;
        counter++;
        theta += deltaTheta;
        }
    }
#endif
}