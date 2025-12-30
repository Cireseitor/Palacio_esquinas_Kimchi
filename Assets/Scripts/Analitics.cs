using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Analitics : MonoBehaviour
{

    public enum Keys
    {

        TRACKED
    }

    public static Analitics instance;

    Dictionary<string, int> states = new Dictionary<string, int>();

    string path;

    public void Awake()
    {
        if (instance)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        //Datapath para local donde esta el exe
        path = Path.Combine(Application.dataPath, "Analitics.txt");

        if (!File.Exists(path))
        {
            StreamWriter writer = new StreamWriter(path);

            writer.Write("TRACKED:0");

            writer.Close();
        }

        states = ReadFile();

        foreach (KeyValuePair<string, int> entry in states) { }

    }

    public Dictionary<string, int> ReadFile()
    {
        StreamReader reader = new StreamReader(path);

        string text = reader.ReadToEnd();

        reader.Close();

        Dictionary<string, int> states = new Dictionary<string, int>();

        string[] lines = text.Split("\n");

        for (int i = 0; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(":");

            states.Add(values[0], int.Parse(values[1]));
        }

        return states;

    }

    public void WriteInFile()
    {

        string text = "";

        foreach (KeyValuePair<string, int> entry in states)
        {
            text += entry.Key + ":" + entry.Value;
        }

        StreamWriter writer = new StreamWriter(path);

        writer.Write(text);

        writer.Close();
    }

    public void SetEvent(Keys key)
    {
        string keyString = key.ToString();

        if (states.TryGetValue(keyString, out int result))
        {

            result++;

            states[keyString] = result;

            WriteInFile();
        }
        else { }
    }
}