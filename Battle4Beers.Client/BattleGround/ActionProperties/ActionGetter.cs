﻿using Battle4Beers.Client.BattleGround.TypesOfAction;
using Battle4Beers.Client.Models;
using Battle4Beers.Client.Utilities.Constants;
using System;
using System.Collections.Generic;

namespace Battle4Beers.Client.BattleGround
{
    public class ActionGetter
    {
        public static void GetTypeOfAction(Models.Action action, Hero player, List<Hero> firstTeam, List<Hero> secondTeam)
        {
            if (action.Type == "friendly")
            {
                var allyTeam = TargetTeamGetter.GetAllies(player, firstTeam, secondTeam);
                if(allyTeam.Count > 1)
                {
                    Hero target = ChooseTarget(allyTeam);
                    FriendlyAction.ExecuteAction(action, player, target);
                }
                else
                {
                    Hero target = allyTeam[0];
                    FriendlyAction.ExecuteAction(action, player, target);
                }
            }
            else if (action.Type == "agressive")
            {
                var enemyTeam = TargetTeamGetter.GetEnemies(player, firstTeam, secondTeam);
                if (enemyTeam.Count > 1)
                {
                    Hero target = ChooseTarget(enemyTeam);
                    AgressiveAction.ExecuteAction(action, player, target);
                }
                else
                {
                    Hero target = enemyTeam[0];
                    AgressiveAction.ExecuteAction(action, player, target);
                }
            }
            else if(action.Type == "passive")
            {
                PassiveAction.ExecuteAction(action, player);
            }
            else if(action.Type == "buff")
            {
                var enemyTeam = TargetTeamGetter.GetEnemies(player, firstTeam, secondTeam);
                if (enemyTeam.Count > 1)
                {
                    Hero target = ChooseTarget(enemyTeam);
                    BuffAction.ExecuteAction(action, player, target);
                }
                else
                {
                    Hero target = enemyTeam[0];
                    BuffAction.ExecuteAction(action, player, target);
                }
            }
            else if(action.Type == "debuff")
            {
                var enemyTeam = TargetTeamGetter.GetEnemies(player, firstTeam, secondTeam);
                if (enemyTeam.Count > 1)
                {
                    Hero target = ChooseTarget(enemyTeam);
                    DebuffAction.ExecuteAction(action, player, target);
                }
                else
                {
                    Hero target = enemyTeam[0];
                    DebuffAction.ExecuteAction(action, player, target);
                }
            }
            else if (action.Type == "execution")
            {
                var enemyTeam = TargetTeamGetter.GetEnemies(player, firstTeam, secondTeam);
                bool isExecuted;
                Hero target;
                if (enemyTeam.Count > 1)
                {
                    target = ChooseTarget(enemyTeam);
                    isExecuted = ExecutionAction.ExecuteAction(action, player, target);
                }
                else
                {
                    target = enemyTeam[0];
                    isExecuted = ExecutionAction.ExecuteAction(action, player, target);
                }

                if(isExecuted)
                {
                    HeroCooldownReductor.ReduceCooldowns(player);
                    target.GetDamaged(AbilityConstants.ExecutionDamage);
                }
                else
                {
                    var key = new ConsoleKeyInfo();
                    while (key.Key != ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Constants.GameTitle);
                        Console.WriteLine($"{target.Name}'S HEALTH IS NOT LOW ENOUGH TO BE EXECUTED!");
                        Console.WriteLine("-- PRESS ENTER TO CONTINUE TO ACTION MENU TO SELECT A DIFFERENT ACTION --");
                        key = Console.ReadKey();
                    }
                    Combat.PlayerTurn(player);
                }
                
            }

        }

        private static Hero ChooseTarget(List<Hero> currentTeam)
        {
            return TypesOfMenu.SelectATarget(currentTeam);
        }
    }
}