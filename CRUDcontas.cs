class CRUDcontas
{
    //propriedade
    List<Conta> BDcontas = new List<Conta>();
    Tela tela;
    string numero;
    string titular;
    int posicao;

    //construtor
    public CRUDcontas(Tela t)
    {
        this.tela = t;


        //acrescenta duas contas para pesquisa
        // posteriormente este codigo será apagado

        this.BDcontas.Add( new Conta("1001", "Ze comeia", 1000) );
        this.BDcontas.Add( new Conta("1002", "Coelho", 10000));


    }

    //outros métodos
    public void controlarCRUD()
    {
        while(true)
        {   

            // monta a tela do cadastro de contas
            this.montarTela(10,5,70,15);

            // solicita entrada do numero da conta
            Console.SetCursorPosition(22,8);
            this.numero = Console.ReadLine();
            if(this.numero == "") break;

            //procura a conta informada no banco de dados
            bool achou = false;
            int x;
            for(x=0; x<this.BDcontas.Count; x++){
                if (this.BDcontas[x].numero == this.numero)
                {
                    achou = true;
                    this.posicao = x;
                    break;
                }
            }

            //se achou a conta, mostra os dados
            //caso contrário mostra a mensagem de não encontrado
            if(achou)
            {
                    //mostrar os dados conta encontradda
                    Console.SetCursorPosition(22,9);
                    Console.Write(this.BDcontas[this.posicao].titular);
                    Console.SetCursorPosition(22,10);
                    Console.Write(this.BDcontas[this.posicao].saldo);
                    Console.ReadKey();
            }else{
                //mostra a mensagem de conta não encontrada
                Console.SetCursorPosition(22,9);
                Console.Write("Conta não encontrada");

                //pergunta se o usuario deseja cadastrar nova conta
                Console.SetCursorPosition(22,12);
                Console.Write("Deseja Cadastar (S/N)  :  ");
                
                string resp;
                resp = Console.ReadLine();

                //verifica a resposta do usuário 
                if( resp == "S" || resp == "s")
                {
                    // o usuário deseja realizar o cadastro da conta
                    this.tela.limparArea(21,9,69,9);

                    Console.SetCursorPosition(21,9);
                    this.titular = Console.ReadLine();

                    decimal depInicial;
                    Console.SetCursorPosition(21, 10);
                    depInicial = Convert.ToDecimal( Console.ReadLine() );

                    // solicita confitmação para cadastro

                    Console.SetCursorPosition(21,22);
                    Console.Write("Confirma cadastro (S/N)  :  ");
                    resp = Console.ReadLine();

                    //se o usuário confirmou o cadastro 
                    if (resp == "S" || resp == "s"){
                        this.BDcontas.Add( new Conta(this.numero, this.titular, depInicial));
                    }
                }


                Console.ReadKey();
            }
        }
    }

    public void mostrarExtrato(){
        
        // este codigo será alterado no futuro
        this.tela.limparArea(1,4,70,24);

        // limpa a area dad tela para mostrar o extrato
        Console.SetCursorPosition(1,4);
        Console.Write("Numero da conta : ");
        this.numero = Console.ReadLine();
        if  (this.numero != "")
        {
            // procura  a conta informada no banco de dados
            bool achou = false;
            int x;
            for(x=0; x<this.BDcontas.Count; x++)
            {
                if (this.BDcontas[x].numero == this.numero)
                {
                    achou = true;
                    this.posicao = x;
                    break;
                }
            }
            if(achou)
            {
                string extrato = this.BDcontas[this.posicao].mostrarExtrato();
                Console.SetCursorPosition(1,4);
                Console.Write(extrato);
                Console.ReadKey();
            }
        }
    }


    public void montarTela(int ci, int li, int cf, int lf)
    {
        this.tela.montarMoldura(ci, li, cf,lf);
        this.tela.montarLinhaHor(li+2, ci, cf);
        this.tela.centralizar(li+1, ci , cf, "Cadastro de contas");
        Console.SetCursorPosition(11,8);
        Console.Write("Numero   :");
        Console.SetCursorPosition(11,9);
        Console.Write("Titular  :");
        Console.SetCursorPosition(11,10);
        Console.Write("Saldo   :");


    }
}