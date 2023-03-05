namespace design.LibraryExample;

using Newtonsoft.Json;
using System.Linq;
using implementation;

public class LibraryExample
{

    List<Book> allBooks;
    List<Customer> customers;


    public LibraryExample()
    {
        allBooks = getAllBooks();
        customers = generateCustomers(10);
    }

    public void main()
    {
        listCustomersWishedBooks();

        addBooksToLibrary();
        customersLookForBooks();

        do
        {
            listCustomersWishedBooks();
    
            Console.WriteLine($"There is {allBooks.Count} available.");

            addBooksToLibrary();

        } while (Library.getInstance().countListningObservers() > 0);

        Console.WriteLine("Seems Like everybody is happy :)");
    }

    private void listCustomersWishedBooks()
    {
        Console.WriteLine($"You have {customers.Count} customers. They wanna this following books:");
        int index = 0;
        foreach (Customer customer in customers)
        {
            String? customerBook = customer.bookLookingFor();
            if (customerBook != null)
            {
                Console.WriteLine($"{index++} - {customerBook}");
            }
        }
        Console.WriteLine();
    }

    private void customersLookForBooks()
    {
        foreach (Customer customer in customers)
        {
            customer.lookForBook();
        }
    }

    private void addBooksToLibrary()
    {

        int booksQuantity = getBooksQuantity();

        if (booksQuantity <= 0) return;

        if (booksQuantity > allBooks.Count)
        {
            Console.WriteLine($"There is only {allBooks.Count} books available");
            booksQuantity = allBooks.Count;
        }

        List<Book> bookList = allBooks.Take(booksQuantity).ToList();
        allBooks.RemoveRange(0, booksQuantity);

        Library.getInstance().addBooks(bookList);
    }

    private int getBooksQuantity()
    {
        string? input;

        Console.WriteLine("How many books do you wanna add to the library?");
        input = Console.ReadLine();


        return int.TryParse(input, out int booksQuantity) ? booksQuantity : getBooksQuantity();
    }


    private List<Book> getAllBooks()
    {
        string json = File.ReadAllText("/home/lusca/nerdola/design/LibraryExample/data/books.json");
        var JObjectList = JsonConvert.DeserializeObject<List<dynamic>>(json) ?? new List<dynamic>();
        var books = new List<Book>();

        foreach (dynamic JObject in JObjectList)
        {
            string name = JObject.name, author = JObject.author;
            int year = JObject.year;
            books.Add(new Book(name, author, year));
        }

        return books;
    }
    private List<Customer> generateCustomers(int number = 20)
    {
        var randomNumbers = generateRandomUniqueNumbers(number, allBooks.Count);

        List<Customer> customers = new List<Customer>();

        foreach (int randomNumber in randomNumbers)
        {
            customers.Add(new Customer(allBooks[randomNumber].name));
        }

        return customers;
    }

    private HashSet<int> generateRandomUniqueNumbers(int quantity, int max)
    {
        HashSet<int> numbers = new HashSet<int>();
        Random random = new Random();

        while (quantity > 0)
        {
            int sortedNum = random.Next(max);

            if (numbers.Contains(sortedNum)) continue;

            numbers.Add(sortedNum);
            quantity--;
        }

        return numbers;
    }

}
