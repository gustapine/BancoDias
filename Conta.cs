class Conta{
    //atributos estáticos
    
    public static int quantContas = 0;


    //atributos
    public List<Transacao> movimentacao = new List<Transacao>();// nessa lista vai ter transação
    public string numero;
    public string titular;
    
    public decimal saldo{
        //programar como vai se comportar
       
        get{
            decimal valorFinal = 0;
            foreach(Transacao transacao in movimentacao){
                valorFinal += transacao.valor;
            }
            return valorFinal;
        }
    }
    //construtor
    public Conta(string num, string tit, decimal sal){
        this.numero = num;
        this.titular = tit;
        this.depositar(sal, DateTime.Now, "Deposito Incial");
        //propriedade estática não usa o this na frente
        quantContas++;
    }

    //métodos
    public string mostrarDados(){
        string texto ="";

        texto += "Conta " + this.numero;
        texto += " do correntista " + this.titular;
        texto += " com saldo de " + this.saldo.ToString();

        return texto;
    }

    public void depositar(decimal val, DateTime dat, string mot ){
        Transacao deposito = new(val, dat, mot);
        this.movimentacao.Add(deposito);
    }

    public virtual void retirar(decimal val, DateTime dat, string mot){
        //o virtual diz que pode ser reescrito na classe filha
       
        if(this.saldo > val){
             Transacao saque = new Transacao(-val, dat, mot);
             this.movimentacao.Add(saque);
        }
    }
    
    public string mostrarExtrato(){
        var extrato = new System.Text.StringBuilder();
        decimal saldo = 0;

        extrato.AppendLine( this.mostrarDados());
        extrato.AppendLine( "Data\t\t\tValor\t\t\t\tSaldo\t\tMotivo"); //cabeçalho do extrato

        for(int x=0; x< movimentacao.Count; x++){
            
            saldo+= this.movimentacao[x].valor;
            extrato.AppendLine(

                //TIRAR EXTRATO
                this.movimentacao[x].data.ToShortDateString()+"\t\t"+
                this.movimentacao[x].data.ToString()+"\t\t"+
                saldo.ToString()+"\t\t"+
                this.movimentacao[x].motivo


            );// vai conter os dados do movimento;
        }
        extrato.AppendLine(saldo.ToString());//mostrar o saldo lá na tela


        return extrato.ToString();
    }
        //PROVA
        //QUANDO TEM O COMANDO RETORNO A VARIÁVEL É APAGADA DA MEMÓRIA
        //CUIDADO COM O this. --> this. chama propriedade


}