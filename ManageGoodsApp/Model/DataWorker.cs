using System;
using System.Collections.Generic;
using System.Linq;
using ManageGoodsApp.Model;
using ManageGoodsApp.Model.Data;

namespace ManageGoodsApp.Model;

public static class DataWorker
{
    #region CREATE

    public static string CreateProduct(string name, Category category, Warehouse warehouse, int count, double price, int discount)
    {
        string result = "Уже существует!";
        using ApplicationContext db = new();
        // Check exist
        bool checkIsExist = db.Products.Any(el => el.Name == name);
        if (!checkIsExist)
        {
            Product newProduct = new()
            {
                Name = name,
                CategoryId = category.Id,
                WarehouseId = warehouse.Id,
                Count = count,
                Price = price,
                Discount = discount
            };
            db.Products.Add(newProduct);
            db.SaveChanges();
            result = "Добавлено!";
        }
        return result;
    }

    public static string CreateCategory(string name)
    {
        string result = "Уже существует!";
        using ApplicationContext db = new();
        // Check exist
        bool checkIsExist = db.Categories.Any(el => el.Name == name);
        if (!checkIsExist)
        {
            Category newCategory = new()
            {
                Name = name
            };
            db.Categories.Add(newCategory);
            db.SaveChanges();
            result = "Добавлено!";
        }
        return result;
    }

    public static string CreateWarehouse(string name, string address, string phone)
    {
        string result = "Уже существует!";
        using ApplicationContext db = new();
        // Check exist
        bool checkIsExist = db.Warehouses.Any(el => el.Name == name);
        if (!checkIsExist)
        {
            Warehouse newWarehouse = new()
            {
                Name = name,
                Address = address,
                Phone = phone
            };
            db.Warehouses.Add(newWarehouse);
            db.SaveChanges();
            result = "Добавлено!";
        }
        return result;
    }

    public static string CreateSupplier(string name, string address, string taxIdentificationNumber, string phone)
    {
        string result = "Уже существует!";
        using ApplicationContext db = new();
        // Check exist
        bool checkIsExist = db.Suppliers.Any(el => el.Name == name && el.TaxIdentificationNumber == taxIdentificationNumber);
        if (!checkIsExist)
        {
            Supplier newSupplier = new()
            {
                Name = name,
                Address = address,
                TaxIdentificationNumber = taxIdentificationNumber,
                Phone = phone
            };
            db.Suppliers.Add(newSupplier);
            db.SaveChanges();
            result = "Добавлено!";
        }
        return result;
    }

    public static string CreateSupply(Product product, int count, Warehouse warehouse)
    {
        string result = "Уже существует!";
        using ApplicationContext db = new();
        // Check exist
        DateTime currentDate = DateTime.Today;
        bool checkIsExist = db.Supplies.Any(el => el.ProductId == product.Id && el.WarehouseId == warehouse.Id && el.DepartureDate == currentDate);
        if (!checkIsExist)
        {
            Supply newSupply = new()
            {
                ProductId = product.Id,
                Count = count,
                WarehouseId = warehouse.Id,
                DepartureDate = currentDate
            };
            db.Supplies.Add(newSupply);
            db.SaveChanges();
            result = "Добавлено!";
        }
        return result;
    }

    public static string CreateUser(string name, string surname, string patronymic, string email, string phone, string login, string password, Role role, Warehouse warehouse)
    {
        string result = "Уже существует!";
        using ApplicationContext db = new();
        // Check exist
        bool checkIsExist = db.Users.Any(el => el.Email == email && el.Phone == phone && el.Login == login);
        if (!checkIsExist)
        {
            User newUser = new()
            {
                Name = name,
                Surname = surname,
                Patronymic = patronymic,
                Email = email,
                Phone = phone,
                Login = login,
                Password = Validation.CreateHash(password),
                RoleId = role.Id,
                WarehouseId = warehouse.Id
            };
            db.Users.Add(newUser);
            db.SaveChanges();
            result = "Добавлено!";
        }
        return result;
    }

    public static string CreateRole(string name)
    {
        string result = "Уже существует!";
        using ApplicationContext db = new();
        // Check exist
        bool checkIsExist = db.Roles.Any(el => el.Name == name);
        if (!checkIsExist)
        {
            Role newRole = new()
            {
                Name = name
            };
            db.Roles.Add(newRole);
            db.SaveChanges();
            result = "Добавлено!";
        }
        return result;
    }

    #endregion

    #region READ

    #region GET ALL

    public static List<Product> GetAllProducts()
    {
        using ApplicationContext db = new();
        var result = db.Products.ToList();
        return result;
    }

    public static List<Category> GetAllCategories()
    {
        using ApplicationContext db = new ApplicationContext();
        var result = db.Categories.ToList();
        return result;
    }

    public static List<Warehouse> GetAllWarehouses()
    {
        using ApplicationContext db = new();
        var result = db.Warehouses.ToList();
        return result;
    }

    public static List<Supplier> GetAllSuppliers()
    {
        using ApplicationContext db = new();
        var result = db.Suppliers.ToList();
        return result;
    }

    public static List<Supply> GetAllSupplies()
    {
        using ApplicationContext db = new();
        var result = db.Supplies.ToList();
        return result;
    }

    public static List<User> GetAllUsers()
    {
        using ApplicationContext db = new();
        var result = db.Users.ToList();
        return result;
    }

    public static List<Role> GetAllRoles()
    {
        using ApplicationContext db = new();
        var result = db.Roles.ToList();
        return result;
    }

    public static List<Audit> GetAllLogs()
    {
        using ApplicationContext db = new();
        var result = db.Audit.ToList();
        return result;
    }

    #endregion

    #region GET BY ID

    public static Product GetProductById(int id)
    {
        using ApplicationContext db = new();
        Product product = db.Products.FirstOrDefault(x => x.Id == id);
        return product;
    }

    public static Category GetCategoryById(int id)
    {
        using ApplicationContext db = new();
        Category category = db.Categories.FirstOrDefault(p => p.Id == id);
        return category;
    }

    public static Supplier GetSupplierById(int id)
    {
        using ApplicationContext db = new();
        Supplier supplier = db.Suppliers.FirstOrDefault(p => p.Id == id);
        return supplier;
    }

    public static Warehouse GetWarehouseById(int? id)
    {
        using ApplicationContext db = new();
        Warehouse warehouse = db.Warehouses.FirstOrDefault(p => p.Id == id);
        return warehouse;
    }

    public static Role GetRoleById(int id)
    {
        using ApplicationContext db = new();
        Role role = db.Roles.FirstOrDefault(p => p.Id == id);
        return role;
    }

    public static User GetUserById(int? id)
    {
        using ApplicationContext db = new();
        User user = db.Users.FirstOrDefault(p => p.Id == id);
        return user;
    }

    #endregion

    #region GET ALL BY ID

    public static List<Product> GetAllProductsByCategoryId(int categoryId)
    {
        using ApplicationContext db = new();
        List<Product> products = (from product in GetAllProducts() where product.CategoryId == categoryId select product).ToList();
        return products;
    }

    public static List<Supply> GetAllSuppliesBySupplierId(int supplierId)
    {
        using ApplicationContext db = new();
        List<Supply> supplies = (from supply in GetAllSupplies() where supply.SupplierId == supplierId select supply).ToList();
        return supplies;
    }

    public static List<User> GetAllUsersByRoleId(int roleId)
    {
        using ApplicationContext db = new();
        List<User> users = (from user in GetAllUsers() where user.RoleId == roleId select user).ToList();
        return users;
    }

    #endregion

    #endregion

    #region UPDATE

    public static string EditProduct(Product oldProduct, string newName, Category newCategory, Warehouse newWarehouse, int newCount, double newPrice, int newDiscount)
    {
        string result = "Такого товара не существует!";
        using ApplicationContext db = new();
        Product product = db.Products.FirstOrDefault(d => d.Id == oldProduct.Id);
        product.Name = newName;
        product.CategoryId = newCategory.Id;
        product.WarehouseId = newWarehouse.Id;
        product.Count = newCount;
        product.Price = newPrice;
        product.Discount = newDiscount;
        db.SaveChanges();
        result = "Сделано! Товар " + product.Name + " изменён.";
        return result;
    }

    public static string EditCategory(Category oldCategory, string newName)
    {
        string result = "Такой категории не существует!";
        using ApplicationContext db = new();
        Category category = db.Categories.FirstOrDefault(d => d.Id == oldCategory.Id);
        category.Name = newName;
        db.SaveChanges();
        result = "Сделано! Категория " + category.Name + " изменена.";
        return result;
    }

    public static string EditWarehouse(Warehouse oldWarehouse, string newName, string newAddress, string newPhone)
    {
        string result = "Такого склада не существует!";
        using ApplicationContext db = new();
        Warehouse warehouse = db.Warehouses.FirstOrDefault(d => d.Id == oldWarehouse.Id);
        warehouse.Name = newName;
        warehouse.Address = newAddress;
        warehouse.Phone = newPhone;
        db.SaveChanges();
        result = "Сделано! Склад " + warehouse.Name + " изменён.";
        return result;
    }

    public static string EditSupplier(Supplier oldSupplier, string newName, string newAddress, string newTaxIdentificationNumber, string newPhone)
    {
        string result = "Такого поставщика не существует!";
        using ApplicationContext db = new();
        Supplier supplier = db.Suppliers.FirstOrDefault(d => d.Id == oldSupplier.Id);
        supplier.Name = newName;
        supplier.Address = newAddress;
        supplier.TaxIdentificationNumber = newTaxIdentificationNumber;
        supplier.Phone = newPhone;
        db.SaveChanges();
        result = "Сделано! Поставщик " + supplier.Name + " изменён.";
        return result;
    }

    public static string EditSupply(Supply oldSupply, Product newProduct, int newCount, Warehouse newWarehouse)
    {
        string result = "Такой поставки не существует!";
        using ApplicationContext db = new();
        Supply supply = db.Supplies.FirstOrDefault(d => d.Id == oldSupply.Id);
        supply.ProductId = newProduct.Id;
        supply.Count = newCount;
        supply.WarehouseId = newWarehouse.Id;
        db.SaveChanges();
        result = "Сделано! Поставка " + supply.Id + " изменена.";
        return result;
    }

    public static string EditUser(User oldUser, string newName, string newSurname, string newPatronymic, string newEmail, string newPhone, string newLogin, string newPassword, Role newRole, Warehouse newWarehouse)
    {
        string result = "Такого пользователя не существует!";
        using ApplicationContext db = new();
        User user = db.Users.FirstOrDefault(d => d.Id == oldUser.Id);
        user.Name = newName;
        user.Surname = newSurname;
        user.Patronymic = newPatronymic;
        user.Email = newEmail;
        user.Phone = newPhone;
        user.Login = newLogin;
        user.Password = Validation.CreateHash(newPassword);
        user.RoleId = newRole.Id;
        user.WarehouseId = newWarehouse.Id;
        db.SaveChanges();
        result = "Сделано! Пользователь " + user.Login + " изменён.";
        return result;
    }

    public static string EditRole(Role oldRole, string newName)
    {
        string result = "Такой роли не существует!";
        using ApplicationContext db = new();
        Role role = db.Roles.FirstOrDefault(d => d.Id == oldRole.Id);
        role.Name = newName;
        db.SaveChanges();
        result = "Сделано! Роль " + role.Name + " изменена.";
        return result;
    }

    #endregion

    #region DELETE

    public static string DeleteProduct(Product product)
    {
        string result = "Такого товара не существует!";
        using ApplicationContext db = new();
        db.Products.Remove(product);
        db.SaveChanges();
        result = "Сделано! Товар " + product.Name + " удалён!";
        return result;
    }

    public static string DeleteCategory(Category category)
    {
        string result = "Такой категории не существует!";
        using ApplicationContext db = new();
        db.Categories.Remove(category);
        db.SaveChanges();
        result = "Сделано! Категория " + category.Name + " удалена!";
        return result;
    }

    public static string DeleteWarehouse(Warehouse warehouse)
    {
        string result = "Такого склада не существует!";
        using ApplicationContext db = new();
        db.Warehouses.Remove(warehouse);
        db.SaveChanges();
        result = "Сделано! Склад " + warehouse.Name + " удалён!";
        return result;
    }

    public static string DeleteSupplier(Supplier supplier)
    {
        string result = "Такого поставщика не существует!";
        using ApplicationContext db = new();
        db.Suppliers.Remove(supplier);
        db.SaveChanges();
        result = "Сделано! Поставщик " + supplier.Name + " удалён!";
        return result;
    }

    public static string DeleteSupply(Supply supply)
    {
        string result = "Такой поставки не существует!";
        using ApplicationContext db = new();
        db.Supplies.Remove(supply);
        db.SaveChanges();
        result = "Сделано! Поставка №" + supply.Id + " удалена!";
        return result;
    }

    public static string DeleteUser(User user)
    {
        string result = "Такого пользователя не существует!";
        using ApplicationContext db = new();
        db.Users.Remove(user);
        db.SaveChanges();
        result = "Сделано! Пользователь " + user.Login + " удалён!";
        return result;
    }

    public static string DeleteRole(Role role)
    {
        string result = "Такой роли не существует!";
        using ApplicationContext db = new();
        db.Roles.Remove(role);
        db.SaveChanges();
        result = "Сделано! Роль " + role.Name + " удалена!";
        return result;
    }

    #endregion
}