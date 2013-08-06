using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models = Homesofts.Currency.Service.models;

namespace Homesofts.Currency.Service
{
    public interface ICurrencyService
    {
        /// <summary>
        /// Service Create Currency
        /// </summary>
        /// <param name="parameter">Create Parameter</param>
        /// <returns>Model Currency</returns>
        Models.Currency Create(parameters.CreateParameter parameter);

        /// <summary>
        /// Service Update Currency
        /// </summary>
        /// <param name="parameter">Update Parameter</param>
        /// <returns>Model Currency</returns>
        void Update(parameters.UpdateParameter parameter);

        /// <summary>
        /// Service Remove Currency
        /// </summary>
        /// <param name="id">Id Currency</param>
        void Remove(string id);
    }
}
