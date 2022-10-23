class ContaEspecial : Conta
{   //os : indica herança

    //atributos específicos da conta especial
    public decimal limite;
    
    public ContaEspecial(string num, string tit, decimal sal, decimal lim) : 
    base(num, tit, sal)
    {
        this.limite = lim;
    }

    //public = qualquer lugar acessa a classe pulbic
    //private = só pode ser acessada na classe que ela foi criada
    //protected = pode ser acessada na classe criou, pode ser na classe filha e só, só da família

public override void retirar(decimal val, DateTime dat, string mot){
        // o método sobrescrito é o conceito de POLIMORFISMO
        if(this.saldo+this.limite > val){
             Transacao saque = new Transacao(-val, dat, mot);
             this.movimentacao.Add(saque);
        }
    }

}
