namespace TestApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            #if DEBUG
                Service myService = new Service();
                myService.onDebug();
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

            #else
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new Service()
                };
                ServiceBase.Run(ServicesToRun);
            #endif
        }
    }
}
