using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoreboard
{
    class Program
    {
        static void Main(string[] args)
        {
            string home, away;
            home = "Home";
            away = "Away";

            bool gameOver = false;

            int homeScore, awayScore, homeScored, awayScored, game, homeWins, awayWins, homeDarts, awayDarts, home9, away9;
            int home95, home140, home180, away95, away140, away180;
            home95 = home140 = home180 = away95 = away140 = away180 = 0;
            
            game = 1;

            while (game < 2)
            {
                homeScore = awayScore = 501;
                homeWins = awayWins = 0;
                homeDarts = awayDarts = 0;
                home9 = away9 = 0;

                while (!gameOver)
                {
                    printScore(game, home, homeScore, homeDarts, away, awayScore, awayDarts);
                    homeScored = awayScored = -1;
                    while (homeScored < 0 || homeScored > 180)
                    {
                        Int32.TryParse(Console.ReadLine(), out homeScored);
                    }
                    
                    int temp = homeScore - homeScored;
                    if (temp < 2 && temp != 0)
                    {
                        Console.WriteLine("Bust");
                        homeDarts += 3;
                        System.Threading.Thread.Sleep(1000);
                        printScore(game, home, homeScore, homeDarts, away, awayScore, awayDarts);
                    }
                    else
                    {
                        homeScore = homeScore - homeScored;
                        
                        if (homeDarts < 9)
                        {
                            home9 += homeScored;
                        }

                        if (homeScore == 0)
                        {
                            int x;
                            Int32.TryParse(Console.ReadLine(), out x);
                            homeDarts += x;
                        }
                        else
                        {
                            homeDarts += 3;
                        }
                        

                        if (homeScored > 94 && homeScored < 140)
                            home95++;
                        if (homeScored > 139 && homeScored < 180)
                            home140++;
                        if (homeScored == 180)
                            home180++;

                        printScore(game, home, homeScore, homeDarts, away, awayScore, awayDarts);
                    }
                    if (checkGame(homeScore))
                    {
                        game++;
                        homeWins++;
                        break;
                    }

                    while (awayScored < 0 || awayScored > 180)
                    {
                        Int32.TryParse(Console.ReadLine(), out awayScored);
                    }

                    temp = awayScore - awayScored;
                    if (temp < 2 && temp != 0)
                    {
                        Console.WriteLine("Bust");
                        awayDarts += 3;
                        System.Threading.Thread.Sleep(1000);
                        printScore(game, home, homeScore, homeDarts, away, awayScore, awayDarts);
                    }
                    else
                    {
                        awayScore = awayScore - awayScored;
                        
                        if (awayDarts < 9)
                        {
                            away9 += awayScored;
                        }

                        if (awayScore == 0)
                        {
                            int x;
                            Int32.TryParse(Console.ReadLine(), out x);
                            awayDarts += x;
                        }
                        else
                        {
                            awayDarts += 3;
                        }

                        if (awayScored > 94 && awayScored < 140)
                            away95++;
                        if (awayScored > 139 && awayScored < 180)
                            away140++;
                        if (awayScored == 180)
                            away180++;

                        printScore(game, home, homeScore, homeDarts, away, awayScore, awayDarts);
                    }
                    if (checkGame(awayScore))
                    {
                        game++;
                        awayWins++;
                        break;
                    }
                }
                Console.WriteLine("Home:  {0}    First 9:  {1}     Average:  {2}", homeWins, home9 / 3.0, ((501.0 - homeScore) / homeDarts) * 3);
                Console.WriteLine("95+:   {0}    140+:     {1}     180:      {2}", home95, home140, home180);
                Console.WriteLine();
                Console.WriteLine("Away:  {0}    First 9:  {1}     Average:  {2}", awayWins, away9 / 3.0, ((501.0 - awayScore) / awayDarts) * 3);
                Console.WriteLine("95+:   {0}    140+:     {1}     180:      {2}", away95, away140, away180);
                Console.ReadLine();
            }



            
            
        }

        static public bool checkGame(int score)
        {
            if (score == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static public void printScore(int game, string home, int homeScore, int homeDarts, string away, int awayScore, int awayDarts)
        {
            Console.Clear();
            Console.WriteLine("Game: {0}", game);
            Console.WriteLine("{0}:  {1}  ({2})", home, homeScore, homeDarts);
            Console.WriteLine("{0}:  {1}  ({2})", away, awayScore, awayDarts);
        }
    }
}
