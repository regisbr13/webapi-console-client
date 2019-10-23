using System.Collections.Generic;
using Webapi.Data.VO.Converters.Interfaces;
using Webapi.Models;

namespace Webapi.Data.VO.Converters 
{
    public class ComputerConverter : IParser<Computer, ComputerVO> 
    {
        public ComputerVO Parse (Computer origin) 
        {
            var computerVO = new ComputerVO 
            {
                Id = origin.Id,
                Name = origin.Name,
                Ip = origin.Ip,
                OS = origin.OS,
                DiskSpace = origin.DiskSpace,
                MemoryInfo = origin.MemoryInfo,
                Username = origin.Username,
                UserId = origin.UserId
            };
            return computerVO;
        }

        public Computer Parse (ComputerVO origin) 
        {
            var computer = new Computer 
            {
                Id = origin.Id,
                Name = origin.Name,
                Ip = origin.Ip,
                OS = origin.OS,
                DiskSpace = origin.DiskSpace,
                MemoryInfo = origin.MemoryInfo,
                Username = origin.Username,
                UserId = origin.UserId
            };
            return computer;
        }

        public List<ComputerVO> ParseList (List<Computer> origin) 
        {
            var list = origin.ConvertAll (x => Parse (x));
            return list;
        }

        public List<Computer> ParseList (List<ComputerVO> origin) 
        {
            var list = origin.ConvertAll (x => Parse (x));
            return list;
        }
    }
}