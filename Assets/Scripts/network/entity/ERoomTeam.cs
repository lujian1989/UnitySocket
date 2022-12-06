using System.Collections.Generic;

namespace network.entity
{
    public class ERoomTeam {
        public int teamId;

        public string teamName;

        public int minPlayers;

        public int maxPlayers;

        public int getTeamId() {
            return this.teamId;
        }

        public void setTeamId(int teamId) {
            this.teamId = teamId;
        }

        public string getTeamName() {
            return this.teamName;
        }

        public void setTeamName(string teamName) {
            this.teamName = teamName;
        }

        public int getMinPlayers() {
            return this.minPlayers;
        }

        public void setMinPlayers(int minPlayers) {
            this.minPlayers = minPlayers;
        }

        public int getMaxPlayers() {
            return this.maxPlayers;
        }

        public void setMaxPlayers(int maxPlayers) {
            this.maxPlayers = maxPlayers;
        }
    }
}

