using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DockerTraining.Interfaces
{
    public interface ISender : IDisposable
    {
        /// <summary>
        /// Gets All values from the second service
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<string>> GetAll();


        /// <summary>
        /// Sends value to the second service
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<bool> SaveOne(string value);
    }
}
