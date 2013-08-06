using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homesofts.PaymentModes.Service
{
    public interface IPaymentModeService
    {
        /// <summary>
        /// Create Payment Mode
        /// </summary>
        /// <param name="param">Create Parameter</param>
        /// <returns>PaymentMode</returns>
        Models.PaymentMode Create(Parameters.CreateParameter param);

        /// <summary>
        /// Update Payment Mode
        /// </summary>
        /// <param name="param">Update Parameter</param>
        void Update(Parameters.UpdateParameter param);

        /// <summary>
        /// Remove Payment Mode
        /// </summary>
        /// <param name="id">Id Payment Mode</param>
        void Remove(string id);
    }
}
