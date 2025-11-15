using KoltivV1.Models;
using KoltivV1.ViewModels;

namespace KoltivV1.Application
{
    public interface IRepository
    {
        public Task<T> GetSettingValue<T>(string name);
        public Task<Dictionary<string, string>> GetAllSettings();
        public Task<ILocalizable> LoadInitialMapSettings();

        public ILocalizable GetLocalizableObj(float lat, float lng); 

    }
}
