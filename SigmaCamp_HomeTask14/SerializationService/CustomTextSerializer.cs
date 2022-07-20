using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SigmaCamp_HomeTask14.Services;
using SigmaCamp_HomeTask14.ProductInterfaces;

namespace SigmaCamp_HomeTask14.SerializationService
{
    internal class CustomTextSerializer:CustomSerializer
    {
        public CustomTextSerializer(string FilePath) : base(FilePath) { }
        public override List<IProduct> Deserialize()
        {
            if (FileOperations.CheckFileExistence(FilePath))
            {
                List<IProduct> products;
                List<string> linesForUtil;
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    products = new List<IProduct>();
                    linesForUtil = new List<string>();
                    using (StreamWriter sw = new StreamWriter("../../../ErrorReport.txt", true))
                    {
                        int place = 0;
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            try
                            {
                                products.Add(StorageService.ParseProduct(line));
                                place++;
                            }
                            catch (ArgumentException ex)
                            {
                                sw.WriteLine($"Error:\n\tLine: {line}\n\t" + ex.Message);
                            }
                            catch (FormatException ex)
                            {
                                sw.WriteLine($"Error:\n\tLine: {line}\n\t" + ex.Message);
                            }
                        }
                    }
                }
                return products;
            }
            else
            {
                throw new FileNotFoundException("All attempts failed");
            }
        }

        public override void Serialize(List<IProduct> products)
        {
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                foreach (IProduct product in products)
                {
                    sw.WriteLine(product.GetShortDescription());
                }
            }
        }
    }
}
