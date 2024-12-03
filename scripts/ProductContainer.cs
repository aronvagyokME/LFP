using Godot;
using MongoDB.Bson;
using System;

public partial class ProductContainer : VBoxContainer
{
	[Export]
	private PackedScene _card;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var products = Database.GetProducts();

		foreach (var product in products)
		{

			Card card = _card.Instantiate() as Card;
			card.Product = product;
			AddChild(card);
		}

	}

	/// <summary>
	/// Terméklista frissítése
	/// </summary>
	public void Update()
	{
		foreach (var child in this.GetChildren())
		{
			RemoveChild(child);
			child.QueueFree();
		}

		var products = Database.GetProducts();

		foreach (var product in products)
		{

			Card card = _card.Instantiate() as Card;
			card.Product = product;
			AddChild(card);
		}
	}
}
