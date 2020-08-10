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
