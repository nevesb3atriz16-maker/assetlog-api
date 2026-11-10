using AssetLog.Api.Data;
using AssetLog.Api.Models;
using AssetLog.Api.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using System.Diagnostics;

namespace AssetLog.Api.Repositories.EquipmentRepository
{
    public class EquipmentRepository(AppDbContext db) : IEquipmentRepository
    {
        //adicionar async save + resto dos metodos
        //fazer igual na interface
        public async Task<List<Equipment>> GetAllEquipment(CancellationToken cancellationToken = default)
        {
            return await db.Equipments.ToListAsync(cancellationToken);
        }

        public async Task<Equipment?> GetEquipmentById(int id, CancellationToken cancelationToken = default)
        {
            return await db.Equipments.FindAsync([id], cancelationToken);
        }

        public async Task AddEquipment(Equipment equipment, CancellationToken cancelationToken = default)
        {
            await db.Equipments.AddAsync(equipment, cancelationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancelationToken = default)
        {
            await db.SaveChangesAsync(cancelationToken);
        }
    }
    
}