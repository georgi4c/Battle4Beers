﻿using Battle4Beers.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Battle4Beers.Client.Interfaces;
using Battle4Beers.Client.Models.Actions;
using Battle4Beers.Data;

namespace Battle4Beers.Client.BattleGround
{
    public class GameResult
    {
        private static IBeersWriter beersWriter;
        public static void GetResult(List<Hero> firstTeam, List<Hero> secondTeam)
        {
            var arenaBattle = firstTeam.Count == 2 ? true : false;
            List<Hero> winningTeam;
            List<Hero> losingTeam;

            if (arenaBattle)
            {
                if (firstTeam.Where(a => a.Health <= 0).ToList().Count == 2)
                {
                    winningTeam = secondTeam;
                    losingTeam = firstTeam;
                }
                else
                {
                    winningTeam = firstTeam;
                    losingTeam = secondTeam;
                }
            }
            else
            {
                if (firstTeam[0].Health <= 0)
                {
                    winningTeam = secondTeam;
                    losingTeam = firstTeam;
                }
                else
                {
                    winningTeam = firstTeam;
                    losingTeam = secondTeam;
                }
            }
            // I don't use Dependancy Injection because GameResult is static
            beersWriter = new BeersDatabase();
            beersWriter.Save(winningTeam, losingTeam);
        }

        
    }
}
