using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LikePindor
{
    class Files
    {
        static string directory = Directory.GetCurrentDirectory();
        public static void Users(out string import)
        {
            import = "";
            string path = $@"{directory}\users.txt";
            try
            {
                using (StreamReader users = new StreamReader(path))
                {
                    import = users.ReadToEnd();
                }
            }
            catch (FileNotFoundException) { }
        }
        public static void Users(string export)
        {
            string path = $@"{directory}\users.txt";
            using (StreamWriter users = new StreamWriter(path))
            {
                users.Write(export);
            }
        }
    }
}
