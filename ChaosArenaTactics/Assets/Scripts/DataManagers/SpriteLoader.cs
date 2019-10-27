using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLoader
{
    private Dictionary<string, Sprite> ui;

    public SpriteLoader()
    {
    }

    #region Get Sprite

    public Sprite GetUI(string id)
    {
        return ui[id];
    }

    #endregion

    #region Loading

    private void loadUI()
    {
        ui = this.loadDirectory(Path.Combine(DataController.FileSystem.spritesFolderPath, "ui"));
    }

    public Dictionary<string, Sprite> LoadAllChars()
    {
        Dictionary<string, Sprite> ret = new Dictionary<string, Sprite>();

        FileSystemHelper fileSystem = DataController.FileSystem;
        List<string> fighters = fileSystem.getAllFighterDirectories();

        foreach (string fighter in fighters)
        {
            ret.Add(fileSystem.getFighterNameFromDirectoryPath(fighter), loadSprite(Path.Combine(fighter, "sprites/char.png")));
        }

        return ret;
    }

    private Dictionary<string, Sprite> loadDirectory(string path)
    {
        string[] files = Directory.GetFiles(path, "*.png");

        Dictionary<string, Sprite> ret = new Dictionary<string, Sprite>();

        foreach (string fn in files)
        {
            int start = fn.LastIndexOf("\\") + 1;
            string name = fn.Substring(start, fn.Length - start - 4); //removing path and extension from the name

            ret.Add(name, loadSprite(fn));
        }

        return ret;
    }

    #endregion

    #region Loading From Disk

    private Sprite loadSprite(string path, Vector2 pivot, Rect rect, int pixelsPerUnit = 100)
    {
        if (!path.EndsWith("png"))
            path += ".png";

        byte[] rawImage = File.ReadAllBytes(path);  //reading image file
        Texture2D texture = new Texture2D(1, 1); //create texture object
        texture.LoadImage(rawImage); //actually loading the image

        if (pivot.x == -1 && pivot.y == -1)
            pivot = new Vector2(0.5f, 0.5f);

        if (rect == Rect.zero)
            rect = new Rect(0, 0, texture.width, texture.height);

        return Sprite.Create(texture, rect, pivot, pixelsPerUnit);
    }

    private Sprite loadSprite(string path, Vector2 pivot)
    {
        return this.loadSprite(path, pivot, Rect.zero);
    }

    private Sprite loadSprite(string path)
    {
        return this.loadSprite(path, new Vector2(-1, -1));
    }

    #endregion
}
