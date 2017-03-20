namespace Ecat.DataLib.DomainModel.Global
{
    public class PersonApp
    {
        public int PersonId { get; set; }
        public int ClientAppId { get; set; }
        public Person Person { get; set; }
        public ClientApp ClientApp { get; set; }
    }
}
