# Learn-EFCore
學習EF Core

# 第一章建立Model
以Code-first方法建立
## 第一步:
### 安裝EFCore相關Nuget

Install-Package Microsoft.EntityFrameworkCore.SqlServer   
Install-Package Microsoft.EntityFrameworkCore.Design  
Install-Package Microsoft.EntityFrameworkCore.Tools  


## 第二步:
新增一個資料夾,取名:Model or Domain  
新增以下所有class  
```C#
public class Product  
{  
  [key]  
  public int Id {get; set;}  
  [required]  
  public string Name {get; set;}  
  [Column(TypeName="decimal(18,2)"]  
  public decimal Price {get; set;}  
}  

public class Customer  
{  
  public int Id {get; set;}
  public string FirstName {get; set;}
  public string LastName {get; set;}
  public string? Address {get; set;}      //This allows null
  public string? Phone {get; set;}
  public string? Email {get; set;}    //This property was added later
  public ICollection<Order> Orders {get; set;}  //Navigation Property  i.e help internal link to the other class
}

public class Order
{ 
  public int Id {get; set;}
  public DateTime OrderPlaced {get; set;}
  public DateTime? OrderFulfilled {get; set;}
  public int CustomerId {get; set;}

  public Customer Customer {get; set;}   //Navigation Property
  public ICollection<ProductOrder> ProductOrders {get; set;}  //Navigation Property  
}

//Intersection Table to faciliate the many to many relationship
public class ProductOrder
{ 
  public int Id {get; set;}
  public int Quantity {get; set;}
  public int ProductId {get; set;}
  public int OrderId {get; set;}

  public Order Order {get; set;}   //Navigation Property
  public Product Product {get; set;}   //Navigation Property 
}
```
  
新增一個資料夾,取名:Data  
新增與DB連線的class  
  
```C#
public class ContosoPetsContext: DbContext
{ 
   public DbSet<Customer> Customers {get; set;}
   public DbSet<Order> Orders {get; set;}
   public DbSet<Product> Products {get; set;}
   public DbSet<ProductOrder> ProductOrders {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ContosoAppData");
    }
}

```  
![image](https://github.com/Tim-SideProjectOrTool/Learn-EFCore/blob/master/ConsoleApp1/GitImage/%E6%96%B0%E5%A2%9EDBclass.PNG)

## 第三步:
新增第一個DB搬移紀錄  
因為第一個紀錄取名為:InitialCreate  
PM> Add-Migration  InitialCreate  
![image](https://github.com/Tim-SideProjectOrTool/Learn-EFCore/blob/master/ConsoleApp1/GitImage/Add-Migration%20%20InitialCreate.PNG)  

## 第四步:
更新DB  
PM> update-database -verbose  
![image](https://github.com/Tim-SideProjectOrTool/Learn-EFCore/blob/master/ConsoleApp1/GitImage/update-database%20-verbose.PNG)  

# 註:
如果Model更動就重複第三'四步,  
建立搬移檔紀錄,在更新  
``` C#
PM> Add-Migration  [記錄名稱]  
PM> update-database -verbose  
```  


# 第二章建立Model (DB-first)
以DB-first方法建立
## 第一步:
### 執行DB連線建立Model
```C#
Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFCore;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context CCIPContext -DataAnnotations -Force
//-OutputDir 資料夾名   :建立的資料夾名
//-Context 連線檔檔名   :建立連線檔檔名
//-DataAnnotations     :加上欄位設定內容
//-Force               :強制產生新Model
```
執行完語法後,如圖自動產生Model  
![image](https://github.com/Tim-SideProjectOrTool/Learn-EFCore/blob/master/ConsoleApp1/GitImage/DBFirst%E5%9F%B7%E8%A1%8CScaffold-DbContext%E5%BE%8C%E7%94%A2%E7%94%9F%E7%9A%84Model.PNG)  


## 第二步:
### 建立自定義屬性
產生一個Partial的資料夾,並以 Products.cs 為範例  
新增一個同檔名,但是副檔名由[.cs]改為[.partial.cs]  
![image](https://github.com/Tim-SideProjectOrTool/Learn-EFCore/blob/master/ConsoleApp1/GitImage/DBFirst%E5%BB%BA%E7%AB%8B%E8%87%AA%E5%AE%9A%E7%BE%A9%E5%B1%AC%E6%80%A7.PNG)  


## 第三步:
### 建立檔案
1. 這個Partial Class必須跟這個物件相同NameSpace  
2. 在Partial Class裡新增一個類別，通常命名方式：原檔名+MD。  
3. 在Partial Class上加上MetadataType，已建立RANGERMD與RANGER的關係  
4.可以直接把原.cs檔的所有欄位貼到.partial.cs, 並加上自定義的屬性, 如:[Display]等...  
 ![image](https://github.com/Tim-SideProjectOrTool/Learn-EFCore/blob/master/ConsoleApp1/GitImage/%E5%BB%BA%E7%AB%8B%E8%87%AA%E5%AE%9A%E7%BE%A9%E5%B1%AC%E6%80%A7class.PNG)  

# 註:
當完成第三步後,如果DB修改後再執行第一步,也不會覆蓋自定的Partial Class內容

[ 參考資源 文章 ][[ASP.NET MVC]使用 DataAnnotations 屬性](https://dotblogs.com.tw/chentingw/2016/11/28/235523 "")  
[ 參考資源 影片 ][Working with an Existing Database | Entity Framework Core 101 [2 of 5]](https://www.youtube.com/watch?v=-sftSA9_X-k&list=PLdo4fOcmZ0oX7uTkjYwvCJDG2qhcSzwZ6&index=2 "")  


# 第三章 MVC專案建立DB連結在Startup.cs
Startup.cs的ConfigureServices內建立連結
```C#
services.AddDbContext<CCIPContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCore;Integrated Security=True"));
```
![image](https://github.com/Tim-SideProjectOrTool/Learn-EFCore/blob/master/ConsoleApp1/GitImage/mvc%E5%B0%88%E6%A1%88%E5%BB%BA%E7%AB%8Bdb%E9%80%A3%E7%B5%90%E5%9C%A8Startup.cs.png)  


[ 參考資源 文章 ][微軟文件](https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings "")  
