using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homesofts.Units.Service
{
    public interface IUnitService
    {
        /// <summary>
        /// Create Unit
        /// </summary>
        /// <param name="param">Create Parameter</param>
        /// <returns>unit created</returns>
        Models.Unit Create(Parameters.CreateParameter param);

        /// <summary>
        /// Update Unit
        /// </summary>
        /// <param name="param">Update Parameter</param>
        void Update(Parameters.UpdateParameter param);

        /// <summary>
        /// Remove Unit
        /// </summary>
        /// <param name="id">Unit Id</param>
        void Remove(string id);
    }
}
