using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        public SoccerTeamsManager()
        {
        }

        private List<SoccerTeam> ListSoccerTeams = new List<SoccerTeam>();
        private List<SoccerPlayer> ListSoccerPlayers = new List<SoccerPlayer>();

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            IsThereTeamId(id);
            ListSoccerTeams.Add(new SoccerTeam(){
                Id = id,
                Name = name,
                DataCriacao = createDate,
                CorUniformePrincipal = mainShirtColor,
                CorUniformeSecundario = secondaryShirtColor
            });
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            IsTherePlayerId(id);
            IsThereTeam(teamId);
            ListSoccerPlayers.Add(new SoccerPlayer(){
                Id = id,
                TeamId = teamId,
                Name = name,
                BirthDate = birthDate,
                SkillLevel = skillLevel,
                Salary = salary
            });
        }

        public void SetCaptain(long playerId)
        {
            IsTherePlayer(playerId);
            long teamId = ListSoccerPlayers
                .Where(x => x.Id.Equals(playerId))
                .Select(x => x.TeamId)
                .First();
            ListSoccerTeams.ForEach(x => {
                if(x.Id == teamId){
                    x.Capitain = playerId;
                }});
        }

        public long GetTeamCaptain(long teamId)
        {
            IsThereTeam(teamId);
            IsThereCapitain(teamId);
            return ListSoccerTeams
                .Where(x => x.Id.Equals(teamId))
                .Select(x => x.Capitain)
                .FirstOrDefault();
        }

        public string GetPlayerName(long playerId)
        {
            IsTherePlayer(playerId);
            return ListSoccerPlayers
                .Where(x => x.Id.Equals(playerId))
                .Select(x => x.Name)
                .FirstOrDefault();     
        }

        public string GetTeamName(long teamId)
        {
            IsThereTeam(teamId);
            return ListSoccerTeams
                .Where(x => x.Id.Equals(teamId))
                .Select(x => x.Name)
                .FirstOrDefault();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            IsThereTeam(teamId);
            return ListSoccerPlayers
                .Where(x => x.TeamId.Equals(teamId))
                .OrderBy(x => x.Id)
                .Select(x => x.Id)
                .ToList();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            IsThereTeam(teamId);
            return ListSoccerPlayers
                .Where(x => x.TeamId.Equals(teamId))
                .OrderByDescending(x => x.SkillLevel)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            IsThereTeam(teamId);
            return ListSoccerPlayers
                .Where(x => x.TeamId.Equals(teamId))
                .OrderBy(x => x.BirthDate)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public List<long> GetTeams()
        {
            return ListSoccerTeams.OrderBy(x => x.Id).Select(x => x.Id).ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            IsThereTeam(teamId);
            return ListSoccerPlayers
                .Where(x => x.TeamId.Equals(teamId))
                .OrderByDescending(x => x.Salary)
                .Select(x => x.Id)
                .FirstOrDefault();
        }

        public decimal GetPlayerSalary(long playerId)
        {
            IsTherePlayer(playerId);
            return ListSoccerPlayers
                .Where(x => x.Id.Equals(playerId))
                .Select(x => x.Salary)
                .FirstOrDefault();
        }

        public List<long> GetTopPlayers(int top)
        {
            return ListSoccerPlayers
                .OrderByDescending(x => x.SkillLevel)
                .Take(top)
                .Select(x => x.Id)
                .ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            IsThereTeam(teamId);
            IsThereTeam(visitorTeamId);
            string corPrincipalCasa = ListSoccerTeams
                .Where(x => x.Id.Equals(teamId))
                .Select(x => x.CorUniformePrincipal).FirstOrDefault();
            string corPrincipalVisita = ListSoccerTeams
                .Where(x => x.Id.Equals(visitorTeamId))
                .Select(x => x.CorUniformePrincipal).FirstOrDefault();
            
            return corPrincipalCasa == corPrincipalVisita 
                ? ListSoccerTeams.Where(x => x.Id.Equals(visitorTeamId)).Select(x => x.CorUniformeSecundario).FirstOrDefault()
                : ListSoccerTeams.Where(x => x.Id.Equals(visitorTeamId)).Select(x => x.CorUniformePrincipal).FirstOrDefault();
        }

        public void IsThereTeamId(long id)
        {
            bool isThereId = ListSoccerTeams.Any(x => x.Id.Equals(id))
                ? throw new UniqueIdentifierException("Já existe esse Id") : false;
        }

        public void IsTherePlayerId(long id)
        {
            bool isThereId = ListSoccerPlayers.Any(x => x.Id.Equals(id))
                ? throw new UniqueIdentifierException("Já existe esse Id") : false;
        }

        private void IsThereTeam(long id)
        {
            bool isThereTeam = ListSoccerTeams.Any(x => x.Id.Equals(id))
                ? true : throw new TeamNotFoundException("Time não encontrado");
        }

        private void IsTherePlayer(long id)
        {
            bool isTherePlayer = ListSoccerPlayers.Any(x => x.Id.Equals(id))
                ? true : throw new PlayerNotFoundException("Jogador não encotrado");
        }

        private void IsThereCapitain (long id)
        {
            bool isThereCapitain = ListSoccerTeams.Where(x => x.Id.Equals(id)).Any(x => x.Capitain != 0) 
                ? true : throw new CaptainNotFoundException("Não existe capitão");
        }
    }
}

