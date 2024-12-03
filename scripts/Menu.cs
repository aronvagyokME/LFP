using Godot;
using System;
using System.Diagnostics;

public partial class Menu : MenuButton
{

	[Export]
	private PackedScene _login,_profile,_profile_editor;
	public override void _Ready()
	{
		var popup = GetPopup();
		popup.Connect(PopupMenu.SignalName.IdPressed, new Callable(this,MethodName.OnButtonDown));
	}

	/// <summary>
	/// Legördülő menü gombjainak kezelése
	/// </summary>
	/// <param name="id">A gomb azonosítószáma</param>
	private void OnButtonDown(int id)
	{
		switch (id) {
			case 0: {
					if (LoginManager.IsLoggedIn())
					{
						var profile = _profile.Instantiate();
						AddChild(profile);
					} else {
						var login = _login.Instantiate();
						AddChild(login);
					}
				return;
			}
			case 1: {
				if (LoginManager.IsLoggedIn())
				{
					var editor = _profile_editor.Instantiate();
					AddChild(editor);
				}
				return;
			}	
			case 2: {
				LoginManager.SetUser(null);
				return;
			}
		}
	}
}
