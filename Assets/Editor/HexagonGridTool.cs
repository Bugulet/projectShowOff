using UnityEditor;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
[CustomEditor(typeof(HexagonGrid))]

public class HexagonGridTool : Editor
{


	private float size = 1f;
    private Vector3 offset,currentPos;
    private Transform targetTransform;
    private Vector3 extents;

    private bool browseMaterial=true;

    private bool copyMode = false;

    private void Awake()
    {
        targetTransform = ((HexagonGrid)target).transform;
        currentPos = ((HexagonGrid)target).transform.position;
    }
    

    protected virtual void OnSceneGUI()
    {
        extents=((HexagonGrid)target).GetComponent<Renderer>().bounds.extents;
        size = extents.x;
        //Gizmos.DrawIcon(targetTransform.position, "testIcon");
        float xConstant = 0.75f;
        float yConstant = 0.433f;
        float sizeReduced = size / 3;

        Transform toolTransform = ((HexagonGrid)target).transform;

        Handles.color = Handles.zAxisColor; 

        switch (Event.current.type)
        {
            case EventType.KeyDown:
                {
                    if (Event.current.keyCode == (KeyCode.M) && browseMaterial==true)
                    {
                        ((HexagonGrid)target).NextMaterial();
                        browseMaterial = false;
                    }
                    if (Event.current.keyCode == (KeyCode.N) && browseMaterial == true)
                    {
                        ((HexagonGrid)target).PreviousMaterial();
                        browseMaterial = false;
                    }
                    if (Event.current.keyCode == (KeyCode.C))
                    {
                        copyMode = !copyMode;
                    }
                    break;
                }
            case EventType.KeyUp:
                {
                    if (Event.current.keyCode == (KeyCode.N) || Event.current.keyCode == (KeyCode.M))
                        browseMaterial = true;
                    break;
                }
        }

        //buttons
        {
            //i assume this is finally done...
            if (copyMode)
                Handles.color = new Color(1f, 0.5f, 0.0f, 0.5f);

            //top
            if (Handles.Button(toolTransform.position + new Vector3(0, 0f, size * yConstant*2),
               toolTransform.rotation * Quaternion.LookRotation(Vector3.right), sizeReduced, sizeReduced, Handles.SphereHandleCap))
            {
                if (copyMode) Instantiate(toolTransform.gameObject);

                offset.z++;
                Vector3 hexPos = CalcWorldPos(new Vector2(offset.x, offset.z));
                hexPos += currentPos;
                ((HexagonGrid)target).transform.position = new Vector3(hexPos.x, hexPos.y, hexPos.z);
            }

            if (Handles.Button(toolTransform.position + new Vector3(0, 0f, -size * yConstant * 2),
               toolTransform.rotation * Quaternion.LookRotation(Vector3.right), sizeReduced, sizeReduced, Handles.SphereHandleCap))
            {
                if (copyMode) Instantiate(toolTransform.gameObject);

                offset.z--;
                Vector3 hexPos = CalcWorldPos(new Vector2(offset.x, offset.z));
                hexPos += currentPos;
                ((HexagonGrid)target).transform.position = new Vector3(hexPos.x, hexPos.y, hexPos.z);
            }

            //right top
            if (Handles.Button(toolTransform.position + new Vector3(size * xConstant, 0f, size * yConstant),
                toolTransform.rotation * Quaternion.LookRotation(Vector3.right), sizeReduced, sizeReduced, Handles.SphereHandleCap))
            {
                if (copyMode) Instantiate(toolTransform.gameObject);

                offset.x++;
                if (offset.x % 2 == 0)
                    offset.z++;
                Vector3 hexPos = CalcWorldPos(new Vector2(offset.x, offset.z));
                hexPos += currentPos;
                ((HexagonGrid)target).transform.position = new Vector3(hexPos.x, hexPos.y, hexPos.z);
            }

            //left top
            if (Handles.Button(toolTransform.position + new Vector3(-size * xConstant, 0f, size * yConstant),
                toolTransform.rotation * Quaternion.LookRotation(Vector3.right), sizeReduced, sizeReduced, Handles.SphereHandleCap))
            {
                if (copyMode) Instantiate(toolTransform.gameObject);

                offset.x--;
                if (offset.x % 2 == 0)
                    offset.z++;
                Vector3 hexPos = CalcWorldPos(new Vector2(offset.x, offset.z));
                hexPos += currentPos;
                ((HexagonGrid)target).transform.position = new Vector3(hexPos.x, hexPos.y, hexPos.z);
            }

            //right bottom
            if (Handles.Button(toolTransform.position + new Vector3(size * xConstant, 0f, -size * yConstant),
                toolTransform.rotation * Quaternion.LookRotation(Vector3.right), sizeReduced, sizeReduced, Handles.SphereHandleCap))
            {
                if (copyMode) Instantiate(toolTransform.gameObject);

                offset.x++;
                if (offset.x % 2 != 0)
                    offset.z--;
                Vector3 hexPos = CalcWorldPos(new Vector2(offset.x, offset.z));
                hexPos += currentPos;
                ((HexagonGrid)target).transform.position = new Vector3(hexPos.x, hexPos.y, hexPos.z);
            }

            //left bottom
            if (Handles.Button(toolTransform.position + new Vector3(-size * xConstant, 0f, -size * yConstant),
                toolTransform.rotation * Quaternion.LookRotation(Vector3.right), sizeReduced, sizeReduced, Handles.SphereHandleCap))
            {
                if (copyMode) Instantiate(toolTransform.gameObject);

                offset.x--;
                if (offset.x % 2 != 0)
                    offset.z--;
                Vector3 hexPos = CalcWorldPos(new Vector2(offset.x, offset.z));
                hexPos += currentPos;
                ((HexagonGrid)target).transform.position = new Vector3(hexPos.x, hexPos.y, hexPos.z);
            }


            sizeReduced /= 1.2f;
            Handles.color = new Color(0, 0.8f, 1f, 0.5f);
            if (Handles.Button(toolTransform.position + new Vector3(extents.x/5f, 0,0),
                toolTransform.rotation * Quaternion.LookRotation(Vector3.right), sizeReduced, sizeReduced, Handles.ConeHandleCap))
            {
                ((HexagonGrid)target).NextMaterial();
            }
            if (Handles.Button(toolTransform.position + new Vector3(-extents.x/5f, 0, 0),
                toolTransform.rotation * Quaternion.LookRotation(Vector3.left), sizeReduced, sizeReduced, Handles.ConeHandleCap))
            {
                ((HexagonGrid)target).PreviousMaterial();
            }
            
        }

    }

    private Vector3 CalcWorldPos(Vector2 gridPos)
    {

        float apothem = 0.866f *extents.x;
        float width = 1.732f * extents.x;

        float offset = 0;

        if (gridPos.x % 2 != 0)
        {
            offset = width / 2;
        }

        float x = gridPos.x * 1.5f*extents.x;
        float z = gridPos.y *apothem*2 +offset;

        return new Vector3(x, 0, z);
    }
}
#endif