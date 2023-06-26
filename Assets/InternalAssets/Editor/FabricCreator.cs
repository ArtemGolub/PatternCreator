using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class FabricCreator : EditorWindow
{
    private string IClassName = "";
    private List<string> classNames = new List<string>();
    private int inheritedClassNumber;
    
    
    
    [MenuItem("Custom Tools/Fabric/New Fabric")]
    private static void SetUpFolders()
    {
        // Check if the window is already open
        FabricCreator existingWindow = EditorWindow.GetWindow<FabricCreator>(false, "New Fabric");
        if (existingWindow != null)
        {
            // If the window is open, close it
            existingWindow.Close();
        }

        // Create a new instance of the window
        FabricCreator window = GetWindow<FabricCreator>();
        window.titleContent = new GUIContent("New Fabric");
        window.minSize = new Vector2(800   , 300);
        window.Show();
    }
    
    private void OnGUI()
    {
        GUILayout.Label("Enter IClass Name:", EditorStyles.boldLabel);

        IClassName = EditorGUILayout.TextField("IClass Name", IClassName);
        
        GUILayout.Space(10);

        inheritedClassNumber = EditorGUILayout.IntField("Inherited Class Number", inheritedClassNumber);

        GUILayout.Space(10);

        for (int i = 0; i < inheritedClassNumber; i++)
        {
            GUILayout.Label("Inherited Class Name " + (i + 1) + ":", EditorStyles.boldLabel);
            if (i >= classNames.Count)
            {
                classNames.Add("");
            }
            classNames[i] = EditorGUILayout.TextField(classNames[i]);
        }
        
        
        EditorGUILayout.LabelField("Fabric Generator");
        this.Repaint();
        GUILayout.Space(70);
        if (GUILayout.Button("Generate!"))
        {
            CreateObjectInterface();
            CreateObjectClass(classNames);

            CreateFabricInterface();

            CreateFabricManager();

            CreateFabricImplementation();
            
            this.Close();
        }
        if (GUILayout.Button("Close!"))
        {
            this.Close();
        }
    }
    
    private void CreateObjectInterface()
    {
        string scriptPath = Path.Combine("Assets", "InternalAssets", "Editor", IClassName + ".cs");
        if (!File.Exists(scriptPath))
        {
            string scriptContent = @"public interface " + IClassName + @"
{
    void Action();
}";
            File.WriteAllText(scriptPath, scriptContent);
        }
        AssetDatabase.Refresh();
    }
    
    private void CreateObjectClass(List<string> ClassName)
    {
        foreach (var className in ClassName)
        {
            string scriptPath = Path.Combine("Assets", "InternalAssets", "Editor", className + ".cs");
            if (!File.Exists(scriptPath))
            {
                string scriptContent = @"using System;

public class " + className + @":" + IClassName + @"
{
    public void Action()
    {
        Console.WriteLine(""No Action Logic implemented in: "" + nameof(" + className + @"));
            }
     }
";
                File.WriteAllText(scriptPath, scriptContent);
            }
        }

        AssetDatabase.Refresh();
    }


    private void CreateFabricInterface()
    {
        string fabricName = IClassName + "Fabric";
        string scriptPath = Path.Combine("Assets", "InternalAssets", "Editor", fabricName + ".cs");
        if (!File.Exists(scriptPath))
        {
            string scriptContent = @"public interface " + fabricName + @"
{
   " +IClassName + @" CreateObject();
}";
            File.WriteAllText(scriptPath, scriptContent);
        }
        AssetDatabase.Refresh();

        CreateObjectsFabric(classNames, fabricName);
    }
    
    
    private void CreateObjectsFabric(List<string> ClassNemes, string FabricName)
    {
        foreach (var className in ClassNemes)
        {
            string scriptPath = Path.Combine("Assets", "InternalAssets", "Editor", className +"Fabric.cs");
            if (!File.Exists(scriptPath))
            {
                string scriptContent = @"public class " + className +"Fabric" + ":"  + FabricName + @"
{
    public " + IClassName + @" CreateObject()
    {
        return new " + className + @"();
    }
}
";
                File.WriteAllText(scriptPath, scriptContent);
            }
        }
        AssetDatabase.Refresh();
    }

    private void CreateFabricManager()
    {
        var fabricManagerName = IClassName.Substring(1) + "FabricManager";
        string fabricName = IClassName + "Fabric";
        var subName = IClassName.Substring(1).ToLower();
        
        string scriptPath = Path.Combine("Assets", "InternalAssets", "Editor", fabricManagerName + ".cs");
        if (!File.Exists(scriptPath))
        {
            string scriptContent = @"public class " + fabricManagerName + @"
{
    private " + fabricName + @" fabric;

    public void " + "Set" + fabricName + @"(" + fabricName + @" fabric)
    {
        this.fabric = fabric;
    }

    public void CreateAndInitialize" + IClassName.Substring(1) + @"()
    {
        "+ IClassName +" " + subName + @"= fabric.CreateObject();
        " + subName + @".Action();
    }
}";
            File.WriteAllText(scriptPath, scriptContent);
        }
        AssetDatabase.Refresh();
    }


    private void CreateFabricImplementation()
    {
        CreateFabricEnum();
        string fabricName = IClassName.Substring(1) + "Fabric";
        string scriptPath = Path.Combine("Assets", "InternalAssets", "Editor", fabricName + ".cs");

        if (!File.Exists(scriptPath))
        {
            string scriptContent = @"


using UnityEngine;

public class NewFabricImplementation : MonoBehaviour
{
    private " + IClassName.Substring(1) + "FabricManager" + @" _fabricManager;
    [Header(""Settings"")]
    [SerializeField]private FabricType myFabricType;
    [SerializeField]private float firstSpawnDelay = 1f;
    [SerializeField]private float repeatRate = 1f;
    

  
    private void Start()
    {
        InitFactory();
        InvokeRepeating(""Spawn" + IClassName.Substring(1)+@""", firstSpawnDelay, repeatRate);
    }

    private void Spawn" + IClassName.Substring(1) + @"()
    {
        _fabricManager.CreateAndInitializeUnit();
    }

    private void InitFactory()
    {
        _fabricManager = new" + IClassName.Substring(1) + "FabricManager" +@"();
        " + GetAllSwitches() + @"

    }
}
";
            File.WriteAllText(scriptPath, scriptContent);
        }
        AssetDatabase.Refresh();
    }


    private void CreateFabricEnum()
    {
        string fabricName = IClassName.Substring(1) + "FabricType";
        string scriptPath = Path.Combine("Assets", "InternalAssets", "Editor", fabricName + ".cs");

        string ClassNamesEnum = "";
        foreach (var className in classNames)
        {
            ClassNamesEnum += className + ", ";
        }
        
        if (!File.Exists(scriptPath))
        {
            string scriptContent = @"
    private enum " + fabricName + @"
    {" + ClassNamesEnum + @"}";

            File.WriteAllText(scriptPath, scriptContent);
        }
        AssetDatabase.Refresh();
    }

    private string GetAllSwitches()
    {
        string myString = @"switch (myFabricType)
        {
";
        for (int i = 0; i < classNames.Count; i++)
        {
            myString += "case FabricType." + classNames[i] + ":\n";
            myString += "{\n";
            myString += "    break;\n";
            myString += "}\n";
        }

        myString += "}";
        return myString;
    }

}
