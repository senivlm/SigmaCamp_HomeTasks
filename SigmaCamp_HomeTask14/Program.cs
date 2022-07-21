using System;
using System.IO;
using SigmaCamp_HomeTask14.Services;
using SigmaCamp_HomeTask14.ProductTypes;
using SigmaCamp_HomeTask14.ProductInterfaces;
using SigmaCamp_HomeTask14.SerializationService;
using System.Collections.Generic;
namespace SigmaCamp_HomeTask14
{
    internal class Program
    {
        static void Main(string[] args)
        {//це тільки частина завдання.
            try
            {
                Console.OutputEncoding = System.Text.Encoding.GetEncoding(65001);
                Storage<IProduct>.CreateStorage(100);
                Storage<IProduct> myStorage = Storage<IProduct>.Instance;
                myStorage.OverDated += Handlers.AddItemHandler;
                SerializerCreator creator1 = new TextSerializerCreator();
                CustomSerializer textSerializer = creator1.CreateSerializer("../../../TextProducts.txt");
                myStorage.AddProducts(textSerializer.Deserialize());

                SerializerCreator creator2 = new JSONSerializerCreator();
                CustomSerializer jsonSerializer = creator2.CreateSerializer("../../../JSONproducts.txt");
                jsonSerializer.Serialize(myStorage.GetAllItems());
                var products = jsonSerializer.Deserialize();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
