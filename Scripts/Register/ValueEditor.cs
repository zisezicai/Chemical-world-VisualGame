using Godot;
using System;

public partial class ValueEditor : LineEdit
{
	Item item;
	FinishButton finishButton;
	TextureRect warningIcon;
	public override void _Ready()
	{
		item=GetParent<Item>();
		finishButton=GetNode<FinishButton>("../../../finishButton");
		warningIcon=GetNode<TextureRect>("../warning");
		if(item.itemName=="playerName"){
			finishButton.Disabled=true;//玩家名不可为空
			this.TextChanged+=onTextChanged;
		}
	}
	public void onTextChanged(string text)
	{
		this.RemoveThemeColorOverride("font_color");
		if (text == "")
		{
			warningIcon.TooltipText="玩家名不能为空！";
			warningIcon.Visible=true;
			finishButton.Disabled=true;//玩家名不可为空
			return;
		}
		using var stream=FileAccess.Open("user://saves/"+text+".json",FileAccess.ModeFlags.Read);
		if (stream != null)
		{
			stream.Close();
			warningIcon.TooltipText="玩家名重复！";
			warningIcon.Visible=true;
			finishButton.Disabled=true;//玩家名不可重复
			this.AddThemeColorOverride("font_color",Colors.Red);
			return;
		}
		warningIcon.Visible=false;
		finishButton.Disabled=false;//如果都没问题，就允许保存
	}
}
