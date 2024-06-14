using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MachineParkManagement.Models;


namespace MachineParkManagement.Services
{
    public class MockMachineService : IMachineService
    {
        private List<Machine> machines = new List<Machine>
        {
            new Machine { Id = Guid.NewGuid(), Name = "Machine 1", Status = "Online", LatestData = "Data 1" },
            new Machine { Id = Guid.NewGuid(), Name = "Machine 2", Status = "Offline", LatestData = "Data 2" }
        };

        public Task<List<Machine>> GetMachinesAsync()
        {
            return Task.FromResult(machines);
        }

        public Task SendDataAsync(Guid id)
        {
            var machine = machines.FirstOrDefault(m => m.Id == id);
            if (machine != null)
            {
                machine.LatestData = $"New Data {DateTime.Now}";
            }
            return Task.CompletedTask;
        }

        public Task<MachineStatistics> GetStatisticsAsync()
        {
            var stats = new MachineStatistics
            {
                TotalMachines = machines.Count,
                OnlineMachines = machines.Count(m => m.Status == "Online"),
                LastEditedMachine = machines.LastOrDefault()?.Name
            };
            return Task.FromResult(stats);
        }

        public Task AddMachineAsync(Machine machine)
        {
            machines.Add(machine);
            return Task.CompletedTask;
        }

        public Task RemoveMachineAsync(Guid id)
        {
            var machine = machines.FirstOrDefault(m => m.Id == id);
            if (machine != null)
            {
                machines.Remove(machine);
            }
            return Task.CompletedTask;
        }

        public Task UpdateMachineAsync(Machine updatedMachine)
        {
            var machine = machines.FirstOrDefault(m => m.Id == updatedMachine.Id);
            if (machine != null)
            {
                machine.Name = updatedMachine.Name;
                machine.Status = updatedMachine.Status;
                machine.LatestData = updatedMachine.LatestData;
            }
            return Task.CompletedTask;
        }

        public Task StartMachineAsync(Guid id)
        {
            var machine = machines.FirstOrDefault(m => m.Id == id);
            if (machine != null)
            {
                machine.Status = "Online";
            }
            return Task.CompletedTask;
        }

        public Task StopMachineAsync(Guid id)
        {
            var machine = machines.FirstOrDefault(m => m.Id == id);
            if (machine != null)
            {
                machine.Status = "Offline";
            }
            return Task.CompletedTask;
        }
    }
}
