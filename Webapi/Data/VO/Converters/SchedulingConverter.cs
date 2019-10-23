using System.Collections.Generic;
using Webapi.Data.VO.Converters.Interfaces;
using Webapi.Models;

namespace Webapi.Data.VO.Converters 
{
    public class SchedulingConverter : IParser<Scheduling, SchedulingVO> 
    {
        public SchedulingVO Parse (Scheduling origin) 
        {
            var schedulingVO = new SchedulingVO 
            {
                Id = origin.Id,
                Comand = origin.Comand,
                Response = origin.Response,
                ExecutionDate = origin.ExecutionDate,
                SchedulingDate = origin.SchedulingDate,
                ComputerId = origin.ComputerId
            };
            return schedulingVO;
        }

        public Scheduling Parse (SchedulingVO origin) 
        {
            var scheduling = new Scheduling 
            {
                Id = origin.Id,
                Comand = origin.Comand,
                Response = origin.Response,
                ExecutionDate = origin.ExecutionDate,
                SchedulingDate = origin.SchedulingDate,
                ComputerId = origin.ComputerId
            };
            return scheduling;
        }

        public List<SchedulingVO> ParseList (List<Scheduling> origin) 
        {
            var list = origin.ConvertAll (x => Parse (x));
            return list;
        }

        public List<Scheduling> ParseList (List<SchedulingVO> origin) 
        {
            var list = origin.ConvertAll (x => Parse (x));
            return list;
        }
    }
}