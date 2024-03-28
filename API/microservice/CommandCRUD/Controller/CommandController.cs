
using Core.Models;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
[Produces("application/json")]
[Route("CommandController")]
[EnableCors("My Policy")]
[ApiController]
public class CommandController:Controller{
    protected readonly IMediator _mediator ;
    public CommandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //Get all clients 

    [Route("GetAllComman")]
    [HttpGet]    public async Task<ActionResult<List<CommandeDto>>> GetAllCommanddto(){
        var ls= await Task.FromResult(_mediator.Send(new GetAllCommandQuery())).Result;
        return ls.Count()>0?Ok(ls):BadRequest(new{
            Message="Votre liste de commande est vide"
        });
    }

    [Route("GetCommandbyId")]
    [HttpGet]

    public async Task<ActionResult<CommandeDto>> GetCommandeById(string id){
        var x= await Task.FromResult(_mediator.Send(new GetCommandByIdQuery(id))).Result;
        return x !=null?Ok(x):BadRequest(new{
            Message="Votre Commande n'existe pas verifier id "
        });
    }

    [Route("AddCCommande")]
    [HttpPost]

    public async Task<ActionResult<bool>> AddCommande(CommandeDto cmd){
        bool k= await Task.FromResult(_mediator.Send(new AddCommandCmd(cmd))).Result;
        return k?Ok(new{Message="Votre Commande a ete ajouter"}):BadRequest(new{
            Message="Votre Commande n'est pas ajouter"
        });
    }
    [Route("UpdateCommande")]
    [HttpPut]
    public async Task<ActionResult<bool>> UpdateCommande(CommandeDto cmd ){
        
        var k= await Task.FromResult(_mediator.Send(new UpdateCommandCmd(cmd))).Result;
        return k?Ok(new{Message="Votre Commande a ete Modifier"}):BadRequest(new{
            Message="Votre Commande n'est pas Modifier verfier client svp"
        });
        
    }

    [Route("DeleteCommande")]
    [HttpDelete]

    public async Task<ActionResult<bool>> DeleteCommande(string id){
        var k= await Task.FromResult(_mediator.Send(new DeleteCommandCmd(id))).Result;
        return k?Ok(new{Message="Votre Commande a ete supprimer "}):BadRequest(new{
            Message="Votre Commande n'est pas supprimer verifier id"
        });
    }
   









}

