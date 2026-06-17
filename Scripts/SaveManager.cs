using Godot;
using Godot.Collections;
using System;
public partial class SaveManager : Singlection<SaveManager>
{
    public string playerName="none";
    public int coins=0;
    public void writeIntoFile()//写入文件
    {
        try
        {
            using var stream = FileAccess.Open("user://saves/"+playerName, FileAccess.ModeFlags.Write);
            var content =new Dictionary<string, Variant>
            {
              ["playName"]= playerName,
              ["coins"]=coins
            };
            stream.StoreVar(Json.Stringify(content,indent:"\t"));
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
        using var stream = FileAccess.Open("user://saves/"+playerName, FileAccess.ModeFlags.Read);
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
            SaveManager.Instance=save;
        }
        return save;
    }



    public static string[] getSaveList()//获取存档列表
    {
        System.Collections.Generic.List<string> list=new System.Collections.Generic.List<string>();
        var dir=DirAccess.Open("user://saves");
        if (dir == null)
        {
            return null;
        }
        dir.ListDirBegin();
        string name=dir.GetNext();
        while (name != "")
        {
            if (dir.CurrentIsDir())
            {
                list.Add(name);
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
            SaveManager.Instance=save;
        }
        return save;
    }
}