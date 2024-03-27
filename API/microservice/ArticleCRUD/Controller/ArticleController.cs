using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("ArticlesController")]
[EnableCors("My Policy")]
[ApiController]
public class ArticleController :Controller{
    protected readonly IMediator _mediator ;

    public ArticleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("GetAllArticle")]
    [HttpGet]

    public async Task<ActionResult<List<ArticleDto>>> GetAllArticles(){

        var ls= await Task.FromResult(_mediator.Send(new GetAllArticleQuery())).Result;
        return ls.Count()>0?Ok(ls):BadRequest(new{
            Message="Liste article est vide"
        });
    }


    [Route("GetArticleById")]
    [HttpGet]

    public async Task<ActionResult<ArticleDto>> GetArticleById(string id){
        var x= await Task.FromResult(_mediator.Send(new GetArticleByIdQuery(id))).Result;
        return x !=null?Ok(x):BadRequest(new{
            Message="Votre Article n'existe pas verifier id "
        });
    }

    [Route("AddArticle")]
    [HttpPost]

    public async Task<ActionResult<bool>> AddArticle(ArticleDto articleDto){

        bool k= await Task.FromResult(_mediator.Send(new AddArticleCommand(articleDto))).Result;
        return k?Ok(new{Message="Votre Article a ete ajouter"}):BadRequest(new{
            Message="Votre Article a ete ajouter"
        });
    }

    [Route("UpdateArticle")]
    [HttpPut]

    public async Task<ActionResult<ArticleDto>> UpdateArticle(ArticleDto dto){
        bool x= await Task.FromResult(_mediator.Send(new UpdateArticleCommand(dto))).Result;
        return x ?Ok(new{Message="Votre Article a ete modifier "}):BadRequest(new{
            Message="Votre Article n'existe pas verifier id "
        });
    }

    [Route("DeleteArticle")]
    [HttpDelete]

    public async Task<ActionResult<bool>> DeleteArticle(string id)
    {
        var k= await Task.FromResult(_mediator.Send(new DeleteArticleCommand(id))).Result;
        return k?Ok(new{Message="Votre Article a ete supprimer "}):BadRequest(new{
            Message="Votre Article n'existe pas verifier id "
        });
    }

    

}