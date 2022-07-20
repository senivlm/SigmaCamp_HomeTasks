using SigmaCamp_HomeTask14.ProductInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Reflection;
using SigmaCamp_HomeTask14.ProductTypes;
namespace SigmaCamp_HomeTask14.SerializationService
{
    internal class CustomJSONSerializer: CustomSerializer
    {
        public CustomJSONSerializer(string filePath):base(filePath)
        {

        }
        public override List<IProduct> Deserialize()
        {
            var options = new JsonSerializerOptions()
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true,
                WriteIndented = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.
                WriteAsString
            };
            List<IProduct> products = new List<IProduct>();
            using (StreamReader sr = new(FilePath))
            {
                string allProducts = sr.ReadToEnd();
                string[] splitedProducts = allProducts.Split("},");
                List<string> jsonProducts = splitedProducts.Select(p=>p+"}").ToList();
                jsonProducts[jsonProducts.Count - 1] = jsonProducts[jsonProducts.Count - 1].Remove(jsonProducts[jsonProducts.Count - 1].Length - 1);
                foreach (string jsonProduct in jsonProducts)
                {
                    using (var jsonDoc = JsonDocument.Parse(jsonProduct))
                    {
                        Type type = typeof(IProduct);
                        List<string> types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                            .Where(p => type.IsAssignableFrom(p)).Select(t=> t.FullName).ToList();
                        string productType = jsonDoc.RootElement.GetProperty("type").GetString();
                        if (types.Contains(productType))
                        {
                            Type pType = Type.GetType(productType);
                            var methods = typeof(JsonSerializer).GetMethods().Where(m => m.Name == "Deserialize").ToList();
                            foreach (var method in methods)
                            {
                                var parameters = method.GetParameters();
                                if (method.IsGenericMethod && parameters[0].ParameterType == typeof(string))
                                {
                                    MethodInfo constucted = method.MakeGenericMethod(pType);
                                    object[] args = { jsonDoc.RootElement.ToString(), options };
                                    products.Add((IProduct)constucted.Invoke(null, args));
                                }
                            }
                        }
                    }
                }
            }
            return products;
        }

        public override void Serialize(List<IProduct> products)
        {
            var options = new JsonSerializerOptions()
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true,
                WriteIndented = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.
                WriteAsString
            };
            using (StreamWriter sw = new(FilePath))
            {
                for (int i = 0; i < products.Count-1; i++)
                {
                    sw.Write(JsonSerializer.Serialize(products[i], products[i].GetType(), options));
                    sw.WriteLine(",");
                }
                sw.Write(JsonSerializer.Serialize(products[products.Count - 1], products[products.Count - 1].GetType(), options));
            }
        }
    }
}
