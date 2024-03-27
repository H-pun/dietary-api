using Microsoft.AspNetCore.Http;
using Dietary.Base;
using Dietary.DataAccess.Entities;
using Dietary.Helpers;
using Dietary.DataAccess.Models;

namespace Dietary.DataAccess.Seeders
{
    public class FoodSeed : IBaseSeed<Food>
    {
        private readonly List<Food> Foods =
        [
            new() { Name = "Ayam Bakar", IdFatSecret = new Guid("d7352727-e6ef-4a7d-b778-02b6c085908e") },
            new() { Name = "Ayam Goreng", IdFatSecret = new Guid("99713a3c-d660-4cf4-90c6-e887985b7494") },
            new() { Name = "Bakso", IdFatSecret = new Guid("ee0f597c-2e50-48bf-ba45-2155bf18c6b2") },
            new() { Name = "Bakwan", IdFatSecret = new Guid("a5173129-8398-4c38-aa4d-410285a0fa19") },
            new() { Name = "Bihun", IdFatSecret = new Guid("985d285d-154c-4b3e-ac9a-316568994d09") },
            new() { Name = "Capcay", IdFatSecret = new Guid("43135437-a075-4b5a-8175-b32e3337246e") },
            new() { Name = "Gado-Gado", IdFatSecret = new Guid("b1aea6ea-789a-40dc-a1aa-1dcd621b561b") },
            new() { Name = "Ikan Goreng", IdFatSecret = new Guid("c13659ba-d62c-4391-8d1c-d8d9b86b995c") },
            new() { Name = "Kerupuk", IdFatSecret = new Guid("b98d19dd-ec3c-4f94-b7c5-ded54382130c") },
            new() { Name = "Martabak Telur", IdFatSecret = new Guid("5bfd0906-661c-403c-988c-016161ffffe1") },
            new() { Name = "Mie", IdFatSecret = new Guid("5872b47d-d868-44b1-a08b-1e9b08bb9138") },
            new() { Name = "Nasi Goreng", IdFatSecret = new Guid("99f1408c-ba57-4fda-b329-d19f12de1e29") },
            new() { Name = "Nasi Putih", IdFatSecret = new Guid("7cacdc1b-790e-44ae-9b83-339342523746") },
            new() { Name = "Nugget", IdFatSecret = new Guid("ac15dce4-90b5-47dd-b090-7b60f1ecdfce") },
            new() { Name = "Opor Ayam", IdFatSecret = new Guid("c2e49f78-cc0f-44f6-95f1-d3818925b3e2") },
            new() { Name = "Rendang", IdFatSecret = new Guid("23f717d5-3ba7-430b-90ca-66fd8cab79d8") },
            new() { Name = "Roti", IdFatSecret = new Guid("26ecdd39-db76-441d-8323-4004203c6da6") },
            new() { Name = "Sate", IdFatSecret = new Guid("fc0db542-fec1-4b1b-b8e0-80dd1ac873f7") },
            new() { Name = "Sosis", IdFatSecret = new Guid("bcc60875-0c26-440a-8749-7c48a6ee3dfd") },
            new() { Name = "Soto", IdFatSecret = new Guid("02d6e788-a29b-4756-8732-24d0f70ee234") },
            new() { Name = "Tahu", IdFatSecret = new Guid("96c75da6-6968-4081-8252-f24b1744223d") },
            new() { Name = "Telur", IdFatSecret = new Guid("4897bc2b-1be8-4951-afe8-1e475fd705e8") },
            new() { Name = "Tempe", IdFatSecret = new Guid("282d2a05-31c0-4355-a3c3-f0153e340575") },
            new() { Name = "Tumis Kangkung", IdFatSecret = new Guid("0cf2a01c-ba9e-4fdc-a02f-d0489a74cd5d") },
            new() { Name = "Udang", IdFatSecret = new Guid("d3139a4e-781c-47d7-9316-891dd75a4535") }
        ];
        public List<Food> GetSeeder()
        {
            return Foods;
        }
    }
}
