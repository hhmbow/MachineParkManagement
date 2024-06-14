// Interface defining the machine service
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MachineParkManagement.Models;

namespace MachineParkManagement.Services
{
    public interface IMachineService
    {
        Task<List<Machine>> GetMachinesAsync();
        Task SendDataAsync(Guid id);
        Task<MachineStatistics> GetStatisticsAsync();
        Task AddMachineAsync(Machine machine);
        Task RemoveMachineAsync(Guid id);
        Task UpdateMachineAsync(Machine updatedMachine);
        Task StartMachineAsync(Guid id);
        Task StopMachineAsync(Guid id);
    }
}
