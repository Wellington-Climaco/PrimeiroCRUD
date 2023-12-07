using System.Data;
using System.Data.SqlClient;
using System.Net;
using Dapper;
using Dapper.Contrib.Extensions;
class Program
{
    private const string ConnectionString = @"server=localhost,1433;Database=Blog;User Id =sa;Password = 1q2w3e4r@#$ ";

    static void Main(string[] args)
    {

        //ReadUsers();
        //ReadUser();
        //CreateUser();
        //UpdateUser();
        DeleteUser();

    }

    public static void ReadUsers()
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            var users = connection.GetAll<User>();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name}");
            }
        }
    }

    public static void ReadUser()
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            var user = connection.Get<User>(1);

            Console.WriteLine($"{user.Name}");
        }
    }

    public static void CreateUser()
    {
        var user = new User()
        {
            Bio = "Aula Curso",
            Email = "wellington@email.com",
            Image = "HTTPS://...",
            Name = "Aula",
            PasswordHash = "HASH",
            Slug = "curso-sql"
        };
        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Insert<User>(user);

            Console.WriteLine($"cadastro realizado com sucesso!!");
        }
    }

    public static void UpdateUser()
    {
        var user = new User()
        {
            Id = 2,
            Bio = "Aula Curso Update User",
            Email = "wellington@email.com",
            Image = "HTTPS://...",
            Name = "Aula UpdateUser",
            PasswordHash = "HASH",
            Slug = "Atualizando-sql"
        };

        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Update<User>(user);

            Console.WriteLine($"atualização realizada com sucesso!!");
        }
    }

    public static void DeleteUser()
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            var user = connection.Get<User>(10);
            connection.Delete<User>(user);
            Console.WriteLine("Usuário deletado com sucesso!!");
        }
    }
}

