using System;
using MongoDB.Bson;

public class Product
{
    public ObjectId Id;
    public ObjectId Advertiser;
    public string Title;
    public string Description;
    public double Review;
    public int Quantity;
    public int MaxQuantity;
    public Unit Unit;
    public double Price;
    public bool Highlighted;
    public Product(ObjectId Id, ObjectId Advertiser, string Title, string Description, double Review, int Quantity, int MaxQuantity, Unit Unit, double Price, bool Highlighted)
    {
        this.Id = Id;
        this.Advertiser = Advertiser;
        this.Title = Title;
        this.Description = Description;
        this.Review = Review;
        this.Quantity = Quantity;
        this.MaxQuantity = MaxQuantity;
        this.Unit = Unit;
        this.Price = Price;
        this.Highlighted = Highlighted;
    }
}

public enum Unit: int
{
    DB = 0,
    KG = 1,
    G = 2
}