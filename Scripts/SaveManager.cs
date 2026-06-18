using Godot;
using Godot.Collections;
using System;
public partial class SaveManager : Singlection<SaveManager>
{
    public string playerName="none";
    public int coins=0;
    const string saveDir = "user://saves";
    public void writeIntoFile()//写入文件
    {
        try
        {
            if (!DirAccess.DirExistsAbsolute(saveDir))
            {
                DirAccess.MakeDirRecursiveAbsolute(saveDir);
            }
            using var stream = FileAccess.Open("user://saves/"+playerName+".json", FileAccess.ModeFlags.Write);
            var content =new Dictionary<string, Variant>
            {
              ["playName"]= playerName,
              ["coins"]=coins
            };
            stream.StoreString(Json.Stringify(content,indent:"\t"));
        }
        catch (Exception e)
        {
            GD.PrintErr(e.Message);
        }
    }
    
    
    
    
    public static SaveManager loadSave(string playerName,bool justGet=false)//加载存档
    {
        SaveManager save=new SaveManager();
        Dictionary content;
        using var stream = FileAccess.Open("user://saves/"+playerName+".json", FileAccess.ModeFlags.Read);
        Json json=new Json();
        Error error =json.Parse(stream.GetAsText());
        if (error != Error.Ok)
        {
            return null;
        }
        content=json.Data.AsGodotDictionary();
        //一条一条的写入


        save.playerName=content["playName"].AsString();
        save.coins=content["coins"].AsInt32();
        
        
        
        
        if (!justGet)
        {
            if (Instance != null)//确保即使保存
            {
                Instance.writeIntoFile();
            }
            SaveManager.Instance=save;
        }
        return save;
    }



    public static string[] getSaveList()//获取存档列表
    {
        var list=new System.Collections.Generic.List<string>();
        var dir=DirAccess.Open("user://saves");
        if (dir == null)
        {
            DirAccess.MakeDirRecursiveAbsolute("user://saves");
            return System.Array.Empty<string>();
        }
        dir.ListDirBegin();
        string name=dir.GetNext();
        while (name != "")
        {
            if (!dir.CurrentIsDir() && name.EndsWith(".json"))
            {
                list.Add(name.Replace(".json", ""));
            }
            name=dir.GetNext();
        }
        return list.ToArray();
    }


    public static SaveManager createSave(string playerName,bool justGet=false)//创建存档
    {
        SaveManager save=new SaveManager();
        save.playerName=playerName;
        save.coins=0;
        save.writeIntoFile();
        if (!justGet)
        {
            if(Instance != null)
            {
                Instance.writeIntoFile();
            }
            SaveManager.Instance=save;
        }
        return save;
    }
}