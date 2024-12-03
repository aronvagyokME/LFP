using Godot;
using System;

public partial class Profile : Window
{
	private void OnCloseRequested()
	{
		this.Hide();
		GetParent().RemoveChild(this);
	}
}
