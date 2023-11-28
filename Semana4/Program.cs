
class Academia
{
    List<Cliente> clientes = new List<Cliente>();
    List<Treinador> treinadores = new List<Treinador>();

    public void run()
    {
        Cliente cliente1 = new Cliente("Arthur", new DateTime(1990, 1, 1), "12345678901", 1.75, 70);
        Cliente cliente2 = new Cliente("Beatriz", new DateTime(1985, 5, 5), "23456789012", 1.80, 80);
        Cliente cliente3 = new Cliente("Catharinha", new DateTime(1995, 1, 1), "34567890123", 1.75, 70);
        Cliente cliente4 = new Cliente("Danilo", new DateTime(1980, 5, 5), "45678901234", 1.90, 80);
        Treinador treinador1 = new Treinador("Esther", new DateTime(1990, 1, 1), "56789012345", "111111111");
        Treinador treinador2 = new Treinador("Fernanda", new DateTime(1985, 5, 5), "67890123456", "222222222");
        Treinador treinador3 = new Treinador("Gustavo", new DateTime(1995, 1, 1), "78901234567", "333333333");
        Treinador treinador4 = new Treinador("Heloisa", new DateTime(1980, 5, 5), "89012345678", "444444444");

        clientes.Add(cliente1);
        clientes.Add(cliente2);
        clientes.Add(cliente3);
        clientes.Add(cliente4);

        treinadores.Add(treinador1);
        treinadores.Add(treinador2);
        treinadores.Add(treinador3);
        treinadores.Add(treinador4);
    }
    public void listarClientegap()
    {
        Console.WriteLine("Digite a idade minima do cliente: ");
        int imin = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Digite a idade maxima do cliente: ");
        int imax = int.Parse(Console.ReadLine()!);

        foreach (var cliente in clientes)
        {
            if (DateTime.Now.Year - cliente.datadenascimento.Year >= imin && DateTime.Now.Year - cliente.datadenascimento.Year <= imax)
            {
                Console.WriteLine("Cliente: " + cliente.nome);
                Console.WriteLine("Data de nascimento: " + cliente.datadenascimento);
                Console.WriteLine("CPF: " + cliente.cpf);
                Console.WriteLine("Altura: " + cliente.altura);
                Console.WriteLine("Peso: " + cliente.peso);
            }


        }
    }
    public void listarClienteimc()
    {
        Console.WriteLine("Digite o IMC: ");
        double imcLimite = double.Parse(Console.ReadLine()!);

        List<Cliente> clientesFiltrados = new List<Cliente>();

        foreach (var cliente in clientes)
        {
            double imc = cliente.calcularIMC();

            if (imc >= imcLimite)
            {
                clientesFiltrados.Add(cliente);
            }
        }

        // Ordenar os clientes com base no IMC
        clientesFiltrados.Sort((c1, c2) => c1.calcularIMC().CompareTo(c2.calcularIMC()));

        // Exibir a lista ordenada
        foreach (var cliente in clientesFiltrados)
        {
            cliente.printCliente();
        }
    }
    public void listarAlfabetica()
    {

        clientes.OrderBy(x => x.nome).ToList().ForEach(x => x.printCliente());
    }
    public void listarIdade()
    {
        clientes.OrderBy(x => x.datadenascimento).ToList().ForEach(x => x.printCliente());
    }
    public void aniversario()
    {
        Console.WriteLine("Aniversariantes do mês: ");
        bool flag = false, flag1 = false;
        foreach (var cliente in clientes)
        {
            if (cliente.datadenascimento.Month == DateTime.Now.Month)
            {
                Console.WriteLine("Nome: " + cliente.nome);
                flag = true;
            }

        }
        foreach (var treinador in treinadores)
        {
            if (treinador.datadenascimento.Month == DateTime.Now.Month)
            {
                Console.WriteLine("Nome: " + treinador.nome);
                flag1 = true;
            }

        }
        if (flag == false && flag1 == false)
        {
            Console.WriteLine("Nenhum cliente ou treinador faz aniverssario nesse mes T.T");
        }
    }
    public void listarTreinador()
    {
        Console.WriteLine("Digite a idade minima do treinador: ");
        int imin = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Digite a idade maxima do treinador: ");
        int imax = int.Parse(Console.ReadLine()!);

        foreach (var treinador in treinadores)
        {
            if (DateTime.Now.Year - treinador.datadenascimento.Year >= imin && DateTime.Now.Year - treinador.datadenascimento.Year <= imax)
            {

                Console.WriteLine("Treinador: " + treinador.nome);
                Console.WriteLine("Data de nascimento: " + treinador.datadenascimento);
                Console.WriteLine("CPF: " + treinador.cpf);
                Console.WriteLine("CREF: " + treinador.cref);
            }


        }
    }
}


class Pessoa
{

    //Atributos
    public string nome { get; set; }
    public DateTime datadenascimento { get; set; }
    private string _cpf;
    public string cpf {
        get { return _cpf; }
        set
        {
            if (value.Length == 11)
            {
                _cpf = value;
            }
            else
            {
                throw new ArgumentException("CPF deve conter 11 digitos");
            }
        }   
    }
}

class Treinador : Pessoa
{
    //Atributos
    public string cref { get; set; }
    //Construtor
    public Treinador(string nome, DateTime datadenascimento, string cpf, string cref)
    {
        this.nome = nome;
        this.datadenascimento = datadenascimento;
        this.cpf = cpf;
        this.cref = cref;
    }
}

class Cliente : Pessoa
{
    //Atributos 
    public double altura { get; set; }
    public double peso { get; set; }
    //Construtor
    public Cliente(string nome, DateTime datadenascimento, string cpf, double altura, double peso)
    {
        this.nome = nome;
        this.datadenascimento = datadenascimento;
        this.cpf = cpf;
        this.altura = altura;
        this.peso = peso;

    }
    //Metodos
    public double calcularIMC()
    {
        return peso / (altura * altura);
    }

    public void printCliente()
    {
        Console.WriteLine("Cliente: " + nome);
        Console.WriteLine("Data de nascimento: " + datadenascimento);
        Console.WriteLine("CPF: " + cpf);
        Console.WriteLine("Altura: " + altura);
        Console.WriteLine("Peso: " + peso);
        Console.WriteLine("IMC: " + calcularIMC());
        Console.WriteLine();
    }


}
class Program
{

    static void Main()
    {
        Academia academia = new Academia();
        academia.run();

        int choice;

        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Listar treinadores");
            Console.WriteLine("2 - Listar clientes entre duas idades");
            Console.WriteLine("3 - Listar clientes por imc");
            Console.WriteLine("4 - Listar clientes alfabeticamente");
            Console.WriteLine("5 - Listar clientes do mais velho para o mais novo");
            Console.WriteLine("6 - aniversariantes do mes");

            Console.WriteLine("0 - Sair");
            choice = int.Parse(Console.ReadLine()!);
            switch (choice)
            {
                case 1:
                    academia.listarTreinador();
                    break;
                case 2:
                    academia.listarClientegap();
                    break;
                case 3:
                    academia.listarClienteimc();
                    break;
                case 4:
                    academia.listarAlfabetica();
                    break;
                case 5:
                    academia.listarIdade();
                    break;
                case 6:
                    academia.aniversario();
                    break;

                case 0:
                    return;
            }
        }
    }
}
