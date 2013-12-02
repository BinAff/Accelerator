namespace BinAff.Facade.Cache
{

    public class Server
    {

        public Cache Cache { get; set; }

        public static Server Current { get; set; }

        static Server()
        {
            Current = new Server
            {
                Cache = new Cache()
            };
        }

    }

}
