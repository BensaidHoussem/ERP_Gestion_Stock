
using Core.Models;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
[Produces("application/json")]
[Route("ClientController")]
[EnableCors("My Policy")]
[ApiController]
public class ClientController:Controller{
    protected readonly IMediator _mediator ;
    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("GetAllClient")]
    [HttpGet]    public async Task<ActionResult<List<ClientDto>>> GetAllClients(){
        var ls= await Task.FromResult(_mediator.Send(new GetAllClientQuery())).Result;
        return ls.Count()>0?Ok(ls):BadRequest(new{
            Message="Votre liste de client est vide"
        });
    }

    [Route("GetClientId")]
    [HttpGet]

    public async Task<ActionResult<ClientDto>> GetClientByName(string id){
        var x= await Task.FromResult(_mediator.Send(new GetClientIdQuery(id))).Result;
        return x !=null?Ok(x):BadRequest(new{
            Message="Votre Client n'existe pas verifier id "
        });
    }

    [Route("AddClient")]
    [HttpPost]

    public async Task<ActionResult<bool>> AddClient(ClientDto clientDto){
        bool k= await Task.FromResult(_mediator.Send(new AddClientCommand(clientDto))).Result;
        return k?Ok(new{Message="Votre Client a ete ajouter"}):BadRequest(new{
            Message="Votre Client n'est pas ajouter"
        });
    }
    [Route("UpdateClient")]
    [HttpPut]
    public async Task<ActionResult<bool>> UpdateClient(ClientDto clientDto ){
        
        var k= await Task.FromResult(_mediator.Send(new UpdateClientCommand(clientDto))).Result;
        return k?Ok(new{Message="Votre Client a ete Modifier"}):BadRequest(new{
            Message="Votre Client n'est pas Modifier verfier client svp"
        });
        
    }

    [Route("DeleteClient")]
    [HttpDelete]

    public async Task<ActionResult<bool>> DeleteClient(string id){
        var k= await Task.FromResult(_mediator.Send(new DeleteClientCommand(id))).Result;
        return k?Ok(new{Message="Votre Client a ete supprimer "}):BadRequest(new{
            Message="Votre Client n'est pas supprimer verifier id"
        });
    }
   









}

