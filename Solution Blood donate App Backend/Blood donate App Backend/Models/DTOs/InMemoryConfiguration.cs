using Microsoft.Extensions.Primitives;

namespace Blood_donate_App_Backend.Models.DTOs
{
    public class InMemoryConfiguration 
    {
        public IConfiguration Configuration {  get; set; }

        public string? this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public InMemoryConfiguration()
        {
            Dictionary<string, string> inMemorySettings = new Dictionary<string, string>();
            inMemorySettings["TokenKey:JWT"] = "Thambi ennoda account ah hack pannuna unaku life time settlement ra , eesala cup namade";
            Configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }

       
    }

    
}
