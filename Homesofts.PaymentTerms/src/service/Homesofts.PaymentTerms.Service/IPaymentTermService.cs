using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homesofts.PaymentTerms.Service
{
    public interface IPaymentTermService
    {
        /// <summary>
        /// Create Payment Term
        /// </summary>
        /// <param name="param">Create Parameter</param>
        /// <returns>Model Payment Term</returns>
        Models.PaymentTerm Create(Parameters.CreateParameter param);

        /// <summary>
        /// Update Payment Term
        /// </summary>
        /// <param name="param">Update Parameter</param>
        void Update(Parameters.UpdateParameter param);

        /// <summary>
        /// Remove Payment Term
        /// </summary>
        /// <param name="id">Payment Term Id</param>
        void Remove(string id);
    }
}
