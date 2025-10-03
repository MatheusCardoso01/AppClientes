namespace Cadastro;

public class Cliente
{
    public int id { get; set; }
    public string? Nome { get; set; }
    public DateOnly? DataNascimento { get; set; }
    public DateTime CadastradoEm { get; set; }
    public Decimal Desconto { get; set; }
    
}