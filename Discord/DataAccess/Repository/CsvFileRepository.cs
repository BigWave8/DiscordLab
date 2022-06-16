using Discord.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.DataAccess.Repository
{
    public class CsvFileRepository : ICsvFileRepository
    {
        public List<string> ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                List<string> list = new();
                while (!reader.EndOfStream)
                {
                    list.Add(reader.ReadLine());
                }
                return list;
            }
        }
    }
}
