using OrderManagement.DataAccessLayer;
using OrderManagement.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.BusinessLogicLayer
{
    public class ProductLogic : BaseLogic<ProductPoco>
    {
        public ProductLogic(IDataRepository<ProductPoco> repository) : base(repository)
        {
        }

        protected override void Verify(ProductPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            //base.Verify(pocos);
            foreach (ProductPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.ProductName))
                {
                    exceptions.Add(new ValidationException(107, "Blank Name Not Accepted"));

                }
                
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }
        public override void Add(ProductPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ProductPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }
}
