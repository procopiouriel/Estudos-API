using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;


class Program
{
    static async Task Main(string[] args)
    {
        await EstadoControle.GetEstados();//PEGA TODOS OS ESTADOS
        await EstadoControle.GetEstadoId(11);//PEGA UM ESTADO PELO ID
    }
}

