using System.Runtime.InteropServices;
using ToolsKS;

namespace TestDll
{
    internal class Program
    {
        [DllImport("ToolsKS.dll")]
        public static extern string PasswordHash(string password);
        [DllImport("ToolsKS.dll")]
        public static extern bool VerifyPassword(string password, string passwordHash);
        [DllImport("ToolsKS.dll")]
        public static extern string Info();
 
        static void Main(string[] args)
        {

            var testhash = new ToolHash();
            
            string haslo = "dupa biskupa";
            string haslo1 = "duppa biskuoa";
            Console.WriteLine(testhash.Info());
            Console.WriteLine($"Hasło: {haslo} po zaszyforwaniu SHA256 to: {testhash.PasswordHash(haslo1)}");
            if(testhash.VerifyPassword(haslo, testhash.PasswordHash(haslo1)))
                Console.WriteLine("Hasło poprawne.");
            else
                Console.WriteLine("Hasło niepoprawne.");
        }
    }
}
