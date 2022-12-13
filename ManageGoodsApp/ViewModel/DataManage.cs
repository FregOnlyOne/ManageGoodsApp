using System;
using ManageGoodsApp.View;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using ManageGoodsApp.Model;
using System.Collections.Generic;

namespace ManageGoodsApp.ViewModel;

public class DataManage : INotifyPropertyChanged
{
    #region GET ALL OBJECTS

    private List<Product> allProducts= DataWorker.GetAllProducts();
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
    public static string SupplierAddress { get; set; }
    public static string SupplierTabIdentificationNumber { get; set; }
    public static string SupplierPhone { get; set; }

    // Supply properties
    public static Product SupplyProduct { get; set; }
    public static int SupplyCount { get; set; }
    public static Warehouse SupplyWarehouse { get; set; }

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
            return addItem ?? new RelayCommand(obj =>
            {
                Window wnd = obj as Window;
                string result = "";
                if (wnd.Name == "AddNewProductWnd")
                {
                    if (ProductName == null || ProductName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "NameBlock");
                    }
                    if (ProductCategory == null)
                    {
                        MessageBox.Show("Укажите категорию!");
                    }
                    if (ProductWarehouse == null)
                    {
                        MessageBox.Show("Укажите склад!");
                    }
                    if (ProductCount == 0)
                    {
                        SetRedBlockControl(wnd, "CountBlock");
                    }
                    if (ProductPrice == 0)
                    {
                        SetRedBlockControl(wnd, "PriceBlock");
                    }
                    else
                    {
                        result = DataWorker.CreateProduct(ProductName, ProductCategory, ProductWarehouse, ProductCount, ProductPrice, ProductDiscount);
                        UpdateAllDataView();
                        ShowMessageToUser(result);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                if (wnd.Name == "AddNewCategoryWnd")
                {
                    if (CategoryName == null || CategoryName.Replace(" ", "").Length == 0)
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
                }
                if (wnd.Name == "AddNewWarehouseWnd")
                {
                    if (WarehouseName == null || WarehouseName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "NameBlock");
                    }
                    if (WarehouseAddress == null || WarehouseAddress.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "AddressBlock");
                    }
                    if (WarehousePhone == null || WarehousePhone.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "PhoneBlock");
                    }
                    else
                    {
                        result = DataWorker.CreateWarehouse(WarehouseName, WarehouseAddress, WarehousePhone);
                        UpdateAllDataView();
                        ShowMessageToUser(result);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                if (wnd.Name == "AddNewSupplierWnd")
                {
                    if (SupplierName == null || SupplierName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "NameBlock");
                    }
                    if (SupplierAddress == null || SupplierAddress.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "AddressBlock");
                    }
                    if (SupplierTabIdentificationNumber == null || SupplierTabIdentificationNumber.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "TabIdentificationNumberBlock");
                    }
                    if (SupplierPhone == null || SupplierPhone.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "PhoneBlock");
                    }
                    else
                    {
                        result = DataWorker.CreateSupplier(SupplierName, SupplierAddress, SupplierTabIdentificationNumber, SupplierPhone);
                        UpdateAllDataView();
                        ShowMessageToUser(result);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                if (wnd.Name == "AddNewSupplyWnd")
                {
                    if (SupplyProduct == null)
                    {
                        MessageBox.Show("Укажите товар!");
                    }
                    if (SupplyCount == 0)
                    {
                        SetRedBlockControl(wnd, "AddressBlock");
                    }
                    if (SupplyWarehouse == null)
                    {
                        MessageBox.Show("Укажите склад!");
                    }
                    else
                    {
                        result = DataWorker.CreateSupply(SupplyProduct, SupplyCount, SupplyWarehouse);
                        UpdateAllDataView();
                        ShowMessageToUser(result);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                if (wnd.Name == "AddNewUserWnd")
                {
                    if (UserName == null || UserName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "NameBlock");
                    }
                    if (UserSurname == null || UserSurname.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "SurnameBlock");
                    }
                    if (UserPatronymic == null || UserPatronymic.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "PatronymicBlock");
                    }
                    if (UserEmail == null || UserEmail.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "EmailBlock");
                    }
                    if (UserPhone == null || UserPhone.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "PhoneBlock");
                    }
                    if (UserLogin == null || UserLogin.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "LoginBlock");
                    }
                    if (UserPassword == null || UserPassword.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "PasswordBlock");
                    }
                    if (UserRole == null)
                    {
                        MessageBox.Show("Укажите роль!");
                    }
                    if (UserWarehouse == null)
                    {
                        MessageBox.Show("Укажите склад!");
                    }
                    else
                    {
                        result = DataWorker.CreateUser(UserName, UserSurname, UserPatronymic, UserEmail, UserPhone, UserLogin, UserPassword, UserRole, UserWarehouse);
                        UpdateAllDataView();
                        ShowMessageToUser(result);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                if (wnd.Name == "AddNewRoleWnd")
                {
                    if (RoleName == null || RoleName.Replace(" ", "").Length == 0)
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
            return editItem ?? new RelayCommand(obj =>
            {
                Window wnd = obj as Window;
                if (wnd.Name == "EditProductWnd")
                {
                    string result = "Не выбран отдел!";
                    if (SelectedProduct != null)
                    {
                        result = DataWorker.EditProduct(SelectedProduct, ProductName, ProductCategory, ProductWarehouse, ProductCount, ProductPrice, ProductDiscount);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(result);
                        wnd.Close();
                    }
                    else
                    {
                        ShowMessageToUser(result);
                    }
                }
                if (wnd.Name == "EditCategoryWnd")
                {
                    string result = "Не выбрана категория!";
                    if (SelectedCategory != null)
                    {
                        result = DataWorker.EditCategory(SelectedCategory, CategoryName);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(result);
                        wnd.Close();
                    }
                    else
                    {
                        ShowMessageToUser(result);
                    }
                }
                if (wnd.Name == "EditWarehouseWnd")
                {
                    string result = "Не выбран отдел!";
                    if (SelectedWarehouse != null)
                    {
                        result = DataWorker.EditWarehouse(SelectedWarehouse, WarehouseName, WarehouseAddress, WarehousePhone);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(result);
                        wnd.Close();
                    }
                    else
                    {
                        ShowMessageToUser(result);
                    }
                }
                if (wnd.Name == "EditSupplierWnd")
                {
                    string result = "Не выбран поставщик!";
                    if (SelectedSupplier != null)
                    {
                        result = DataWorker.EditSupplier(SelectedSupplier, SupplierName, SupplierAddress, SupplierTabIdentificationNumber, SupplierPhone);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(result);
                        wnd.Close();
                    }
                    else
                    {
                        ShowMessageToUser(result);
                    }
                }
                if (wnd.Name == "EditSupplyWnd")
                {
                    string result = "Не выбрана поставка!";
                    if (SelectedSupply != null)
                    {
                        result = DataWorker.EditSupply(SelectedSupply, SupplyProduct, SupplyCount, SupplyWarehouse);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(result);
                        wnd.Close();
                    }
                    else
                    {
                        ShowMessageToUser(result);
                    }
                }
                if (wnd.Name == "EditUserWnd")
                {
                    string result = "Не выбран пользователь!";
                    if (SelectedUser != null)
                    {
                        result = DataWorker.EditUser(SelectedUser, UserName, UserSurname, UserPatronymic, UserEmail, UserPhone, UserLogin, UserPassword, UserRole, UserWarehouse);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(result);
                        wnd.Close();
                    }
                    else
                    {
                        ShowMessageToUser(result);
                    }
                }
                if (wnd.Name == "EditRoleWnd")
                {
                    string result = "Не выбрана роль!";
                    if (SelectedRole != null)
                    {
                        result = DataWorker.EditRole(SelectedRole, RoleName);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(result);
                        wnd.Close();
                    }
                    else
                    {
                        ShowMessageToUser(result);
                    }
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
            return deleteItem ?? new RelayCommand(obj =>
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
            return openAddNewProductWnd ?? new RelayCommand(obj =>
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
            return openAddNewCategoryWnd ?? new RelayCommand(obj =>
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
            return openAddNewWarehouseWnd ?? new RelayCommand(obj =>
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
            return openAddNewSupplierWnd ?? new RelayCommand(obj =>
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
            return openAddNewSupplyWnd ?? new RelayCommand(obj =>
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
            return openAddNewUserWnd ?? new RelayCommand(obj =>
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
            return openAddNewRoleWnd ?? new RelayCommand(obj =>
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
            return openAddItem ?? new RelayCommand(obj =>
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
            return openEditItem ?? new RelayCommand(obj =>
            {
                if (SelectedTabItem.Name == "ProductsTabItem" && SelectedProduct != null)
                {
                    OpenEditProductWindowsMethod(SelectedProduct);
                }
                if (SelectedTabItem.Name == "CategoriesTabItem" && SelectedCategory != null)
                {
                    OpenEditCategoryWindowsMethod(SelectedCategory);
                }
                if (SelectedTabItem.Name == "WarehousesTabItem" && SelectedWarehouse != null )
                {
                    OpenEditWarehouseWindowsMethod(SelectedWarehouse);
                }
                if (SelectedTabItem.Name == "SuppliersTabItem" && SelectedSupplier != null)
                {
                    OpenEditSupplierWindowsMethod(SelectedSupplier);
                }
                if (SelectedTabItem.Name == "SupplyTabItem" && SelectedSupply != null)
                {
                    OpenEditSupplyWindowsMethod(SelectedSupply);
                }
                if (SelectedTabItem.Name == "UsersTabItem" && SelectedUser != null)
                {
                    OpenEditUserWindowsMethod(SelectedUser);
                }
                if (SelectedTabItem.Name == "RolesTabItem" && SelectedRole != null)
                {
                    OpenEditRoleWindowsMethod(SelectedRole);
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
        SupplierAddress = null;
        SupplierTabIdentificationNumber = null;
        SupplierPhone = null;

        // Supply properties
        SupplyProduct = null;
        SupplyCount = 0;
        SupplyWarehouse = null;

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

    private void SetRedBlockControl(Window wnd, string blockName)
    {
        Control block = wnd.FindName(blockName) as Control;
        block.BorderBrush = Brushes.Red;
    }

    private void ShowMessageToUser(string message)
    {
        MessageView messageView = new MessageView(message);
        SetCenterPositionAndOpen(messageView);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}