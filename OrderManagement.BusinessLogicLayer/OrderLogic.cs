using OrderManagement.DataAccessLayer;
using OrderManagement.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.BusinessLogicLayer
{
    public class OrderLogic : BaseLogic<OrderPoco>
    {
        public OrderLogic(IDataRepository<OrderPoco> repository) : base(repository)
        {
        }

        protected override void Verify(OrderPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            //base.Verify(pocos);
            foreach (OrderPoco poco in pocos)
            {
                if (poco.OrderDate > DateTime.Now)
                {
                    exceptions.Add(new ValidationException(108, "ORder Date cannot be greater than today"));

                }

            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }
        public override void Add(OrderPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(OrderPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }
}
