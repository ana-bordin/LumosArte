using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

//[Keyless]
public class Usuario
{
    public int Id { get; set; }
    public string Primeiro_nome { get; set; }
    public string Ultimo_nome { get; set; }   
    public string Data_nascimento { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Nome_usuario { get; set; }
    public string Senha { get; set; }
    public string? Descricao { get; set; }
    public string? Foto_Perfil { get; set; }

    public bool SenhaValida(string senha)
    {
        return Senha == senha;
    }

    }
