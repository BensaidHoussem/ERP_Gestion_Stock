using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
[Route("FournisseurController")]
[EnableCors("My Policy")]
[ApiController]
public class FournisseurController :Controller{
    protected readonly IMediator _mediator ;

    public FournisseurController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("GetAllFournisseur")]
    [HttpGet]

    public async Task<ActionResult<List<FournisseurDto>>> GetAllFourDto(){

        var ls= await Task.FromResult(_mediator.Send(new GetAllFournisseurQuery())).Result;
        return ls.Count()>0?Ok(ls):BadRequest(new{
            Message="Liste Fournisseur est vide"
        });
    }


    [Route("GetFournisseurById")]
    [HttpGet]

    public async Task<ActionResult<FournisseurDto>> GetFourDtoById(string id){
        var x= await Task.FromResult(_mediator.Send(new GetFournisseurById(id))).Result;
        return x !=null?Ok(x):BadRequest(new{
            Message="Votre Fournisseur n'existe pas verifier id "
        });
    }

    [Route("AddFournisseur")]
    [HttpPost]

    public async Task<ActionResult<bool>> AddFourDto(FournisseurDto fourdto){

        bool k= await Task.FromResult(_mediator.Send(new AddFournisseurCommand(fourdto))).Result;
        return k?Ok(new{Message="Votre Fournisseur a ete ajouter"}):BadRequest(new{
            Message="Votre fournisseur n'est pas ajouter"
        });
    }

    [Route("UpdateFournisseur")]
    [HttpPut]

    public async Task<ActionResult<FournisseurDto>> UpdateFourDto(FournisseurDto dto){
        bool x= await Task.FromResult(_mediator.Send(new UpdateFournisseurCommand(dto))).Result;
        return x ?Ok(new{Message="Votre Fournisseur a ete modifier "}):BadRequest(new{
            Message="Votre Fournisseur n'existe pas verifier id "
        });
    }

    [Route("DeleteFournisseur")]
    [HttpDelete]

    public async Task<ActionResult<bool>> DeleteFourDto(string id)
    {
        var k= await Task.FromResult(_mediator.Send(new DeleteFournisseurCommand(id))).Result;
        return k?Ok(new{Message="Votre Fournisseur a ete supprimer "}):BadRequest(new{
            Message="Votre fournisseur n'existe pas verifier id "
        });
    }

    

}