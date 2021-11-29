namespace DIO.Bank;

public class Conta
{
    private string Nome { get; set; }
    private double Credito { get; set; }
    private double Saldo { get; set; }
    private TipoConta TipoConta { get; set; }

    public Conta(string nome, double credito, double saldo, TipoConta tipoConta)
    {
        this.Nome = nome;
        this.Credito = credito;
        this.Saldo = saldo;
        this.TipoConta = tipoConta;
    }

    public bool Sacar(double valorSaque)
    {
        if (this.Saldo - valorSaque < (this.Credito * -1))
        {
            Console.WriteLine("Saldo insuficiente!");

            return false;
        }

        this.Saldo -= valorSaque;

        Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");

        return true;
    }

    public void Depositar(double valorDeposito)
    {
        this.Saldo += valorDeposito;

        Console.WriteLine($"Saldo atual da conta {this.Nome} é {this.Saldo}");
    }

    public void Transferir(double valorTransferencia, Conta contaDestino)
    {
        if (this.Sacar(valorTransferencia))
        {
            contaDestino.Depositar(valorTransferencia);
        }
    }

    public override string ToString()
    {
        string retorno = "";
        retorno += "Nome " + this.Nome + " | ";
        retorno += "Credito " + this.Credito + " | ";
        retorno += "Saldo " + this.Saldo + " | ";
        retorno += "TipoConta " + this.TipoConta;
        return retorno;
    }
}
