using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class FindMat : EditorWindow
{

    [MenuItem("Find/mat")]
    static void Find()
    {
        FindMat window = (FindMat)EditorWindow.GetWindow(typeof(FindMat));
    }
    GameObject obj;
    void OnGUI()
    {

        obj = EditorGUILayout.ObjectField("物体", obj, typeof(GameObject), true) as GameObject;
        if (obj && GUILayout.Button("开始查找", GUILayout.Width(200)))
        {
            Debug.Log("开始查找");
            OnFind(obj);
        }
    }
    List<string> matName;
    GameObject nullobj;
    void OnFind(GameObject go)
    {
        if (go == null) return;
        nullobj = new GameObject();
        matName = new List<string>();
        GameObject matgo;
        Material mat;
        for (int i = 0; i <= go.transform.childCount; i++)
        {
            matgo = go;
            
            mat = matgo.GetComponent<MeshRenderer>().materials[0];
            if (!matName.Contains(mat.name))
            {
                GameObject matprent = Instantiate<GameObject>(nullobj, go.transform);
                matprent.name = mat.name;
                matgo.transform.parent = matprent.transform;
                matName.Add(mat.name);
            }
            else if (matName.Contains(mat.name))
            {
                matgo.transform.parent = go.transform.Find(mat.name);
            }
            OnFind(matgo.transform.GetChild(i).gameObject);
        }
    }
}
