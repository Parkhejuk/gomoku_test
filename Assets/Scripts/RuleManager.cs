using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
    Process process;

    void ParsingPY()
    {
        process.StartInfo.FileName = @"C:\Program Files\Python36\python.exe";
        process.StartInfo.Arguments = @"C:\Users\PHJ\Desktop\Unity Files\Gomoku\Assets\Scripts\Rules.py";
    }
    // Start is called before the first frame update
    void Start()
    {
        ParsingPY();
    }

    // Update is called once per frame
    void Update()
    {
        process.Start();
    }
}
