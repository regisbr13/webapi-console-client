using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tapioca.HATEOAS;
using Webapi.Data.VO;

namespace Webapi.Hypermedia
{
    public class ComputerEnricher : ObjectContentResponseEnricher<ComputerVO>
    {
        protected override Task EnrichModel(ComputerVO content, IUrlHelper urlHelper)
        {
            content.Links.Add(new HyperMediaLink 
            {
                Action = HttpActionVerb.DELETE,
                Href = urlHelper.Link("DeleteComputer", new { id = content.Id }),
                Rel = RelationType.self,
                Type = "no content"
            });
            content.Links.Add(new HyperMediaLink 
            {
                Action = HttpActionVerb.GET,
                Href = urlHelper.Link("GetAllComputer", new { userId = content.UserId }),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink 
            {
                Action = HttpActionVerb.POST,
                Href = urlHelper.Link("NewComputer", null),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });

            return null;
        }
    }
}