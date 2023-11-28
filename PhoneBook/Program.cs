using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

interface IDocument
{
    int Create(ModelClass modelClass);
    int Update(ModelClass modelClass);
    bool Delete(int id);
    List<ModelClass> Show();
    List<ModelClass> Find(string name);

}

class SQLDocument : IDocument
{
    public List<ModelClass> modelClasses;

    public SQLDocument()
    {
        modelClasses = new List<ModelClass>();
    }

    public int Create(ModelClass modelClass)
    {
        modelClasses.Add(modelClass);
        return modelClass.Id;
    }

    public int Update(ModelClass modelClass)
    {
        var existing = modelClasses.FirstOrDefault(p => p.Id == modelClass.Id);
        if (existing != null)
        {

            existing.Name = modelClass.Name;
            existing.Email = modelClass.Email;
            existing.phone = modelClass.phone;
            existing.Address = modelClass.Address;
        }
        return modelClass.Id;
    }


    public bool Delete(int id)
    {
        var existing = modelClasses.FirstOrDefault(p => p.Id == id);
        if (existing == null)
            return false;
        {

        }
        modelClasses.Remove(existing);
        return true;
    }

    public List<ModelClass> Show()
    {
        return modelClasses;
    }



    public List<ModelClass> Find(string name)
    {
        var matchingItems = modelClasses.Where(p => p.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)).ToList();
        return matchingItems;
    }

}

class ModelClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

}

class Program
{
    public static void Main(string[] args)
    {

        IDocument document = new SQLDocument();
        document.Create(new ModelClass
        {
            Id = 1,
            Name = "Sajjad",
            phone = "01765756",
            Email = "sazzad17@cse.pstu.ac.bd",
            Address = "Bhandaria, Prirojpur"
        });

        while (true)
        {
            Console.WriteLine("\nPress 1 to see your data ");
            Console.WriteLine("Press 2 to add your data ");
            Console.WriteLine("Press 3 to search your data");
            Console.WriteLine("Press 4 to stop the system");
            int events = Convert.ToInt32(Console.ReadLine());
            if (events == 4) { break; }

            switch (events)
            {
                case 1:
                    {
                        List<ModelClass> modelClasses = document.Show();
                        Console.WriteLine($"ID      Name       Phone              Email                      Address             ");
                        foreach (ModelClass item in modelClasses)
                            Console.WriteLine($"{item.Id}     {item.Name}     {item.phone}      {item.Email}        {item.Address}");
                        break;
                    }

                case 2:
                    {

                        Console.Write("How many ids data Do you want to add :");
                        int totalinput = Convert.ToInt32(Console.ReadLine());

                        for (int i = 1; i <= totalinput; i++)
                        {
                            ModelClass objectofmodelclass = new ModelClass();
                            objectofmodelclass.Id = i + 1;
                            Console.Write("Name: ");
                            objectofmodelclass.Name = Console.ReadLine();

                            Console.Write("Phone: ");
                            objectofmodelclass.phone = Console.ReadLine();

                            Console.Write("Email: ");
                            objectofmodelclass.Email = Console.ReadLine();

                            Console.Write("Address: ");
                            objectofmodelclass.Address = Console.ReadLine();

                            int newId = document.Create(objectofmodelclass);

                        }
                       
                            Console.Write("Data inserted Successfully\n");

                        // List<ModelClass> modelClasses = document.Show();
                        // Console.WriteLine($"ID      Name       Phone              Email                      Address             ");
                        // foreach (ModelClass item in modelClasses)
                        // Console.WriteLine($"{item.Id}     {item.Name}     {item.phone}      {item.Email}        {item.Address}");
                        break;
                    }




                case 3:
                    {

                        Console.Write("Enter the name to search: ");
                        string Name = Console.ReadLine();
                        List<ModelClass> matchingItems = document.Find(Name);
                        Console.WriteLine($"ID      Name       Phone              Email                      Address             ");
                        foreach (ModelClass item in matchingItems)
                            Console.WriteLine($"{item.Id}     {item.Name}     {item.phone}      {item.Email}        {item.Address}");

                        Console.WriteLine("\nPress 1 to edit your data ");
                        Console.WriteLine("Press 2 to delet your data ");
                        int tmp = Convert.ToInt32(Console.ReadLine());
                        switch (tmp)
                        {
                            case 1:
                                {
                                    Console.Write("Which Id do you want you update  : ");
                                    ModelClass objectofmodelclass = new ModelClass();
                                    objectofmodelclass.Id = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("\nName: ");
                                    objectofmodelclass.Name = Console.ReadLine();

                                    Console.Write("Phone: ");
                                    objectofmodelclass.phone = Console.ReadLine();

                                    Console.Write("Email: ");
                                    objectofmodelclass.Email = Console.ReadLine();

                                    Console.Write("Address: ");
                                    objectofmodelclass.Address = Console.ReadLine();


                                    int response = document.Update(objectofmodelclass);
                                    if (response == objectofmodelclass.Id)
                                        Console.Write("Updated Successfully\n");




                                    break;

                                }


                            case 2:
                                {
                                    Console.Write("Which Id do you want you delete  : ");
                                    bool cheaking = document.Delete(Convert.ToInt32(Console.ReadLine()));
                                    if (cheaking == true)
                                        Console.Write("Deletion Successfull\n");

                                    break;
                                }


                        }


                        break;


                    }
                default:
                    Console.WriteLine("Your input number is not valid");
                    break;
            }

        }

    }
}



class MyTableA
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateTime { get; set; }

    public List<MyTableB> MyTableBs { get; set; }
}
class MyTableB
{
    public Guid Id { get; set; }
    public string Offset { get; set; }
    public double Unit { get; set; }

    public List<MyTableA> MyTableAs { get; set; }

}

class MyClassAB
{
    public Guid Id { get; set; }
    public MyTableA MyTableA { get; set; }
    public Guid MyTableAId { get; set; }
    public MyTableB MyTableB { get; set; }
    public Guid MyTableBId { get; set; }

}

class Sylabuss
{
    public Guid Id { get; set; }
    public string Session { get; set; }
    public List<Course> Courses { get; set; }
}

class Course
{
    public Guid Id { get; set; }
    public string CourseCode { get; set; }
    public string CourseTitle { get; set; }
    public double Credit { get; set; }
    public Sylabuss Sylabuss { get; set; }
    public Guid SylabussId { get; set; }
}






// TASK : Design a online market database relation with code first approach using model class 

public class Retailer
{
    public int RetailerId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
  
    public List<Product> products { get; set; }
    public Daraz daraz { get; set; }
}





public class Product
{
   
    public int ProductId { get; set; }

    public string Name { get; set; }
 
    public string Description { get; set; }

    public decimal Price { get; set; }
    public Retailer Retailer { get; set; }
    
}

public class Daraz
{

    public string Name { get; set; }

    public string Email { get; set; }

    public List <Retailer> Retailers { get; set; }
    public List<User> Users { get; set; }
    public List<Order> Orders { get; set; }
   
}



public class User
{
      
    public int UserId { get; set; }

  
    public string UserName { get; set; }

 
    public string Email { get; set; }

   
    public string Password { get; set; }

    public List<Order> Orders { get; set; }
    public List<Product> Products { get; set; }
 
}

public class Order
{
 
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; } 

    public int OrderItemId { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public User user { get; set; }
    public Order order { get; set; }


}


