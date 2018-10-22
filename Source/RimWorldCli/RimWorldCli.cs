using RimWorldUtils;

namespace RimWorldCli
{
    class Program
    {
        /* 
        static void Usage(string catagory = null, string item = null)
        {
            if(catagory == "mod")
            {
                switch(item)
                {
                    case "create":
                        Console.WriteLine("")
                        break;
                }
            }
        } */
        static void Main(string[] args)
        {
            Mod.Create(args[0]);
        }
    }
}
