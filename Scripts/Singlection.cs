using Godot;
public partial class Singlection<T> : GodotObject where T:new()
{
    public static T Instance
    {
        get
        {
            if(__instance == null)
            {
                __instance = new T();
            }
            return __instance;
        }
        protected set
        {
            __instance = value;
        }
    }
    private static T __instance;
}