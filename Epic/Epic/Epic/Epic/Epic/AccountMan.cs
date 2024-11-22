using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMan
{

   public class Game
    {
        private const string DefaultImgSource = "defaulte";
        private string GameName;
        private string Description;
        private double Price;
        private int SellCount;
        private int DiscountPercentage;
        private string ImgSource;

        public Game(string gameName, string description, double price, int discountPercentage, string imgSource = DefaultImgSource)
        {
            GameName = gameName;
            Description = description;
            Price = price;
            DiscountPercentage = discountPercentage;
            ImgSource = DefaultImgSource;
        }

        public string gameName
        {
            get
            {
                return GameName;
            }
        }
        public bool Compare(in Game game)
        {
            return game.GameName == GameName;
        }

        public bool CheckName(string gameName)
        {
            return gameName == GameName;
        }
        public double price
        {
            get
            {
                return Price;
            }
        }
        public void IncreaseSellCount()
        {
            ++SellCount;
        }


    }

   public class Account
    {

        private string Name;
        private string UserName;
        private string Email;
        private string Password;
        private double Balance;
        public string getName
        {
            get
            {
                return Name;
            }
        }
        public Account(string name, string userName, string email, string password, double balance)
        {
            Name = name;
            UserName = userName;
            Email = email;
            Password = password;
            Balance = balance;
        }

        public Account(Account account)
        {
            Name = account.Name;
            UserName = account.UserName;
            Email = account.Email;
            Password = account.Password;
            Balance = account.Balance;
        }
        public bool checkPassword(string password)
        {
            return password == Password;
        }
        public bool ChangePassword(string Oldpassword, string NewPassoword)
        {
            if (checkPassword(Oldpassword))
            {
                Password = NewPassoword;
                return true;
            }
            return false;
        }
        public bool CheckUserName(string userName)
        {
            return userName == UserName;
        }
        public bool CheckEmail(string email)
        {
            return Email == email;
        }

        public bool ChangeUserName(string password, string newUserName)
        {
            if (checkPassword(password))
            {
                UserName = newUserName;
                return true;
            }

            return false;
        }

        public bool Deposit(double amount)
        {
            Balance += amount;
            return true;
        }

        public double balance
        {
            get
            {
                return Balance;
            }
        }
        public bool WithDraw(double amount)
        {
            if (Balance < amount)
            {
                return false;
            }
            Balance -= amount;
            return true;
        }

        public bool Compare(in Account acc)
        {
            return acc.UserName == UserName || acc.Email == Email;
        }

    }


    public class User : Account
    {
        private List<Game> ListOfGames;
        public User(string name, string userName, string email, string password, double balance) : base(name, userName, email, password, balance)
        {
            ListOfGames = new List<Game>();
        }

        public User(Account account) : base(account)
        {

        }

        bool BuyGame(ref Game game)
        {
            if (WithDraw(game.price))
            {
                Game copyObj = game;
                game.IncreaseSellCount();
                ListOfGames.Add(copyObj);
                return true;
            }
            return false;
        }


    }

  public  class Developer : Account
    {
        private List<Game> ListOfGames;
        public Developer(string name, string userName, string email, string password, double balance) : base(name, userName,
            email, password, balance)
        {
            ListOfGames = new List<Game>();
        }

        public Developer(Account acc) : base(acc)
        {

        }
        private int SearchForGame(string GameName)
        {
            for (int i = 0; i < ListOfGames.Count; i++)
            {
                if (ListOfGames[i].CheckName(GameName))
                {
                    return i;
                }

            }

            return -1;
        }
        public bool AddGameToStore(Game game)
        {
            if (SearchForGame(game.gameName) == -1)
            {
                ListOfGames.Add(game);

            }
            return false;
        }

        public bool RemoveGame(string gameName)
        {
            int GamePoss = SearchForGame(gameName);
            if (GamePoss == -1)
            {
                return false;
            }
            else
            {
                ListOfGames.RemoveAt(GamePoss);
                return true;
            }

        }

    }

   public class AccountManger
    {
        private List<Account> ListOfAccount;
        private int LogedInAccount;

        public AccountManger()
        {
            ListOfAccount = new List<Account>();
            LogedInAccount = -1;
        }
        private int SearchForAccount(in Account acc)
        {
            for (int i = 0; i < ListOfAccount.Count; i++)
            {
                if (ListOfAccount[i].Compare(in acc))
                {
                    return i;
                }
            }

            return -1;
        }
        private int SearchForAccountUserName(string UserName)
        {
            for (int i = 0; i < ListOfAccount.Count; i++)
            {
                if (ListOfAccount[i].CheckUserName(UserName))
                {
                    return i;
                }
            }

            return -1;
        }
        private int SearchForAccountEmail(string email)
        {
            for (int i = 0; i < ListOfAccount.Count; i++)
            {
                if (ListOfAccount[i].CheckEmail(email))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool LoginUserName(string userName, string password)
        {
            int AccountPostion = SearchForAccountUserName(userName);
            if (AccountPostion == -1)
            {
                return false;
            }

            if (ListOfAccount[AccountPostion].checkPassword(password))
            {
                LogedInAccount = AccountPostion;
                return true;
            }

            return false;
        }
        public bool LoginEmail(string email, string password)
        {
            int AccountPostion = SearchForAccountEmail(email);
            if (AccountPostion == -1)
            {
                return false;
            }

            if (ListOfAccount[AccountPostion].checkPassword(password))
            {
                LogedInAccount = AccountPostion;
                return true;
            }

            return false;
        }


        public bool AddAccount(Account acc)
        {
            if (SearchForAccount(acc) == -1)
            {
                if (acc is User)
                {
                    ListOfAccount.Add(new User(acc));
                    return true;
                }
                else if (acc is Developer)
                {
                    ListOfAccount.Add(new Developer(acc));
                    return true;
                }

                return false;
            }

            return false;
        }

        public void LogOut()
        {
            LogedInAccount = -1;
        }
        public bool RemoveAccount()
        {
            if (LogedInAccount >= 0 && LogedInAccount < ListOfAccount.Count)
            {
                ListOfAccount.RemoveAt(LogedInAccount);
                LogOut();
                return true;
            }
            return false;
        }

        public bool GetAccountCurLogin(ref Account acc)
        {
            if (LogedInAccount >= 0 && LogedInAccount < ListOfAccount.Count)
            {
                acc = ListOfAccount[LogedInAccount];
                return true;
            }
            return false;
        }
    }


}