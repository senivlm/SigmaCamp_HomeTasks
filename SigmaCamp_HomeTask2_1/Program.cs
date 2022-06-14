using SigmaCamp_HomeTask1;

try
{
    Product product1 = new Product("Картопля", 7.4m, 1);
    Product product2 = new Product("Шампунь", 72m, 0.2);
    Product product3 = new Product("Батон", 20.75m, 0.5);
    Product product4 = new Meat(120m, 1, "Extra class 1", "veal");
    Product product5 = new DairyProducts("Молоко", 30m, 0.9, 10);

    Console.WriteLine(product4);

    Buy myProducts = new Buy();
    myProducts.AddProduct(product1);
    myProducts.AddProduct(product2, 8);
    myProducts.AddProduct(product4, 3);
    myProducts.AddProduct(product5, 5);

    Check myCheck = new Check();
    myCheck.PrintCheck(myProducts);
}
catch(ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

