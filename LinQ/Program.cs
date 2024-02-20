using LinQ.Methods;
using LinQ.Models;


namespace LinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ForTask1  data = new ForTask1 ();
            foreach (Student item in data.GetCenterByNameWithExperience())
            {
                Console.WriteLine(item.FirstName + " " + item.StudyType);
            }
        }
    }
}
