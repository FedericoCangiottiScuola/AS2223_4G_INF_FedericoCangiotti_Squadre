﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Team
    {
        string name;

        /// <summary>
        /// List of players of the Team
        /// </summary>
        List<Player> players;

        /// <summary>
        /// Team captain
        /// </summary>
        Player? captain;
        
        /// <summary>
        /// Maximum number of players for each role
        /// </summary>
        const int MAX_RISERVA_PLAYERS = 3;
        const int MAX_ROSA_PLAYERS = 11;

        public Team(string name)
        {
            this.name = name;
            players = new List<Player>();
        }

        /// <summary>
        /// Adding player to a Team
        /// 
        /// We can have a maximum of MAX_ROSA_PLAYERS rosa's players and MAX_RISERVA_PLAYERS riserva's player
        /// </summary>
        /// <param name="player"></param>
        /// <returns>True if player has been inserted</returns>
        public bool AddPlayer(Player player)
        {
            switch (player.Role)
            {
                case Player.ERole.Rosa:
                    int nRosa = 0;
                    foreach(Player p in players)
                    {
                        if (player.Role == Player.ERole.Rosa)
                        {
                            nRosa++;
                        }
                    }
                    if (nRosa + 1 <= MAX_ROSA_PLAYERS)
                    {
                        players.Add(player);
                        return true;
                    }
                    return false;

                case Player.ERole.Riserva:
                    int nRiserva = 0;
                    foreach (Player p in players)
                    {
                        if (player.Role == Player.ERole.Riserva)
                        {
                            nRiserva++;
                        }
                    }
                    if (nRiserva + 1 <= MAX_RISERVA_PLAYERS)
                    {
                        players.Add(player);
                        return true;
                    }
                    return false;

                default: return false;
            }
        }

        /// <summary>
        /// Setting captain of the Team
        /// 
        /// Captain must be in the Rosa role
        /// </summary>
        /// <param name="captain"></param>
        /// <returns>True if captain has been setted</returns>
        public bool AddCaptain(Player captain)
        {
            if (captain.Role == Player.ERole.Rosa)
            {
                this.captain = captain;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get a list of players of the team
        /// </summary>
        /// <returns></returns>
        public string GetPlayers()
        {
            string ris = string.Empty;

            foreach (Player player in players)
            {
                ris += $"{player.Description()}";
            }

            return ris;
        }

        public string Name { get { return name; } }

        public Player? Captain { get { return captain; } }
    }
}
