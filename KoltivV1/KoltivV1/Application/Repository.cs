
using KoltivV1.Data;
using KoltivV1.ViewModels;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.Generic;

namespace KoltivV1.Application
{
    public class Repository : IRepository
    {
        private readonly IDbContextFactory<AppDbContext> dbContextFactory;
        public Repository(IDbContextFactory<AppDbContext> DbContextFactory)
        {
            dbContextFactory = DbContextFactory;
        }
        public async Task<Dictionary<string, string>> GetAllSettings()
        {
            using AppDbContext db = await dbContextFactory.CreateDbContextAsync();

            var ItemsInDb = await db.Settings
                .AsNoTracking()
                .Select(s => new KeyValuePair<string, string>(s.Name, s.Value))
                .ToDictionaryAsync(keySelector: item => item.Key, elementSelector: item => item.Value );

            if (ItemsInDb != null && ItemsInDb.Any()) return ItemsInDb;

            return new Dictionary<string, string>();

        }

        public ILocalizable GetLocalizableObj(float lat, float lng)
        {
            return new Localizable() { lat = lat, lng = lng };
        }

        public async Task<T> GetSettingValue<T>(string name)
        {
            Dictionary<string, string> Settings = await GetAllSettings();

            KeyValuePair<string, string>? nullableKeyValuePair = Settings.FirstOrDefault(s => s.Key == name);
            
            Type targetType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);            

            if (nullableKeyValuePair.HasValue)
            {
                KeyValuePair<string, string> KeyValuePair = nullableKeyValuePair.Value;

                var valueToConvert = KeyValuePair.Value;

                T convertedValue = (T)Convert.ChangeType(valueToConvert, targetType);

                return convertedValue;

            } else
            {
                throw new Exception($"Setting with name \"{name}\" not found");
            }        
            
        }

        public async Task<ILocalizable> LoadInitialMapSettings()
        {
            ILocalizable localizable = new Localizable()
            {
                lat = await GetSettingValue<float>("Map_Initial_LAT"),
                lng = await GetSettingValue<float>("Map_Initial_LON"),
                zoom = await GetSettingValue<int>("Map_Initial_ZOOM"),
            };

            return localizable;

        }
    }
}
