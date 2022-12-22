using System;
using ManageGoodsApp.View;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using ManageGoodsApp.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Validation = ManageGoodsApp.Model.Validation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace ManageGoodsApp.ViewModel;

public class DataManage : INotifyPropertyChanged
{
    #region GET ALL OBJECTS

    private List<Product> allProducts = DataWorker.GetAllProducts();
    public List<Product> AllProducts
    {
        get { return allProducts; }
        set
        {
            allProducts = value;
            NotifyPropertyChanged("AllProducts");
        }
    }

    private List<Category> allCategories = DataWorker.GetAllCategories();
    public List<Category> AllCategories
    {
        get { return allCategories; }
        set
        {
            allCategories = value;
            NotifyPropertyChanged("AllCategories");
        }
    }

    private List<Supplier> allSuppliers = DataWorker.GetAllSuppliers();
    public List<Supplier> AllSuppliers
    {
        get { return allSuppliers; }
        set
        {
            allSuppliers = value;
            NotifyPropertyChanged("AllSuppliers");
        }
    }

    private List<Supply> allSupplies = DataWorker.GetAllSupplies();
    public List<Supply> AllSupplies
    {
        get { return allSupplies; }
        set
        {
            allSupplies = value;
            NotifyPropertyChanged("AllSupplies");
        }
    }

    private List<Warehouse> allWarehouses = DataWorker.GetAllWarehouses();
    public List<Warehouse> AllWarehouses
    {
        get { return allWarehouses; }
        set
        {
            allWarehouses = value;
            NotifyPropertyChanged("AllWarehouses");
        }
    }

    private List<User> allUsers = DataWorker.GetAllUsers();
    public List<User> AllUsers
    {
        get { return allUsers; }
        set
        {
            allUsers = value;
            NotifyPropertyChanged("AllUsers");
        }
    }

    private List<Role> allRoles = DataWorker.GetAllRoles();
    public List<Role> AllRoles
    {
        get { return allRoles; }
        set
        {
            allRoles = value;
            NotifyPropertyChanged("AllRoles");
        }
    }

    private List<Audit> allLogs = DataWorker.GetAllLogs();
    public List<Audit> AllLogs
    {
        get { return allLogs; }
        set
        {
            allLogs = value;
            NotifyPropertyChanged("AllLogs");
        }
    }

    #endregion

    #region MODELS PROPERTIES

    // Product properties
    public static string ProductName { get; set; }
    public static Category ProductCategory { get; set; }
    public static Warehouse ProductWarehouse { get; set; }
    public static string ProductBarcode { get; set; }
    public static string ProductWeight { get; set; }
    public static int ProductCount { get; set; }
    public static double ProductPrice { get; set; }
    public static int ProductDiscount { get; set; }

    // Category properties
    public static string CategoryName { get; set; }

    // Warehouse properties
    public static string WarehouseName { get; set; }
    public static string WarehouseAddress { get; set; }
    public static string WarehousePhone { get; set; }

    // Supplier properties
    public static string SupplierName { get; set; }
    public static string SupplierPhysicalAddress { get; set; }
    public static string SupplierLegalAddress { get; set; }
    public static string SupplierTabIdentificationNumber { get; set; }
    public static string SupplierPhone { get; set; }
    public static string SupplierEmail { get; set; }

    // Supply properties
    public static Product SupplyProduct { get; set; }
    public static int SupplyCount { get; set; }
    public static Warehouse SupplyWarehouse { get; set; }
    public static DateTime? SupplyDepartureDate { get; set; }
    public static DateTime? SupplyArrivalDate { get; set; }

    // User properties
    public static string UserName { get; set; }
    public static string UserSurname { get; set; }
    public static string UserPatronymic { get; set; }
    public static string UserEmail { get; set; }
    public static string UserPhone { get; set; }
    public static string UserLogin { get; set; }
    public static string UserPassword { get; set; }
    public static Role UserRole { get; set; }
    public static Warehouse UserWarehouse { get; set; }

    // Role properties
    public static string RoleName { get; set; }

    // Audit properties
    public static string AuditName { get; set; }
    public static string AuditDescription { get; set; }
    public static User AuditUser { get; set; }

    // SelectedTabItems properties
    public TabItem SelectedTabItem { get; set; }
    public static Product SelectedProduct { get; set; }
    public static Category SelectedCategory { get; set; }
    public static Warehouse SelectedWarehouse { get; set; }
    public static Supplier SelectedSupplier{ get; set; }
    public static Supply SelectedSupply { get; set; }
    public static User SelectedUser { get; set; }
    public static Role SelectedRole { get; set; }
    public static Audit SelectedAudit { get; set; }

    #endregion

    #region COMMAND TO CREATE


    public RelayCommand addItem;
    public RelayCommand AddItem
    {
        get
        {
            return addItem = new RelayCommand(obj =>
            {
                Window wnd = obj as Window;
                string result = "";
                switch (wnd.Name)
                {
                    case "AddNewProductWnd":
                        if (Validation.IsNullString(ProductName))
                        {
                            SetRedBlockControl(wnd, "NameBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "NameBlock");
                        }
                        if (ProductCategory == null)
                        {
                            MessageBox.Show("Укажите категорию!");
                        }
                        if (ProductWarehouse == null)
                        {
                            MessageBox.Show("Укажите склад!");
                        }
                        if (Validation.IsNullString(ProductBarcode))
                        {
                            SetRedBlockControl(wnd, "BarcodeBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "BarcodeBlock");
                        }
                        if (Validation.IsNullString(ProductWeight))
                        {
                            SetRedBlockControl(wnd, "WeightBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "WeightBlock");
                        }
                        if (ProductCount == 0 || ProductCount > 100000)
                        {
                            SetRedBlockControl(wnd, "CountBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "CountBlock");
                        }
                        if (ProductPrice == 0 || ProductPrice > 100000000)
                        {
                            SetRedBlockControl(wnd, "PriceBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "PriceBlock");
                        }
                        if (!Validation.IsNullString(ProductName) &&
                            ProductCategory != null &&
                            ProductWarehouse != null &&
                            !Validation.IsNullString(ProductBarcode) &&
                            !Validation.IsNullString(ProductWeight) &&
                            ProductPrice > 0)
                        {
                            result = DataWorker.CreateProduct(ProductName, ProductCategory, ProductWarehouse, ProductBarcode, ProductWeight, ProductCount, ProductPrice, ProductDiscount);
                            UpdateAllDataView();
                            ShowMessageToUser(result);
                            SetNullValuesToProperties();
                            wnd.Close();
                        }
                        break;

                    case "AddNewCategoryWnd":
                        if (Validation.IsNullString(CategoryName))
                        {
                            SetRedBlockControl(wnd, "NameBlock");
                        }
                        else
                        {
                            result = DataWorker.CreateCategory(CategoryName);
                            UpdateAllDataView();
                            ShowMessageToUser(result);
                            SetNullValuesToProperties();
                            wnd.Close();
                        }
                        break;
                    
                    case "AddNewWarehouseWnd":
                        if (Validation.IsNullString(WarehouseName))
                        {
                            SetRedBlockControl(wnd, "NameBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "NameBlock");
                        }
                        if (Validation.IsNullString(WarehouseAddress))
                        {
                            SetRedBlockControl(wnd, "AddressBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "AddressBlock");
                        }
                        if (Validation.IsNullString(WarehousePhone))
                        {
                            SetRedBlockControl(wnd, "PhoneBlock");
                        }
                        else if (Validation.IsPhoneNumber(WarehousePhone))
                        {
                            SetDefaultBlockControl(wnd, "PhoneBlock");
                        }
                        else
                        {
                            SetRedBlockControl(wnd, "PhoneBlock");
                        }
                        if (!Validation.IsNullString(WarehouseName) &&
                            !Validation.IsNullString(WarehouseAddress) &&
                            !Validation.IsNullString(WarehousePhone) &&
                            Validation.IsPhoneNumber(WarehousePhone))
                        {
                            result = DataWorker.CreateWarehouse(WarehouseName, WarehouseAddress, WarehousePhone);
                            UpdateAllDataView();
                            ShowMessageToUser(result);
                            SetNullValuesToProperties();
                            wnd.Close();
                        }
                        break;
                    
                    case "AddNewSupplierWnd":
                        if (Validation.IsNullString(SupplierName))
                        {
                            SetRedBlockControl(wnd, "NameBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "NameBlock");
                        }
                        if (Validation.IsNullString(SupplierPhysicalAddress))
                        {
                            SetRedBlockControl(wnd, "PhysicalAddressBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "PhysicalAddressBlock");
                        }
                        if (Validation.IsNullString(SupplierLegalAddress))
                        {
                            SetRedBlockControl(wnd, "LegalAddressBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "LegalAddressBlock");
                        }
                        if (Validation.IsNullString(SupplierTabIdentificationNumber))
                        {
                            SetRedBlockControl(wnd, "TabIdentificationNumberBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "TabIdentificationNumberBlock");
                        }
                        if (Validation.IsNullString(SupplierPhone))
                        {
                            SetRedBlockControl(wnd, "PhoneBlock");
                        }
                        else if (Validation.IsPhoneNumber(SupplierPhone))
                        {
                            SetDefaultBlockControl(wnd, "PhoneBlock");
                        }
                        else
                        {
                            SetRedBlockControl(wnd, "PhoneBlock");
                        }
                        if (Validation.IsNullString(SupplierEmail))
                        {
                            SetRedBlockControl(wnd, "EmailBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "EmailBlock");
                        }
                        if (!Validation.IsNullString(SupplierName) &&
                            !Validation.IsNullString(SupplierPhysicalAddress) &&
                            !Validation.IsNullString(SupplierLegalAddress) &&
                            !Validation.IsNullString(SupplierTabIdentificationNumber) &&
                            !Validation.IsNullString(SupplierPhone) &&
                            !Validation.IsNullString(SupplierEmail))
                        {
                            result = DataWorker.CreateSupplier(SupplierName, SupplierPhysicalAddress, SupplierLegalAddress, SupplierTabIdentificationNumber, SupplierPhone, SupplierEmail);
                            UpdateAllDataView();
                            ShowMessageToUser(result);
                            SetNullValuesToProperties();
                            wnd.Close();
                        }
                        break;
                    
                    case "AddNewSupplyWnd":
                        if (SupplyProduct == null)
                        {
                            MessageBox.Show("Укажите товар!");
                        }
                        if (SupplyCount == 0)
                        {
                            SetRedBlockControl(wnd, "CountBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "CountBlock");
                        }
                        if (SupplyWarehouse == null)
                        {
                            MessageBox.Show("Укажите склад!");
                        }
                        else if (SupplyProduct != null && SupplyCount > 0)
                        {
                            result = DataWorker.CreateSupply(SupplyProduct, SupplyCount, SupplyWarehouse);
                            UpdateAllDataView();
                            ShowMessageToUser(result);
                            SetNullValuesToProperties();
                            wnd.Close();
                        }
                        break;
                    
                    case "AddNewUserWnd":
                        if (Validation.IsNullString(UserName))
                        {
                            SetRedBlockControl(wnd, "NameBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "NameBlock");
                        }
                        if (Validation.IsNullString(UserSurname))
                        {
                            SetRedBlockControl(wnd, "SurnameBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "SurnameBlock");
                        }
                        if (Validation.IsNullString(UserEmail))
                        {
                            SetRedBlockControl(wnd, "EmailBlock");
                        }
                        else if (Validation.IsValidEmail(UserEmail))
                        {
                            SetDefaultBlockControl(wnd, "EmailBlock");
                        }
                        else
                        {
                            SetRedBlockControl(wnd, "EmailBlock");
                        }
                        if (Validation.IsNullString(UserPhone))
                        {
                            SetRedBlockControl(wnd, "PhoneBlock");
                        }
                        else if (Validation.IsPhoneNumber(UserPhone))
                        {
                            SetDefaultBlockControl(wnd, "PhoneBlock");
                        }
                        else
                        {
                            SetRedBlockControl(wnd, "PhoneBlock");
                        }
                        if (Validation.IsNullString(UserLogin))
                        {
                            SetRedBlockControl(wnd, "LoginBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "LoginBlock");
                        }
                        if (Validation.IsNullString(UserPassword))
                        {
                            SetRedBlockControl(wnd, "PasswordBlock");
                        }
                        else
                        {
                            SetDefaultBlockControl(wnd, "PasswordBlock");
                        }
                        if (UserRole == null)
                        {
                            result = "Укажите роль!";
                            ShowMessageToUser(result);
                        }
                        else if (UserWarehouse == null && UserRole.Name != "Администратор")
                        {
                            result = "Укажите склад!";
                            ShowMessageToUser(result);
                        }
                        else if (!Validation.IsNullString(UserName) &&
                                 !Validation.IsNullString(UserSurname) &&
                                 !Validation.IsNullString(UserEmail) && Validation.IsValidEmail(UserEmail) &&
                                 !Validation.IsNullString(UserPhone) && Validation.IsPhoneNumber(UserPhone) &&
                                 !Validation.IsNullString(UserLogin) &&
                                 !Validation.IsNullString(UserPassword))
                        {
                            result = DataWorker.CreateUser(UserName, UserSurname, UserEmail, UserPhone, UserLogin, UserPassword, UserRole, UserWarehouse, UserPatronymic);
                            UpdateAllDataView();
                            ShowMessageToUser(result);
                            SetNullValuesToProperties();
                            wnd.Close();
                        }
                        break;
                    
                    case "AddNewRoleWnd":
                        if (Validation.IsNullString(RoleName))
                        {
                            SetRedBlockControl(wnd, "NameBlock");
                        }
                        else
                        {
                            result = DataWorker.CreateRole(RoleName);
                            UpdateAllDataView();
                            ShowMessageToUser(result);
                            SetNullValuesToProperties();
                            wnd.Close();
                        }
                        break;
                }
            });
        }
    }

    #endregion

    #region COMMAND TO EDIT

    public RelayCommand editItem;
    public RelayCommand EditItem
    {
        get
        {
            return editItem = new RelayCommand(obj =>
            {
                Window wnd = obj as Window;
                if (wnd.Name == "EditProductWnd")
                {
                    string result = DataWorker.EditProduct(SelectedProduct, ProductName, ProductCategory, ProductWarehouse, ProductBarcode, ProductWeight, ProductCount, ProductPrice, ProductDiscount);
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    ShowMessageToUser(result);
                    wnd.Close();
                }
                if (wnd.Name == "EditCategoryWnd")
                {
                    string result = DataWorker.EditCategory(SelectedCategory, CategoryName);
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    ShowMessageToUser(result);
                    wnd.Close();
                }
                if (wnd.Name == "EditWarehouseWnd")
                {
                    if (Validation.IsNullString(WarehouseName))
                    {
                        SetRedBlockControl(wnd, "NameBlock");
                    }
                    else
                    {
                        SetDefaultBlockControl(wnd, "NameBlock");
                    }
                    if (Validation.IsNullString(WarehouseAddress))
                    {
                        SetRedBlockControl(wnd, "AddressBlock");
                    }
                    else
                    {
                        SetDefaultBlockControl(wnd, "AddressBlock");
                    }
                    if (Validation.IsNullString(WarehousePhone))
                    {
                        SetRedBlockControl(wnd, "PhoneBlock");
                    }
                    else if (Validation.IsPhoneNumber(WarehousePhone))
                    {
                        SetDefaultBlockControl(wnd, "PhoneBlock");
                    }
                    else
                    {
                        SetRedBlockControl(wnd, "PhoneBlock");
                    }
                    if (!Validation.IsNullString(WarehouseName) &&
                        !Validation.IsNullString(WarehouseAddress) &&
                        !Validation.IsNullString(WarehousePhone) &&
                        Validation.IsPhoneNumber(WarehousePhone))
                    {
                        string result = DataWorker.EditWarehouse(SelectedWarehouse, WarehouseName, WarehouseAddress, WarehousePhone);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(result);
                        wnd.Close();
                    }
                }
                if (wnd.Name == "EditSupplierWnd")
                {
                    string result = DataWorker.EditSupplier(SelectedSupplier, SupplierName, SupplierPhysicalAddress, SupplierLegalAddress, SupplierTabIdentificationNumber, SupplierPhone, SupplierEmail);
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    ShowMessageToUser(result);
                    wnd.Close();
                }
                if (wnd.Name == "EditSupplyWnd")
                {
                    string result = DataWorker.EditSupply(SelectedSupply, SupplyProduct, SupplyCount, SupplyWarehouse, SupplyDepartureDate, SupplyArrivalDate);
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    ShowMessageToUser(result);
                    wnd.Close();
                }
                if (wnd.Name == "EditUserWnd")
                {
                    if (Validation.IsNullString(UserName))
                    {
                        SetRedBlockControl(wnd, "NameBlock");
                    }
                    else
                    {
                        SetDefaultBlockControl(wnd, "NameBlock");
                    }
                    if (Validation.IsNullString(UserSurname))
                    {
                        SetRedBlockControl(wnd, "SurnameBlock");
                    }
                    else
                    {
                        SetDefaultBlockControl(wnd, "SurnameBlock");
                    }
                    if (Validation.IsNullString(UserEmail))
                    {
                        SetRedBlockControl(wnd, "EmailBlock");
                    }
                    else if (Validation.IsValidEmail(UserEmail))
                    {
                        SetDefaultBlockControl(wnd, "EmailBlock");
                    }
                    else
                    {
                        SetRedBlockControl(wnd, "EmailBlock");
                    }
                    if (Validation.IsNullString(UserPhone))
                    {
                        SetRedBlockControl(wnd, "PhoneBlock");
                    }
                    else if (Validation.IsPhoneNumber(UserPhone))
                    {
                        SetDefaultBlockControl(wnd, "PhoneBlock");
                    }
                    else
                    {
                        SetRedBlockControl(wnd, "PhoneBlock");
                    }
                    if (Validation.IsNullString(UserLogin))
                    {
                        SetRedBlockControl(wnd, "LoginBlock");
                    }
                    else
                    {
                        SetDefaultBlockControl(wnd, "LoginBlock");
                    }
                    if (UserRole != null)
                    {
                        if (UserRole.Name != "Администратор" && UserWarehouse == null)
                        {
                            string result = "Укажите склад!";
                            ShowMessageToUser(result);
                        }
                        else if (!Validation.IsNullString(UserName) &&
                                 !Validation.IsNullString(UserSurname) &&
                                 !Validation.IsNullString(UserEmail) && Validation.IsValidEmail(UserEmail) &&
                                 !Validation.IsNullString(UserPhone) && Validation.IsPhoneNumber(UserPhone) &&
                                 !Validation.IsNullString(UserLogin))
                        {
                            string result = DataWorker.EditUser(SelectedUser, UserName, UserSurname, UserEmail, UserPhone, UserLogin, UserRole, UserWarehouse, UserPatronymic, UserPassword);
                            UpdateAllDataView();
                            SetNullValuesToProperties();
                            ShowMessageToUser(result);
                            wnd.Close();
                        }
                    }
                    else if (!Validation.IsNullString(UserName) &&
                             !Validation.IsNullString(UserSurname) &&
                             !Validation.IsNullString(UserEmail) && Validation.IsValidEmail(UserEmail) &&
                             !Validation.IsNullString(UserPhone) && Validation.IsPhoneNumber(UserPhone) &&
                             !Validation.IsNullString(UserLogin))
                    {
                        string result = DataWorker.EditUser(SelectedUser, UserName, UserSurname, UserEmail, UserPhone, UserLogin, UserRole, UserWarehouse, UserPatronymic, UserPassword);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(result);
                        wnd.Close();
                    }
                }
                if (wnd.Name == "EditRoleWnd")
                {
                    string result = DataWorker.EditRole(SelectedRole, RoleName);
                    UpdateAllDataView();
                    SetNullValuesToProperties();
                    ShowMessageToUser(result);
                    wnd.Close();
                }
            });
        }
    }

    #endregion

    #region COMMAND TO DELETE

    private RelayCommand deleteItem;
    public RelayCommand DeleteItem
    {
        get
        {
            return deleteItem = new RelayCommand(obj =>
            {
                string result = "Ничего не выбрано!";
                if (SelectedTabItem.Name == "ProductsTabItem" && SelectedProduct != null)
                {
                    result = DataWorker.DeleteProduct(SelectedProduct);
                    UpdateAllDataView();
                }
                if (SelectedTabItem.Name == "CategoriesTabItem" && SelectedCategory != null)
                {
                    result = DataWorker.DeleteCategory(SelectedCategory);
                    UpdateAllDataView();
                }
                if (SelectedTabItem.Name == "WarehousesTabItem" && SelectedWarehouse != null)
                {
                    result = DataWorker.DeleteWarehouse(SelectedWarehouse);
                    UpdateAllDataView();
                }
                if (SelectedTabItem.Name == "SuppliersTabItem" && SelectedSupplier != null)
                {
                    result = DataWorker.DeleteSupplier(SelectedSupplier);
                    UpdateAllDataView();
                }
                if (SelectedTabItem.Name == "SuppliesTabItem" && SelectedSupply != null)
                {
                    result = DataWorker.DeleteSupply(SelectedSupply);
                    UpdateAllDataView();
                }
                if (SelectedTabItem.Name == "UsersTabItem" && SelectedUser != null)
                {
                    result = DataWorker.DeleteUser(SelectedUser);
                    UpdateAllDataView();
                }
                if (SelectedTabItem.Name == "RolesTabItem" && SelectedRole != null)
                {
                    result = DataWorker.DeleteRole(SelectedRole);
                    UpdateAllDataView();
                }
                SetNullValuesToProperties();
                ShowMessageToUser(result);
            });
        }
    }

    #endregion

    #region COMMANDS TO OPEN WINDOWS

    private RelayCommand openAddNewProductWnd;
    public RelayCommand OpenAddNewProductWnd
    {
        get
        {
            return openAddNewProductWnd = new RelayCommand(obj =>
            {
                OpenAddProductWindowsMethod();
            });
        }
    }

    private RelayCommand openAddNewCategoryWnd;
    public RelayCommand OpenAddNewCategoryWnd
    {
        get
        {
            return openAddNewCategoryWnd = new RelayCommand(obj =>
            {
                OpenAddCategoryWindowsMethod();
            });
        }
    }

    private RelayCommand openAddNewWarehouseWnd;
    public RelayCommand OpenAddNewWarehouseWnd
    {
        get
        {
            return openAddNewWarehouseWnd = new RelayCommand(obj =>
            {
                OpenAddWarehouseWindowsMethod();
            });
        }
    }

    private RelayCommand openAddNewSupplierWnd;
    public RelayCommand OpenAddNewSupplierWnd
    {
        get
        {
            return openAddNewSupplierWnd = new RelayCommand(obj =>
            {
                OpenAddSupplierWindowsMethod();
            });
        }
    }

    private RelayCommand openAddNewSupplyWnd;
    public RelayCommand OpenAddNewSupplyWnd
    {
        get
        {
            return openAddNewSupplyWnd = new RelayCommand(obj =>
            {
                OpenAddSupplyWindowsMethod();
            });
        }
    }

    private RelayCommand openAddNewUserWnd;
    public RelayCommand OpenAddNewUserWnd
    {
        get
        {
            return openAddNewUserWnd = new RelayCommand(obj =>
            {
                OpenAddUserWindowsMethod();
            });
        }
    }

    private RelayCommand openAddNewRoleWnd;
    public RelayCommand OpenAddNewRoleWnd
    {
        get
        {
            return openAddNewRoleWnd = new RelayCommand(obj =>
            {
                OpenAddRoleWindowsMethod();
            });
        }
    }

    private RelayCommand openAddItem;
    public RelayCommand OpenAddItem
    {
        get
        {
            return openAddItem = new RelayCommand(obj =>
            {
                if (SelectedTabItem.Name == "ProductsTabItem")
                {
                    OpenAddProductWindowsMethod();
                }
                if (SelectedTabItem.Name == "CategoriesTabItem")
                {
                    OpenAddCategoryWindowsMethod();
                }
                if (SelectedTabItem.Name == "WarehousesTabItem")
                {
                    OpenAddWarehouseWindowsMethod();
                }
                if (SelectedTabItem.Name == "SuppliersTabItem")
                {
                    OpenAddSupplierWindowsMethod();
                }
                if (SelectedTabItem.Name == "SuppliesTabItem")
                {
                    OpenAddSupplyWindowsMethod();
                }
                if (SelectedTabItem.Name == "UsersTabItem")
                {
                    OpenAddUserWindowsMethod();
                }
                if (SelectedTabItem.Name == "RolesTabItem")
                {
                    OpenAddRoleWindowsMethod();
                }
            });
        }
    }

    private RelayCommand openEditItem;
    public RelayCommand OpenEditItem
    {
        get
        {
            return openEditItem = new RelayCommand(obj =>
            {
                if (SelectedTabItem.Name == "ProductsTabItem" && SelectedProduct != null)
                {
                    OpenEditProductWindowsMethod(SelectedProduct);
                }
                else if (SelectedTabItem.Name == "ProductsTabItem" && SelectedProduct == null)
                {
                    string result = "Не выбран товар!";
                    ShowMessageToUser(result);
                }
                if (SelectedTabItem.Name == "CategoriesTabItem" && SelectedCategory != null)
                {
                    OpenEditCategoryWindowsMethod(SelectedCategory);
                }
                else if (SelectedTabItem.Name == "CategoriesTabItem" && SelectedCategory == null)
                {
                    string result = "Не выбрана категория!";
                    ShowMessageToUser(result);
                }
                if (SelectedTabItem.Name == "WarehousesTabItem" && SelectedWarehouse != null)
                {
                    OpenEditWarehouseWindowsMethod(SelectedWarehouse);
                }
                else if (SelectedTabItem.Name == "WarehousesTabItem" && SelectedWarehouse == null)
                {
                    string result = "Не выбран склад!";
                    ShowMessageToUser(result);
                }
                if (SelectedTabItem.Name == "SuppliersTabItem" && SelectedSupplier != null)
                {
                    OpenEditSupplierWindowsMethod(SelectedSupplier);
                }
                else if (SelectedTabItem.Name == "SuppliersTabItem" && SelectedSupplier == null)
                {
                    string result = "Не выбран поставщик!";
                    ShowMessageToUser(result);
                }
                if (SelectedTabItem.Name == "SuppliesTabItem" && SelectedSupply != null)
                {
                    OpenEditSupplyWindowsMethod(SelectedSupply);
                }
                else if (SelectedTabItem.Name == "SuppliesTabItem" && SelectedSupply == null)
                {
                    string result = "Не выбрана поставка!";
                    ShowMessageToUser(result);
                }
                if (SelectedTabItem.Name == "UsersTabItem" && SelectedUser != null)
                {
                    OpenEditUserWindowsMethod(SelectedUser);
                }
                else if (SelectedTabItem.Name == "UsersTabItem" && SelectedUser == null)
                {
                    string result = "Не выбран пользователь!";
                    ShowMessageToUser(result);
                }
                if (SelectedTabItem.Name == "RolesTabItem" && SelectedRole != null)
                {
                    OpenEditRoleWindowsMethod(SelectedRole);
                }
                else if (SelectedTabItem.Name == "RolesTabItem" && SelectedRole == null)
                {
                    string result = "Не выбрана роль!";
                    ShowMessageToUser(result);
                }
            });
        }
    }

    #endregion

    #region METHODS TO OPEN WINDOWS

    #region OPEN ADD WINDOWS METHODS

    private void OpenAddProductWindowsMethod()
    {
        AddNewProductWindow window = new();
        SetCenterPositionAndOpen(window);
    }

    private void OpenAddCategoryWindowsMethod()
    {
        AddNewCategoryWindow window = new();
        SetCenterPositionAndOpen(window);
    }

    private void OpenAddWarehouseWindowsMethod()
    {
        AddNewWarehouseWindow window = new();
        SetCenterPositionAndOpen(window);
    }

    private void OpenAddSupplierWindowsMethod()
    {
        AddNewSupplierWindow window = new();
        SetCenterPositionAndOpen(window);
    }

    private void OpenAddSupplyWindowsMethod()
    {
        AddNewSupplyWindow window = new();
        SetCenterPositionAndOpen(window);
    }

    private void OpenAddUserWindowsMethod()
    {
        AddNewUserWindow window = new();
        SetCenterPositionAndOpen(window);
    }

    private void OpenAddRoleWindowsMethod()
    {
        AddNewRoleWindow window = new();
        SetCenterPositionAndOpen(window);
    }

    #endregion

    #region OPEN EDIT WINDOWS METHODS

    private void OpenEditProductWindowsMethod(Product product)
    {
        EditProductWindow window = new(product);
        SetCenterPositionAndOpen(window);
    }

    private void OpenEditCategoryWindowsMethod(Category category)
    {
        EditCategoryWindow window = new(category);
        SetCenterPositionAndOpen(window);
    }

    private void OpenEditWarehouseWindowsMethod(Warehouse warehouse)
    {
        EditWarehouseWindow window = new(warehouse);
        SetCenterPositionAndOpen(window);
    }

    private void OpenEditSupplierWindowsMethod(Supplier supplier)
    {
        EditSupplierWindow window = new(supplier);
        SetCenterPositionAndOpen(window);
    }

    private void OpenEditSupplyWindowsMethod(Supply supply)
    {
        EditSupplyWindow window = new(supply);
        SetCenterPositionAndOpen(window);
    }

    private void OpenEditUserWindowsMethod(User user)
    {
        EditUserWindow window = new(user);
        SetCenterPositionAndOpen(window);
    }

    private void OpenEditRoleWindowsMethod(Role role)
    {
        EditRoleWindow window = new(role);
        SetCenterPositionAndOpen(window);
    }

    #endregion

    private void SetCenterPositionAndOpen(Window window)
    {
        window.Owner = Application.Current.MainWindow;
        window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        window.ShowDialog();
    }

    #endregion

    #region UPDATE VIEWS

    private void UpdateAllDataView()
    {
        UpdateAllProductsView();
        UpdateAllCategoriesView();
        UpdateAllWarehousesView();
        UpdateAllSuppliersView();
        UpdateAllSuppliesView();
        UpdateAllUsersView();
        UpdateAllRolesView();
        UpdateAllLogsView();
    }

    private void SetNullValuesToProperties()
    {
        // Product properties
        ProductName = null;
        ProductCategory = null;
        ProductWarehouse = null;
        ProductBarcode = null;
        ProductWeight = null;
        ProductCount = 0;
        ProductPrice = 0;
        ProductDiscount = 0;

        // Category properties
        CategoryName = null;

        // Warehouse properties
        WarehouseName = null;
        WarehouseAddress = null;
        WarehousePhone = null;

        // Supplier properties
        SupplierName = null;
        SupplierPhysicalAddress = null;
        SupplierLegalAddress = null;
        SupplierTabIdentificationNumber = null;
        SupplierPhone = null;
        SupplierEmail = null;

        // Supply properties
        SupplyProduct = null;
        SupplyCount = 0;
        SupplyWarehouse = null;
        SupplyDepartureDate = null;
        SupplyArrivalDate = null;

        // User properties
        UserName = null;
        UserSurname = null;
        UserPatronymic = null;
        UserEmail = null;
        UserPhone = null;
        UserLogin = null;
        UserPassword = null;
        UserRole = null;
        UserWarehouse = null;

        // Role properties
        RoleName = null;

        // Audit properties
        AuditName = null;
        AuditDescription = null;
        AuditUser = null;
    }

    private void UpdateAllProductsView()
    {
        AllProducts = DataWorker.GetAllProducts();
        MainWindow.AllProductsView.ItemsSource = null;
        MainWindow.AllProductsView.Items.Clear();
        MainWindow.AllProductsView.ItemsSource = AllProducts;
        MainWindow.AllProductsView.Items.Refresh();
    }

    private void UpdateAllCategoriesView()
    {
        AllCategories = DataWorker.GetAllCategories();
        MainWindow.AllCategoriesView.ItemsSource = null;
        MainWindow.AllCategoriesView.Items.Clear();
        MainWindow.AllCategoriesView.ItemsSource = AllCategories;
        MainWindow.AllCategoriesView.Items.Refresh();
    }

    private void UpdateAllWarehousesView()
    {
        AllWarehouses = DataWorker.GetAllWarehouses();
        MainWindow.AllWarehousesView.ItemsSource = null;
        MainWindow.AllWarehousesView.Items.Clear();
        MainWindow.AllWarehousesView.ItemsSource = AllWarehouses;
        MainWindow.AllWarehousesView.Items.Refresh();
    }

    private void UpdateAllSuppliersView()
    {
        AllSuppliers = DataWorker.GetAllSuppliers();
        MainWindow.AllSuppliersView.ItemsSource = null;
        MainWindow.AllSuppliersView.Items.Clear();
        MainWindow.AllSuppliersView.ItemsSource = AllSuppliers;
        MainWindow.AllSuppliersView.Items.Refresh();
    }

    private void UpdateAllSuppliesView()
    {
        AllSupplies = DataWorker.GetAllSupplies();
        MainWindow.AllSuppliesView.ItemsSource = null;
        MainWindow.AllSuppliesView.Items.Clear();
        MainWindow.AllSuppliesView.ItemsSource = AllSupplies;
        MainWindow.AllSuppliesView.Items.Refresh();
    }

    private void UpdateAllUsersView()
    {
        AllUsers = DataWorker.GetAllUsers();
        MainWindow.AllUsersView.ItemsSource = null;
        MainWindow.AllUsersView.Items.Clear();
        MainWindow.AllUsersView.ItemsSource = AllUsers;
        MainWindow.AllUsersView.Items.Refresh();
    }

    private void UpdateAllRolesView()
    {
        AllRoles = DataWorker.GetAllRoles();
        MainWindow.AllRolesView.ItemsSource = null;
        MainWindow.AllRolesView.Items.Clear();
        MainWindow.AllRolesView.ItemsSource = AllRoles;
        MainWindow.AllRolesView.Items.Refresh();
    }

    private void UpdateAllLogsView()
    {
        AllLogs = DataWorker.GetAllLogs();
        MainWindow.AllLogsView.ItemsSource = null;
        MainWindow.AllLogsView.Items.Clear();
        MainWindow.AllLogsView.ItemsSource = AllLogs;
        MainWindow.AllLogsView.Items.Refresh();
    }

    #endregion

    #region VALIDATION OF REQUIRED TEXTBOXES

    private void SetRedBlockControl(Window wnd, string blockName)
    {
        Control block = wnd.FindName(blockName) as Control;
        block.BorderBrush = Brushes.Red;
    }

    private void SetDefaultBlockControl(Window wnd, string blockName)
    {
        Control block = wnd.FindName(blockName) as Control;
        block.ClearValue(TextBox.BorderBrushProperty);
    }

    private void ShowMessageToUser(string message)
    {
        MessageView messageView = new MessageView(message);
        SetCenterPositionAndOpen(messageView);
    }

    #endregion

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}