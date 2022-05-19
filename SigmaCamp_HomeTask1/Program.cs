using SigmaCamp_HomeTask1;

Product product1 = new Product("Картопля", 7.4m, 1);
Product product2 = new Product("Шампунь", 72m, 0.2);
Product product3 = new Product("Батон", 20.75m, 0.5);

Buy productToBuy1 = new Buy(product1, 5);
Buy productToBuy2 = new Buy(product2, 2);
Buy productToBuy3 = new Buy(product3, 3);

Check myCheck = new Check();
myCheck.PrintCheck(productToBuy1, productToBuy2, productToBuy3);
