using System;
using System.Collections.Generic;
using System.Linq;


// Classe Tarefa
class Task
{
    //Atributos
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public DateTime deadline { get; set; }



    //Construtor
    public Task(string title, string description, bool completed, DateTime deadline)
    {
        Title = title;
        Description = description;
        Completed = completed;
        this.deadline = deadline;

    }

    //Implementação da lista de tarefas

    List<Task> tasks = new List<Task>();


    //Metodos

    public void listTask()
    {


        int i = 1;
        bool flag = false;
        Console.WriteLine("----- TAREFAS CONCLUÍDAS -----");
        foreach (var task in tasks)
        {

            if (task.Completed == true)
            {
                flag = true;
                Console.WriteLine(i + " " + task.Title);
                Console.WriteLine(task.Description);
                Console.WriteLine(task.Completed);
                Console.WriteLine(task.deadline);
                i++;
            }
            
        }

        if (flag == false)
        {
            Console.WriteLine("Nenhuma tarefa concluída");
        }

        i = 1;
        Console.WriteLine("----- TAREFAS EM ANDAMENTO -----");
        foreach (var task in tasks)
        {
            if (task.Completed == false)
            {
                Console.WriteLine(i + " " + task.Title);
                Console.WriteLine(task.Description);
                Console.WriteLine(task.Completed);
                Console.WriteLine(task.deadline);
                i++;
            }
        }

    }
    public void setDone()
    {
        listTask();
        Console.WriteLine("Qual tarefa deseja marcar como concluída?");
        int choice = int.Parse(Console.ReadLine()!);
        tasks[choice - 1].Completed = true;
        Console.WriteLine("Tarefa marcada como concluída!");

    }
    public void deleteTask()
    {
        listTask();
        Console.WriteLine("Qual tarefa deseja excluir?");
        int choice = int.Parse(Console.ReadLine()!);
        tasks.RemoveAt(choice - 1);
        Console.WriteLine("Tarefa excluída!");
    }
    public void addTask()
    {
        Console.WriteLine("Qual o título da tarefa?");
        string title = Console.ReadLine()!;
        Console.WriteLine("Qual a descrição da tarefa?");
        string description = Console.ReadLine()!;
        Console.WriteLine("Qual a data limite da tarefa yyyy-mm-dd?");
        DateTime deadline = DateTime.Parse(Console.ReadLine()!);
        tasks.Add(new Task(title, description, false, deadline));
        Console.WriteLine("Tarefa adicionada!");
    }
    public void searchTask()
    {
        Console.WriteLine("Qual a palavra-chave?");
        string search = Console.ReadLine()!.ToLower();
        var result = tasks.Where(task => task.Title.Contains(search) || task.Description.Contains(search)).ToList();
        foreach (var task in result)
        {
            Console.WriteLine(task.Title);
            Console.WriteLine(task.Description);
            Console.WriteLine(task.Completed);
            Console.WriteLine(task.deadline);
        }

    }
    public void statistics()
    {
        Console.WriteLine("Existem {0} tarefas no total.", tasks.Count());
        Console.WriteLine("Existem {0} tarefas concluídas.", tasks.Where(task => task.Completed == true).Count());
        Console.WriteLine("Existem {0} tarefas pendentes.", tasks.Where(task => task.Completed == false).Count());
    }
    public void editTask()
    {
        listTask();
        Console.WriteLine("Qual tarefa deseja editar?");
        int choice = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Qual o novo tiítulo?");
        tasks[choice - 1].Title = Console.ReadLine()!;
        Console.WriteLine("Qual a nova descrição?");
        tasks[choice - 1].Description = Console.ReadLine()!;
        Console.WriteLine("Qual a nova data limite yyyy-mm-dd?");
        tasks[choice - 1].deadline = DateTime.Parse(Console.ReadLine()!);
        Console.WriteLine("Tarefa editada!");
    }


}






namespace MeuProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task("", "", false, DateTime.Now);

            while (true)
            {
                Console.WriteLine("----- TAREFAS -----");
                Console.WriteLine("1. Adicionar tarefa");
                Console.WriteLine("2. Marcar tarefa como concluída");
                Console.WriteLine("3. Excluir tarefa");
                Console.WriteLine("4. Listar tarefas");
                Console.WriteLine("5. Buscar tarefas");
                Console.WriteLine("6. Estatísticas");
                Console.WriteLine("0. Sair");
                Console.WriteLine("Escolha uma opção:");
                int choice = int.Parse(Console.ReadLine()!);
                switch (choice)
                {
                    case 1:
                        task.addTask();
                        break;
                    case 2:
                        task.setDone();
                        break;
                    case 3:
                        task.deleteTask();
                        break;
                    case 4:
                        task.listTask();
                        break;
                    case 5:
                        task.searchTask();
                        break;
                    case 6:
                        task.statistics();
                        break;
                    case 7:
                        task.editTask();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;

                }
            }
        }

    }
}


