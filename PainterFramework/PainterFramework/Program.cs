using System;

namespace PainterFramework
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (PainterFramework game = new PainterFramework())
            {
                game.Run();
            }
        }
    }
#endif
}

