using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EsportsModels
{
    public class Match
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("scheduled_at")]
        public DateTime? ScheduledAt { get; set; }

        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; set; }

        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }

        [JsonProperty("original_scheduled_at")]
        public DateTime? OriginalScheduledAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("draw")]
        public bool? Draw { get; set; }

        [JsonProperty("forfeit")]
        public bool? Forfeit { get; set; }

        [JsonProperty("rescheduled")]
        public bool? Rescheduled { get; set; }

        [JsonProperty("detailed_stats")]
        public bool? DetailedStats { get; set; }

        [JsonProperty("match_type")]
        public string MatchType { get; set; }

        [JsonProperty("number_of_games")]
        public int? NumberOfGames { get; set; }

        [JsonProperty("game_advantage")]
        public object GameAdvantage { get; set; }

        [JsonProperty("winner_type")]
        public string WinnerType { get; set; }

        [JsonProperty("winner_id")]
        public int? WinnerId { get; set; }

        [JsonProperty("modified_at")]
        public DateTime? ModifiedAt { get; set; }

        // Relacionamentos
        [JsonProperty("videogame")]
        public Videogame Videogame { get; set; }

        [JsonProperty("videogame_title")]
        public VideogameTitle VideogameTitle { get; set; }

        [JsonProperty("videogame_version")]
        public object VideogameVersion { get; set; }

        [JsonProperty("serie")]
        public Serie Serie { get; set; }

        [JsonProperty("serie_id")]
        public int? SerieId { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("league_id")]
        public int? LeagueId { get; set; }

        [JsonProperty("tournament")]
        public Tournament Tournament { get; set; }

        [JsonProperty("tournament_id")]
        public int? TournamentId { get; set; }

        // Objetos aninhados
        [JsonProperty("live")]
        public Live Live { get; set; }

        [JsonProperty("winner")]
        public Team Winner { get; set; }

        [JsonProperty("streams_list")]
        public List<Stream> StreamsList { get; set; }

        [JsonProperty("games")]
        public List<Game> Games { get; set; }

        [JsonProperty("opponents")]
        public List<Opponent> Opponents { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public class Videogame
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public class VideogameTitle
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("videogame_id")]
        public int? VideogameId { get; set; }
    }

    public class Serie
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; set; }

        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }

        [JsonProperty("winner_id")]
        public int? WinnerId { get; set; }

        [JsonProperty("winner_type")]
        public string WinnerType { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("modified_at")]
        public DateTime? ModifiedAt { get; set; }

        [JsonProperty("league_id")]
        public int? LeagueId { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }
    }

    public class League
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("modified_at")]
        public DateTime? ModifiedAt { get; set; }
    }

    public class Tournament
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; set; }

        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }

        [JsonProperty("winner_id")]
        public int? WinnerId { get; set; }

        [JsonProperty("winner_type")]
        public string WinnerType { get; set; }

        [JsonProperty("serie_id")]
        public int? SerieId { get; set; }

        [JsonProperty("modified_at")]
        public DateTime? ModifiedAt { get; set; }

        [JsonProperty("league_id")]
        public int? LeagueId { get; set; }

        [JsonProperty("prizepool")]
        public object Prizepool { get; set; }

        [JsonProperty("tier")]
        public string Tier { get; set; }

        [JsonProperty("has_bracket")]
        public bool? HasBracket { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("live_supported")]
        public bool? LiveSupported { get; set; }

        [JsonProperty("detailed_stats")]
        public bool? DetailedStats { get; set; }
    }

    public class Live
    {
        [JsonProperty("supported")]
        public bool? Supported { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("opens_at")]
        public DateTime? OpensAt { get; set; }
    }

    public class Team
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("acronym")]
        public string Acronym { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("modified_at")]
        public DateTime? ModifiedAt { get; set; }
    }

    public class Stream
    {
        [JsonProperty("main")]
        public bool? Main { get; set; }

        [JsonProperty("official")]
        public bool? Official { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("embed_url")]
        public string EmbedUrl { get; set; }

        [JsonProperty("raw_url")]
        public string RawUrl { get; set; }
    }

    public class Game
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("position")]
        public int? Position { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("complete")]
        public bool? Complete { get; set; }

        [JsonProperty("finished")]
        public bool? Finished { get; set; }

        [JsonProperty("forfeit")]
        public bool? Forfeit { get; set; }

        [JsonProperty("length")]
        public int? Length { get; set; } // em segundos

        [JsonProperty("match_id")]
        public int? MatchId { get; set; }

        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; set; }

        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }

        [JsonProperty("detailed_stats")]
        public bool DetailedStats { get; set; }

        [JsonProperty("winner_type")]
        public string WinnerType { get; set; }

        [JsonProperty("winner")]
        public TeamWinner Winner { get; set; }
    }

    public class TeamWinner
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Opponent
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("opponent")]
        public Team OpponentTeam { get; set; }
    }

    public class Result
    {
        [JsonProperty("team_id")]
        public int? TeamId { get; set; }

        [JsonProperty("score")]
        public int? Score { get; set; }
    }
}