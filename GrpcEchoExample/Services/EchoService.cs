using Grpc.Core;
using GrpcEchoExample;

namespace GrpcEchoExample.Services;

public class EchoService : GrpcEchoExample.EchoService.EchoServiceBase
{
    public override Task<EchoReply> Echo(EchoRequest request, ServerCallContext context)
    {
        // Simplesmente retorna a mensagem recebida de volta para o cliente
        return Task.FromResult(new EchoReply
        {
            Message = request.Message
        });
    }
}