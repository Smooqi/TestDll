using System.Runtime.InteropServices;
using ToolsKS;

namespace TestDll
{
    internal class Program
    {
        [DllImport("ToolsKS.dll")]
        public static extern string PasswordToHash(string password);
        [DllImport("ToolsKS.dll")]
        public static extern bool VerifyPassword(string password, string passwordHash);
        [DllImport("ToolsKS.dll")]
        public static extern string Info();
        [DllImport("ToolsKS.dll")]
        public static extern void SavePasswordToFile(string password, string patchFile);
        [DllImport("ToolsKS.dll")]
        public static extern void LoadPAsswordFromFile(string patchFile);
 
        static void Main(string[] args)
        {

            var testhash = new ToolHash();
            
            string haslo = "dupa biskupa";
            string hasloHash = testhash.PasswordToHash(haslo);
            string haslo1 = "duppa biskuoa";
            Console.WriteLine(testhash.Info());
            Console.WriteLine($"Hasło: {haslo} po zaszyforwaniu SHA256 to: {hasloHash}");
            if(testhash.VerifyPassword(haslo, testhash.PasswordToHash(haslo1)))
                Console.WriteLine("Hasło poprawne.");
            else
                Console.WriteLine("Hasło niepoprawne.");
            testhash.SavePasswordToFile(hasloHash, @"C:\Users\KSzwajka\Documents\password.txt");
            Console.WriteLine(testhash.StatusMessage);
            testhash.LoadPasswordFromFile(@"C:\Users\KSzwajka\Documents\password.txt");
            Console.WriteLine(testhash.StatusMessage);
            Console.WriteLine(testhash.HashedPassword);


        }
    }
}
