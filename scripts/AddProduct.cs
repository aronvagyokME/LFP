using Godot;
using MongoDB.Bson;
using System;

public partial class AddProduct : Window
{
	[Export]
	private NodePath _name,_description,_amount,_price,_unit;

	/// <summary>
	/// Termék létrehozása és hozzáadása az adatbázishoz
	/// </summary>
	private void _On_Accept_Pressed()
	{
		var Product = new Product(
			new ObjectId(),
			LoginManager.GetUser().Id,
			GetNode<LineEdit>(_name).Text,
			GetNode<TextEdit>(_description).Text,
			4.0,
			Convert.ToInt16(GetNode<SpinBox>(_amount).Value),
			Convert.ToInt16(GetNode<SpinBox>(_amount).Value),
			(Unit) GetNode<OptionButton>(_unit).Selected,
			GetNode<SpinBox>(_price).Value,
			false
		);

		Database.InsertProduct(Product);
	}

	private void OnCloseRequested()
	{
		this.Hide();
		GetParent().RemoveChild(this);
	}
}
