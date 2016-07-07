using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PagingSum
    {
        public List<Products> productList = new List<Products>();

        public PagingSum()
        {
            for (int i = 1; i < 12; i++)
            {
                productList.Add(new Products()
                {
                    ID = i,
                    Cost = i,
                    Revenue = 10 + i,
                    SellProce = 20 + i
                });
            }

        }

        public IEnumerable<Products> GetProducts()
        {
            return productList;
        }

        public string GetCost()
        {
            var cost = "";
            var costData = productList;
            decimal costSum = 0;

            for (int i = 0; i < costData.Count / 3; i++)
            {
                costSum = 0;
                var count = i * 3;
                costSum += costData[count].Cost;
                costSum += costData[count + 1].Cost;
                costSum += costData[count + 2].Cost;
                cost += costSum;
                cost += ",";
                if (i == 2)
                {
                    costSum = 0;
                    costSum += costData[9].Cost;
                    costSum += costData[10].Cost;
                    cost += costSum;
                }
            }


            return cost;
        }


        public string GetRevenue()
        {
            var revenue = "";
            var revenueData = productList;
            List<decimal> result = new List<decimal>();

            for (int i = 0; i < revenueData.Count / 4; i++)
            {
                decimal revenueSum = 0;

                var count = i * 4;
                revenueSum += revenueData[count].Revenue;
                revenueSum += revenueData[count + 1].Revenue;
                revenueSum += revenueData[count + 2].Revenue;
                revenueSum += revenueData[count + 3].Revenue;

                revenue += revenueSum;
                revenue += ",";

                if (i == 1)
                {
                    revenueSum = 0;
                    revenueSum += revenueData[8].Revenue;
                    revenueSum += revenueData[9].Revenue;
                    revenueSum += revenueData[10].Revenue;
                    revenue += revenueSum;
                }
            }


            return revenue;
        }

        public List<decimal> GetSum(List<decimal> field, int pageCount)
        {

            List<decimal> result = new List<decimal>();
            decimal sum = 0;
            var less = field.Count%pageCount;

            for (int i = 0; i < field.Count / pageCount; i++)
            {
                sum = 0;
                var num = i * pageCount;
                for (int j = 0; j < pageCount; j++)
                {
                    sum += field[num + j];
                 }
                result.Add(sum);

                if (less != 0)
                {
                    if (i == field.Count/pageCount-1)
                    {
                        sum = 0;
                        for (int j = field.Count; j > (i+1)* pageCount; j--)
                        {
                            sum += field[j-1];
                        }
                        result.Add(sum);
                    }
                }

                }
            


            return result;
        }

    }


}
