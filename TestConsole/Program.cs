using SpongeCity.Asses.BLL;
using SpongeCity.Assess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            using (AssessDBContext db = new AssessDBContext())
            {
                CategoryBLL catebll = new CategoryBLL();
                var list = catebll.GetAllCategory();
                foreach (var item in list)
                {
                    Console.WriteLine(item.DisplayName+item.IsShow);
                }
                Console.WriteLine("End");
                Console.Read();
            }
        }
    }
}
