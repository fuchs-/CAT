using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class FileSystemHelper
{
    public string spritesFolderPath;
    public string fightersFolderPath;

    public FileSystemHelper()
    {
        spritesFolderPath = Path.Combine(Application.streamingAssetsPath, "sprites");
        fightersFolderPath = Path.Combine(Application.streamingAssetsPath, "fighters");
    }

    public List<string> getAllFighterUniversesDirectories()
    {
        List<string> ret = new List<string>();

        ret.AddRange(Directory.GetDirectories(fightersFolderPath));
        ret.Remove("info");

        return ret;
    }

    public List<string> getAllFighterDirectories()
    {
        List<string> ret = new List<string>();

        foreach (string universe in getAllFighterUniversesDirectories())
        {
            ret.AddRange(Directory.GetDirectories(universe));
        }

        return ret;
    }

    public string getFighterNameFromDirectoryPath(string path)
    {
        string[] strs = path.Split('\\');
        return strs[strs.Length - 1];
    }
}
