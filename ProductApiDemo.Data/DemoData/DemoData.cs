using ProductApiDemo.Models;

namespace ProductApiDemo.Data.DemoData
{
    public static class DemoData
    {
        private static List<Product> data = new List<Product>
        {
            new Product { Id = new Guid("{7025C81B-E44D-4A78-BF6F-914414946A68}"), Name = "Banana chips", Code = "AB11", ExpirationDate = new DateTime(2023, 12, 1) },
            new Product { Id = new Guid("{ADE84630-C3D3-462D-A958-C5592916EF76}"), Name= "Apple chips", Code = "AB12", ExpirationDate = new DateTime(2023, 12, 1) },
            new Product { Id = new Guid("{94346C0A-A803-4E27-8749-6AD547CB3978}"), Name = "Potato chips", Code = "AB13", ExpirationDate = new DateTime(2023, 11, 1) },
            new Product { Id = new Guid("{4ADB3E6E-55BC-4CD8-AAA5-6F3EF7B3F730}"), Name = "Pineapple", Code = "BB11", ExpirationDate = new DateTime(2023, 2, 1) },
            new Product { Id = new Guid("{777A2917-65AE-47C6-A62D-DF53EABBFD2B}"), Name = "Lime", Code = "BB12", ExpirationDate = new DateTime(2023, 2, 1) },
            new Product { Id = new Guid("{E3F3A6DA-60DB-4818-8E3C-AF1787762224}"), Name = "Apple", Code = "BB13", ExpirationDate = new DateTime(2023, 2, 1) },
            new Product { Id = new Guid("{A58C5B46-3EA5-41D6-8467-10DCA04AB0FA}"), Name = "Banana", Code = "BB14", ExpirationDate = new DateTime(2023, 2, 1) },
            new Product { Id = new Guid("{2A02DD05-604F-41C0-8BE2-9A0251575523}"), Name = "Chocolade", Code = "CB11", ExpirationDate = new DateTime(2023, 6, 1) },
            new Product { Id = new Guid("{0B1A02C2-0C71-49B3-A374-0B0745AF2FFC}"), Name = "Cereal", Code = "CB12", ExpirationDate = new DateTime(2023, 5, 1) },
            new Product { Id = new Guid("{F9BECDC8-A694-48CD-8245-19E254FB049B}"), Name = "Vanilla cookies", Code = "CB13", ExpirationDate = new DateTime(2023, 5, 1) },
            new Product { Id = new Guid("{BD61B7DC-E4AF-4940-A468-5FCD9093AE10}"), Name = "Chocolade cookies", Code = "CB14", ExpirationDate = new DateTime(2023, 5, 1) },
            new Product { Id = new Guid("{24529D6E-E0EA-4D52-8C27-FB8B9E003CBA}"), Name = "Strawberry cookies", Code = "CB15", ExpirationDate = new DateTime(2023, 5, 1) },
            new Product { Id = new Guid("{9533EC53-0D6A-4264-8034-BB62F11DF282}"), Name = "Water", Code = "DB11", ExpirationDate = new DateTime(2023, 12, 1) },
            new Product { Id = new Guid("{ADBFDF00-315E-4D2F-9D9F-608D336E46A5}"), Name = "Sparkling water", Code = "DB12", ExpirationDate = new DateTime(2023, 6, 1) },
            new Product { Id = new Guid("{357380FE-9F42-43AB-89D9-6D92BFAB1A30}"), Name = "Limonade", Code = "DB13", ExpirationDate = new DateTime(2023, 6, 1) },
            new Product { Id = new Guid("{E8FA1755-5C55-41AE-A822-5A0BAD0FE65F}"), Name = "Vanilla icecream", Code = "EB11", ExpirationDate = new DateTime(2023, 6, 1) },
            new Product { Id = new Guid("{79B37C8A-250D-42B3-876F-BC0ACCBC83FC}"), Name = "Strawberry icecream", Code = "EB12", ExpirationDate = new DateTime(2023, 6, 1) },
            new Product { Id = new Guid("{B462E0CB-C45C-4956-95EA-9252A234C835}"), Name = "Chocolate icecream", Code = "EB13", ExpirationDate = new DateTime(2023, 6, 1) },
            new Product { Id = new Guid("{E477CCC0-6286-43F9-A9FC-5E9486A6A93D}"), Name = "Pineapple icecream", Code = "EB14", ExpirationDate = new DateTime(2022, 12, 1) }
        };

        public static List<Product> GetProductExamples()
        {
            return data.ToList();
        }

        public static async IAsyncEnumerable<Product> GetProductExamplesAsAsyncEnumerable()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }
    }
}
