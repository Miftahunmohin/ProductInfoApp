using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductInfoApp.DAL.DAO;
using ProductInfoApp.DAL.GateWay;

namespace ProductInfoApp.BLL
{
    class ProductBLL
    {
        private ProductGateWay aProductGateWay = new ProductGateWay();
        private ProductBLL aProductBll = new ProductBLL();
        public string Save(Product aProduct)
        {
               if ((IsValidCode(aProduct.Code) && IsValidName(aProduct.Name)))
                {
                    return aProductGateWay.Save(aProduct);
                }
              
                   
              if (aProduct.Code.Length == 3)
               {
                   return "Code string is Not valid";
               }

              if (aProduct.Name.Length <= 10 && aProduct.Name.Length >= 5)
               {
                   return "Name string is Not valid";
               }                                       
          
        }

        private bool IsValidName(string name)
        {
            return aProductGateWay.IsValidName(name);
        }

        private bool IsValidCode(string code)
        {
            return aProductGateWay.IsValidCode(code);

        }
    }
}
