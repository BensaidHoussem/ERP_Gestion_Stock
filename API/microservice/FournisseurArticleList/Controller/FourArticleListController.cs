using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
[Produces("application/json")]
[Route("FourrnisseurArticleListController")]
[EnableCors("My Policy")]
[ApiController]
public class FourArticleListController:Controller{
    protected readonly IMediator _mediator ;
    public FourArticleListController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //Get all clients 

    [Route("GetAllFourArticles")]
    [HttpGet]    
    public async Task<ActionResult<List<FouarticleDto>>> GetAllFourArt(){
        var ls= await Task.FromResult(_mediator.Send(new GetAllListFourArticleQuery())).Result;
        return ls.Count()>0?Ok(ls):BadRequest(new{
            Message="Votre liste de fourarticle est vide"
        });
    }

    [Route("GetFournisseurArticleId")]
    [HttpGet]

    public async Task<ActionResult<FouarticleDto>> GetFouArticleById(string id){
        var x= await Task.FromResult(_mediator.Send(new GetFourArticleListById(id))).Result;
        return x !=null?Ok(x):BadRequest(new{
            Message="Votre Fournisseur Article n'existe pas verifier id "
        });
    }

    [Route("AddFourArticle")]
    [HttpPost]

    public async Task<ActionResult<bool>> AddFourArticle(FouarticleDto cmd){
        bool k= await Task.FromResult(_mediator.Send(new AddFourArticleList(cmd))).Result;
        return k?Ok(new{Message="Votre FournisseurArticle a ete ajouter"}):BadRequest(new{
            Message="Votre FournisseurArticle n'est pas ajouter"
        });
    }
    [Route("UpdateFourniisseurArticle")]
    [HttpPut]
    public async Task<ActionResult<bool>> UpdateFouarticle(FouarticleDto cmd ){
        
        var k= await Task.FromResult(_mediator.Send(new UpdateFourArticleList(cmd))).Result;
        return k?Ok(new{Message="Votre FournisseurArticle a ete Modifier"}):BadRequest(new{
            Message="Votre FournisseurArticle n'est pas Modifier verfier client svp"
        });
        
    }

    [Route("DeleteFournisseurArticle")]
    [HttpDelete]

    public async Task<ActionResult<bool>> DeleteFourArticle(string id){
        var k= await Task.FromResult(_mediator.Send(new DeleteFourArticleList(id))).Result;
        return k?Ok(new{Message="Votre FournisseurArticle a ete supprimer "}):BadRequest(new{
            Message="Votre FournisseurArticle n'est pas supprimer verifier id"
        });
    }
   









}

