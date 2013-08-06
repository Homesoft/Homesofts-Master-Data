using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homesofts.Taxes.Service.Models;

namespace Homesofts.Taxes.Service
{
    public interface ITaxService
    {
        /// <summary>
        /// Create Tax
        /// </summary>
        /// <param name="param">Create Parameter</param>
        /// <returns>Tax Created</returns>
        Tax Create(Parameters.CreateParameter param);

        /// <summary>
        /// Update Tax
        /// </summary>
        /// <param name="param">Update Parameter</param>
        void Update(Parameters.UpdateParameter param);

        /// <summary>
        /// Remove Tax
        /// </summary>
        /// <param name="id">Tax Id</param>
        void Remove(string id);
    }
}
