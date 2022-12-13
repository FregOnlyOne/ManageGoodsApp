using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageGoodsApp.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }
    public int Count { get; set; }
    public double Price { get; set; }
    public int Discount { get; set; }

    [NotMapped]
    public double DiscountPrice
    {
        get
        {
            return Price * ((100 - Convert.ToDouble(Discount))) / 100;
        }
    }

    [NotMapped]
    public double TotalCost
    {
        get
        {
            return Convert.ToDouble(Count) * DiscountPrice;
        }
    }

    [NotMapped]
    public Category ProductCategory
    {
        get
        {
            return DataWorker.GetCategoryById(CategoryId);
        }
    }

    [NotMapped]
    public Warehouse ProductWarehouse
    {
        get
        {
            return DataWorker.GetWarehouseById(WarehouseId);
        }
    }
}