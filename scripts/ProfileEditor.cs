using Godot;
using System;

public partial class ProfileEditor : Window
{
	[Export]
	private NodePath _name,_email,_phone,_password,_new_password,_zip_code,_settlement,_street;

	User user = LoginManager.GetUser();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<LineEdit>(_name).Text = user.Username;
		GetNode<LineEdit>(_email).Text = user.Email;
		GetNode<LineEdit>(_phone).Text = user.Phone;
		GetNode<LineEdit>(_zip_code).Text = user.Address[0];
		GetNode<LineEdit>(_settlement).Text = user.Address[1];
		GetNode<LineEdit>(_street).Text = user.Address[2];
	}

	private void _On_Update_Pressed()
	{
		user.Phone = GetNode<LineEdit>(_phone).Text;
		user.Address[0] = GetNode<LineEdit>(_zip_code).Text;
		user.Address[1] = GetNode<LineEdit>(_settlement).Text;
		user.Address[2] = GetNode<LineEdit>(_street).Text;

		Database.UpdateUser();
	}

	private void _On_Reset_Pressed()
	{
		_Ready();
	}

	private void OnCloseRequested()
	{
		this.Hide();
		GetParent().RemoveChild(this);
	}
}
