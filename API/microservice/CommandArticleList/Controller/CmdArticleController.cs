using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("ArticlesController")]
[EnableCors("My Policy")]
[ApiController]
public class CmdArticleController :Controller{
    protected readonly IMediator _mediator ;

    public CmdArticleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("GetAllCommandArticles")]
    [HttpGet]

    public async Task<ActionResult<List<ListarticleDto>>> GetAllCmdArticles(){

        var ls= await Task.FromResult(_mediator.Send(new GetAllCmdArticleListeQuery())).Result;
        return ls.Count()>0?Ok(ls):BadRequest(new{
            Message="Liste d'article des Commandes  est vide"
        });
    }


    [Route("GetCommandArticle")]
    [HttpGet]

    public async Task<ActionResult<ListarticleDto>> GetCmdArticleById(string id){
        var x= await Task.FromResult(_mediator.Send(new GetCmdArticleByIdQuery(id))).Result;
        return x !=null?Ok(x):BadRequest(new{
            Message="Votre Liste Article commande n'existe pas verifier id "
        });
    }

    [Route("AddListeArticleCommande")]
    [HttpPost]

    public async Task<ActionResult<bool>> AddCmdArticle(ListarticleDto cmd){

        bool k= await Task.FromResult(_mediator.Send(new AddCmdArticleListCommand(cmd))).Result;
        return k?Ok(new{Message=$"Votre Liste Article de Commande n°{cmd.CodeartNavigation} a ete ajouter"}):BadRequest(new{
            Message="Votre Article a ete ajouter"
        });
    }

    [Route("UpdateListeArticleCommande")]
    [HttpPut]

    public async Task<ActionResult<ListarticleDto>> UpdateCmdArticle(ListarticleDto dto){
        bool x= await Task.FromResult(_mediator.Send(new UpdateCmdArticleList(dto))).Result;
        return x ?Ok(new{Message="Votre Liste Article de Commande a ete modifier "}):BadRequest(new{
            Message="Votre liste d'Article n'existe pas verifier id "
        });
    }

    [Route("DeleteListeArticleCommande")]
    [HttpDelete]

    public async Task<ActionResult<bool>> DeleteCmdArticle(string id)
    {
        var k= await Task.FromResult(_mediator.Send(new DeleteCmdArticleListCommand(id))).Result;
        return k?Ok(new{Message="Votre Liste d'Article Commande a ete supprimer "}):BadRequest(new{
            Message="Votre liste d'Article Commande n'existe pas verifier id "
        });
    }

    

}