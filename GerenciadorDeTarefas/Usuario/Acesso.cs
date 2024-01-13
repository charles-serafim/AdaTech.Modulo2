using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios;

public class Acesso
{
    public int IdUsuario { get; set; }
    public string ChaveDeAcesso { get; set; }
    public string Senha { get; set; }

    public Acesso(int idUsuario, string chaveDeAcesso, string senha)
    {
        IdUsuario = idUsuario;
        ChaveDeAcesso = chaveDeAcesso;
        Senha = senha;
    }
}
