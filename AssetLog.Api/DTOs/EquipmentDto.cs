using AssetLog.Api.Models.Enums;

namespace AssetLog.Api.DTOs
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public String Name { get; set; } = string.Empty;
        public String Description { get; set; } = string.Empty;
        public CategoryEnum Category { get; set; }
       
    }
}