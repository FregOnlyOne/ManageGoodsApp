using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageGoodsApp.Model;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }

    [NotMapped]
    public List<Product> CategoryProduct
    {
        get
        {
            return DataWorker.GetAllProductsByCategoryId(Id);
        }
    }
}