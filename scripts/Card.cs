using Godot;
using MongoDB.Bson;
using System;
using System.Formats.Asn1;

public partial class Card : Control
{

	[Export]
	private NodePath _titlePath,_descriptonPath,_reviewPath,_quantityPath,_pricePath;
	public Product Product;

	
	/// <summary>
	/// Kártya adatainak betöltése
	/// </summary>
	public override void _Ready()
	{
		GetNode<Label>(_titlePath).Text = Product.Title;
		GetNode<RichTextLabel>(_descriptonPath).Text = Product.Description;
		GetNode<Label>(_reviewPath).Text = Product.Review + "/5";
		GetNode<Label>(_quantityPath).Text = Product.Quantity + "/" + Product.MaxQuantity;
		GetNode<Label>(_pricePath).Text = Product.Price + "Ft/" + Product.Unit.ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
