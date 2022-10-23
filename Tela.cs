class Tela
{
    //propriedades
    ConsoleColor corFundo, corTexto;

    //Construtor
    public Tela(ConsoleColor cf, ConsoleColor ct){
        this.corFundo = cf;
        this.corTexto = ct;
    }    

    //metodos
    public void configurarTela()
    {
        Console.BackgroundColor = this.corFundo;
        Console.ForegroundColor = this.corTexto;
        Console.Clear();
    }

    public void montarTelaGeral()
    {
        this.montarMoldura(0,0,79,24);
        this.montarLinhaHor(2,0,79);
        this.centralizar(1,0,79,"Dias Bank");
    }

    public void montarMoldura(int ci, int li, int cf, int lf)
    {
        int col, lin;
        this.limparArea(ci,li,cf,lf);
        for(col = ci; col <= cf; col++)
        {
            Console.SetCursorPosition(col, li);
            Console.Write("-");
            Console.SetCursorPosition(col, lf);
            Console.Write("-");
        }

        for (lin = li; lin<=lf; lin++)
        {
            Console.SetCursorPosition(ci, lin);
            Console.Write("|");
            Console.SetCursorPosition(cf, lin);
            Console.Write("|");
        }
        //arruma os cantos
        Console.SetCursorPosition(ci, li); Console.Write("+");
        Console.SetCursorPosition(ci, lf); Console.Write("+");
        Console.SetCursorPosition(cf, li); Console.Write("+");
        Console.SetCursorPosition(cf, lf); Console.Write("+");
        
    }

    public void limparArea(int ci, int li, int cf, int lf)
    {
        int col, lin;
        //percorrer cada uma das colunas
        for(col=ci; col<=cf;col++)
        {
            //percorre cada umas das linhas
            for(lin=li; lin<=lf; lin++)
            {
                //Limpa a posição col,lin
                Console.SetCursorPosition(col,lin);
                Console.Write(" ");
            }
        }
    }
    
    public void montarLinhaHor(int lin, int ci, int cf)
    {
        int col;
        for(col=ci; col<=cf; col++)
        {
            Console.SetCursorPosition(col,lin);
            Console.Write("-");
        }
        Console.SetCursorPosition(ci,lin); Console.Write("+");
        Console.SetCursorPosition(cf,lin); Console.Write("+");
    }


    //com essa classe eu posso fazer quadrinhos aonde quiser
    public void centralizar(int lin, int ci, int cf, string msg)
    {
        int col;
        col = (cf-ci-msg.Length)/2;
        Console.SetCursorPosition(col,lin);
        Console.Write(msg);
    }

    public string mostrarMenu(int ci, int li, List<string> opcoes)
    {
        string op;
        int col, lin, cf, lf;

        lf = li + opcoes.Count + 2;
        cf = ci + opcoes[0].Length + 1;
        this.montarMoldura(ci,li,cf,lf);

        col = ci + 1;
        lin = li + 1;

        foreach(string item in opcoes)
        {
            Console.SetCursorPosition(col,lin);
            Console.Write(item);
            lin ++;
        }
        Console.SetCursorPosition(col, lin);
        Console.Write("Opcao: ");
        op = Console.ReadLine();

        return op;
    }
}