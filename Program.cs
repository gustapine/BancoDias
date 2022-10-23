Tela tela = new Tela(ConsoleColor.Black, ConsoleColor.White);
CRUDcontas crudContas = new CRUDcontas(tela);

Console.Clear();

List<string> menu = new List<string>();
string opcao;

//menu do sistema
menu.Add("1 - Contas      ");
menu.Add("2 - Movimentação");
menu.Add("3 - Extrato     ");
menu.Add("0 - Sair        ");

while(true)
{
    tela.montarLinhaHor(2,0,79);
    tela.montarTelaGeral();
    tela.centralizar(1,0,79,"Dias Bank");
    opcao = tela.mostrarMenu(2,3,menu);

    if(opcao == "0") break;

    if(opcao == "1") crudContas.controlarCRUD();
    
    if(opcao == "3") crudContas.mostrarExtrato();
}





// tela.montarTelaGeral();
// tela.montarLinhaHor(2,0,79);
// tela.centralizar(1,0,79,"Dias Bank");

// tela.montarMoldura(5,5,40,12);
// tela.montarMoldura(10,20,70,18);

