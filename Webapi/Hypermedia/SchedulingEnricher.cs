using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tapioca.HATEOAS;
using Webapi.Data.VO;

namespace Webapi.Hypermedia
{
    public class SchedulingEnricher : ObjectContentResponseEnricher<SchedulingVO>
    {
        protected override Task EnrichModel(SchedulingVO content, IUrlHelper urlHelper)
        {
            content.Links.Add(new HyperMediaLink 
            {
                Action = HttpActionVerb.GET,
                Href = urlHelper.Link("GetAllSchedulings", new { computerId = content.ComputerId }),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink 
            {
                Action = HttpActionVerb.GET,
                Href = urlHelper.Link("GetSchedulingById", new { id = content.Id }),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink 
            {
                Action = HttpActionVerb.POST,
                Href = urlHelper.Link("NewScheduling", null),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink 
            {
                Action = HttpActionVerb.PUT,
                Href = urlHelper.Link("UpScheduling", new { id = content.Id }),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink 
            {
                Action = HttpActionVerb.DELETE,
                Href = urlHelper.Link("DeleteScheduling", new { id = content.Id }),
                Rel = RelationType.self,
                Type = "no content"
            });
            return null;
        }
    }
}